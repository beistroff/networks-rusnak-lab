import React from "react";

function Team() {
  const members = [
    { name: "Козак Андрій", role: "Frontend Developer", email: "kozak.andrii.o@chnu.edu.ua" },
    { name: "Галяс Андрій", role: "DevOps Engineer", email: "halias.andrii@chnu.edu.ua" },
    { name: "Вишньовська Яна", role: "Backend Developer", email: "vyshnovska.yana@chnu.edu.ua" },
    { name: "Фарина Юрій", role: "Product Manager", email: "faryna.yurii@chnu.edu.ua" },
    { name: "Хойський Олександр", role: "Backend Developer", email: "khoiskyi.oleksandr@chnu.edu.ua" },
    { name: "Шепелюк Максим", role: "QA Engineer", email: "shepeliuk.maksym@chnu.edu.ua" },
  ];

  return (
    <div className="bg-white text-black p-10 min-h-screen flex flex-col justify-between">
      <div>
        <h2 className="text-4xl font-bold text-center mb-10">Команда проєкту</h2>
        <ul className="space-y-4 max-w-xl mx-auto">
          {members.map((member, index) => (
            <li key={index} className="bg-gray-100 p-4 rounded-lg shadow-md">
              <p className="text-xl font-semibold">{member.name}</p>
              <p className="text-gray-600">{member.role}</p>
              <p className="text-gray-500 text-sm">{member.email}</p>
            </li>
          ))}
        </ul>
      </div>

      <footer className="text-center mt-10 pt-6 border-t text-sm text-gray-500">
        Розроблено студентами ЧНУ, кафедра МПУіК
      </footer>
    </div>
  );
}

export default Team;
