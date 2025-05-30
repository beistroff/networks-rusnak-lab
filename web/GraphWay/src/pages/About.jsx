import React from "react";

function About() {
  return (
    <div className="bg-white text-black p-10 space-y-10">
      <h2 className="text-4xl font-bold text-center mb-6">Про додаток</h2>

      <section className="bg-gray-100 p-6 rounded-lg shadow-md space-y-6">
        <p><strong>Назва додатку:</strong> GraphWay</p>

        <p><strong>Мета програми:</strong></p>
        <ul className="list-disc list-inside space-y-2">
          <li>Реалізація алгоритму Мінті для знаходження найкоротшого шляху на мережі.</li>
          <li>Реалізація алгоритму Форда-Фалкерсона для знаходження максимального потоку та мінімального перерізу.</li>
        </ul>

        <p><strong>Опис:</strong></p>
        <p>
          Програма розроблена студентами ЧНУ, кафедри МПУіК, з метою популяризації рішень оптимізаційних задач
          на мережах у рамках навчальної дисципліни "Мережі та потоки".
        </p>
        <p>Додаток дозволяє:</p>
        <ul className="list-disc list-inside space-y-2">
          <li>Будувати найкоротші шляхи на орієнтованих графах методом Мінті.</li>
          <li>Знаходити максимальний потік та мінімальний переріз у мережі методом Форда-Фалкерсона.</li>
        </ul>

        <p><strong>Використані алгоритми:</strong></p>
        <ul className="list-disc list-inside space-y-2">
          <li>Метод Мінті для пошуку найкоротшого шляху.</li>
          <li>Метод Форда-Фалкерсона для визначення максимального потоку.</li>
        </ul>

        <p><strong>Керівник проєкту:</strong></p>
        <p>Руснак Микола Андрійович (кандидат фізико-математичних наук, доцент кафедри МПУіК)</p>

        <p><strong>Кафедра:</strong></p>
        <p>Математичних проблем управління і кібернетики (МПУіК), Чернівецький національний університет імені Юрія Федьковича.</p>

      </section>
    </div>
  );
}

export default About;
