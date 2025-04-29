import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Home from "./pages/Home";
import About from "./pages/About";
import Team from "./pages/Team";

function App() {
  return (
    <Router>
      <div className="min-h-screen bg-white text-black font-sans">
        <header className="p-5 shadow-md bg-gray-100 flex flex-col items-center space-y-2 sm:space-y-0 sm:flex-row sm:justify-between sm:items-center">
          <h1 className="text-3xl font-bold">GraphWay</h1>

          <p className="text-sm text-gray-600 text-center sm:text-base sm:mx-auto">
            Розроблено студентами ЧНУ, кафедра МПУіК, спеціальність 122 –
            Комп’ютерні науки
          </p>

          <nav className="space-x-6 text-lg">
            <Link to="/" className="hover:underline">
              Головна
            </Link>
            <Link to="/about" className="hover:underline">
              Про додаток
            </Link>
            <Link to="/team" className="hover:underline">
              Наша команда
            </Link>
          </nav>
        </header>

        <main className="p-6 max-w-5xl mx-auto">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/about" element={<About />} />
            <Route path="/team" element={<Team />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
}

export default App;
