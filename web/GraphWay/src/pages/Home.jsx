// src/pages/Home.jsx
import React from "react";

function Home() {
  return (
    <div className="bg-white text-black p-10">
      <div className="text-center space-y-8">
        <h2 className="text-4xl font-bold">
          Ласкаво просимо до <span className="text-blue-600">GraphWay</span>
        </h2>
        <p className="text-lg text-gray-700 max-w-xl mx-auto">
          Цей додаток створено студентами ЧНУ, кафедри МПУіК, в рамках навчального проєкту.
        </p>
        <p className="text-base text-gray-600">
          Після оплати файл буде автоматично надіслано на вашу електронну пошту.
        </p>
        <div className="flex justify-center">
          <a
            href="https://payhip.com/b/VFsSv"
            target="_blank"
            rel="noreferrer"
            className="px-6 py-3 bg-green-600 hover:bg-green-700 text-white rounded-lg shadow-md transition-all"
          >
            Оплатити
          </a>
        </div>
      </div>
    </div>
  );
}

export default Home;
