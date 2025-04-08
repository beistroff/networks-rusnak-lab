using System.Windows.Forms;

namespace rysnak
{
    public partial class Form1 : Form
    {
        // Зберігаємо ребра графа
        private Dictionary<int, List<(int destination, int weight)>> graph;
        private Dictionary<int, Point> nodePositions = new Dictionary<int, Point>();
        private HashSet<int> allNodes = new HashSet<int>();

        public Form1()
        {
            InitializeComponent();
            graph = new Dictionary<int, List<(int destination, int weight)>>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            graph.Clear();
            allNodes.Clear();

            string[] lines = textBox1.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            ParseLines(lines);

            if (!int.TryParse(textBox2.Text.Trim(), out int target))
            {
                MessageBox.Show("Будь ласка, введіть коректне число в текстове поле для цільової вершини.", "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            (List<int> path, int cost) = Dijkstra(1, target);

            if (path.Count == 0)
                textBox3.Text = "Шлях не знайдено";
            else
                textBox3.Text = string.Join(" - ", path) + $" | Ціна: {cost}";

            AutoArrangeNodes();
            DrawGraph(path);
        }
        private void ParseLines(string[] lines)
        {
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length < 2) continue;

                string[] nodes = parts[0].Split('-');
                int from = int.Parse(nodes[0]);
                int to = int.Parse(nodes[1]);
                int weight = int.Parse(parts[1]);

                if (!graph.ContainsKey(from)) graph[from] = new List<(int, int)>();
                if (!graph.ContainsKey(to)) graph[to] = new List<(int, int)>();

                graph[from].Add((to, weight));
                // graph[to].Add((from, weight)); // Розкоментуй для неорієнтованого графа

                allNodes.Add(from);
                allNodes.Add(to);
            }
        }

        //private void AutoArrangeNodes()
        //{
        //    nodePositions.Clear();
        //    int level = 0;
        //    int nodesPerLevel = 1;
        //    int spacingX = 100;
        //    int spacingY = 100;
        //    int centerX = pictureBox1.Width / 2;

        //    List<int> sortedNodes = allNodes.ToList();
        //    sortedNodes.Sort();

        //    int index = 0;
        //    while (index < sortedNodes.Count)
        //    {
        //        int nodesThisLevel = Math.Min(nodesPerLevel, sortedNodes.Count - index);
        //        int totalWidth = (nodesThisLevel - 1) * spacingX;

        //        for (int i = 0; i < nodesThisLevel; i++)
        //        {
        //            int x = centerX - totalWidth / 2 + i * spacingX;
        //            int y = 50 + level * spacingY;
        //            nodePositions[sortedNodes[index]] = new Point(x, y);
        //            index++;
        //        }

        //        level++;
        //        nodesPerLevel++;
        //    }
        //}

        private void AutoArrangeNodes()
        {
            nodePositions.Clear();
            Random rand = new Random();

            int level = 0;
            int nodesPerLevel = 1;
            int spacingY = 220;
            int margin = 100;
            int maxTries = 500;
            int minDistance = 100; // Мінімальна відстань між вузлами

            List<int> sortedNodes = allNodes.ToList();
            sortedNodes.Sort();

            int index = 0;

            while (index < sortedNodes.Count)
            {
                int nodesThisLevel = Math.Min(nodesPerLevel, sortedNodes.Count - index);
                int baseY = 50 + level * spacingY;

                for (int i = 0; i < nodesThisLevel; i++)
                {
                    int node = sortedNodes[index];
                    Point newPoint = Point.Empty;
                    bool found = false;

                    for (int tries = 0; tries < maxTries; tries++)
                    {
                        int x = rand.Next(margin, pictureBox1.Width - margin);
                        int y = baseY + rand.Next(-30, 30);
                        Point candidate = new Point(x, y);

                        bool overlaps = false;

                        foreach (var existing in nodePositions.Values)
                        {
                            double distance = Math.Sqrt(Math.Pow(existing.X - candidate.X, 2) + Math.Pow(existing.Y - candidate.Y, 2));
                            if (distance < minDistance)
                            {
                                overlaps = true;
                                break;
                            }
                        }

                        if (!overlaps)
                        {
                            newPoint = candidate;
                            found = true;
                            break;
                        }
                    }

                    // Якщо після всіх спроб не вдалося знайти вільне місце — просто зсунь нижче
                    if (!found)
                    {
                        newPoint = new Point(margin + rand.Next(0, pictureBox1.Width - 2 * margin), baseY + 200);
                    }

                    nodePositions[node] = newPoint;
                    index++;
                }

                level++;
                nodesPerLevel++;
            }
        }


        // Допоміжний метод для обчислення відстані між двома точками
        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }



        private void DrawGraph(List<int> path)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            int radius = 20;
            Font font = new Font("Arial", 10);
            Pen arrowPen = new Pen(Color.Black, 2) { EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor };
            Pen highlightPen = new Pen(Color.Red, 3) { EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor };

            //foreach (var from in graph.Keys)
            //{
            //    foreach (var (to, weight) in graph[from])
            //    {
            //        if (!nodePositions.ContainsKey(from) || !nodePositions.ContainsKey(to))
            //            continue;

            //        Point p1 = nodePositions[from];
            //        Point p2 = nodePositions[to];

            //        if (path != null && path.Contains(from) && path.Contains(to) &&
            //            path.IndexOf(to) - path.IndexOf(from) == 1)
            //            g.DrawLine(highlightPen, p1, p2);
            //        else
            //            g.DrawLine(arrowPen, p1, p2);

            //        int midX = (p1.X + p2.X) / 2;
            //        int midY = (p1.Y + p2.Y) / 2;
            //        g.DrawString(weight.ToString(), font, Brushes.Blue, midX, midY);
            //    }
            //}

            Random rand = new Random();
            Dictionary<(int, int), Point> edgeOffsets = new Dictionary<(int, int), Point>(); // Для збереження зсуву для кожного ребра

            foreach (var from in graph.Keys)
            {
                foreach (var (to, weight) in graph[from])
                {
                    if (!nodePositions.ContainsKey(from) || !nodePositions.ContainsKey(to))
                        continue;

                    Point p1 = nodePositions[from];
                    Point p2 = nodePositions[to];

                    // Обчислюємо унікальний ключ для кожного ребра
                    var edgeKey = (from < to) ? (from, to) : (to, from);

                    // Якщо вже були обчислені зсуви для цього ребра, використовуємо їх
                    if (!edgeOffsets.ContainsKey(edgeKey))
                    {
                        // Для кожного ребра додаємо випадковий зсув для контролюючих точок
                        int offsetX = rand.Next(-50, 50); // Випадковий зсув по осі X
                        int offsetY = rand.Next(-30, 30); // Випадковий зсув по осі Y
                        edgeOffsets[edgeKey] = new Point(offsetX, offsetY);
                    }

                    // Отримуємо зсув для поточної дуги
                    Point offset = edgeOffsets[edgeKey];

                    // Якщо ця дуга належить шляху — підсвічується червоним
                    if (path != null && path.Contains(from) && path.Contains(to) &&
                        path.IndexOf(to) - path.IndexOf(from) == 1)
                        g.DrawLine(highlightPen, p1, p2); // Червона стрілка
                    else
                    {
                        // Для вигнутих ліній використовуємо криву Безьє
                        Point controlPoint = new Point((p1.X + p2.X) / 2 + offset.X,
                                                      (p1.Y + p2.Y) / 2 + offset.Y);
                        g.DrawBezier(arrowPen, p1, controlPoint, controlPoint, p2); // Стрілка з вигином
                    }

                    // Малюємо вагу дуги біля її середини
                    int midX2 = p2.X - (p2.X - p1.X) / 5; // Ближче до p2
                    int midY2 = p2.Y - (p2.Y - p1.Y) / 5;

                    // Вимірюємо розмір тексту для ваги
                    string weightText = weight.ToString();
                    SizeF size = g.MeasureString(weightText, font);

                    // Малюємо прямокутник з білим фоном для ваги
                    g.FillRectangle(Brushes.White, midX2 - size.Width / 2 - 2, midY2 - size.Height / 2 - 2, size.Width + 4, size.Height + 4);

                    // Малюємо саму вагу
                    g.DrawString(weightText, font, Brushes.Black, midX2 - size.Width / 2, midY2 - size.Height / 2);
                }
            }


            foreach (var kvp in nodePositions)
            {
                int node = kvp.Key;
                Point pos = kvp.Value;

                g.FillEllipse(Brushes.LightYellow, pos.X - radius, pos.Y - radius, radius * 2, radius * 2);
                g.DrawEllipse(Pens.Black, pos.X - radius, pos.Y - radius, radius * 2, radius * 2);

                string text = node.ToString();
                SizeF size = g.MeasureString(text, font);
                g.DrawString(text, font, Brushes.Black, pos.X - size.Width / 2, pos.Y - size.Height / 2);
            }

            pictureBox1.Image = bmp;
        }

        private (List<int>, int) Dijkstra(int start, int end)
        {
            var distances = new Dictionary<int, int>();
            var previous = new Dictionary<int, int>();
            var visited = new HashSet<int>();
            var queue = new PriorityQueue<int, int>();

            foreach (var node in graph.Keys)
            {
                distances[node] = int.MaxValue;
            }

            distances[start] = 0;
            queue.Enqueue(start, 0);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (visited.Contains(current))
                    continue;

                visited.Add(current);

                if (current == end)
                    break;

                foreach (var (neighbor, weight) in graph[current])
                {
                    int newDist = distances[current] + weight;
                    if (newDist < distances.GetValueOrDefault(neighbor, int.MaxValue))
                    {
                        distances[neighbor] = newDist;
                        previous[neighbor] = current;
                        queue.Enqueue(neighbor, newDist);
                    }
                }
            }

            if (!distances.ContainsKey(end) || distances[end] == int.MaxValue)
                return (new List<int>(), 0);

            List<int> path = new List<int>();
            int currentNode = end;
            while (currentNode != start)
            {
                path.Add(currentNode);
                if (!previous.ContainsKey(currentNode))
                    return (new List<int>(), 0); // шляху немає
                currentNode = previous[currentNode];
            }
            path.Add(start);
            path.Reverse();

            return (path, distances[end]);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog.FileName);
                textBox1.Text = string.Join(Environment.NewLine, lines); // Показуємо у TextBox
            }
        }
    }
}
