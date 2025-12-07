import { useState } from 'react';
import Dashboard from './components/Dashboard';
import PatientList from './components/Patients/PatientList';
import DoctorList from './components/Doctors/DoctorList';
import AppointmentList from './components/Appointments/AppointmentList';
import './App.css';

function App() {
  const [currentPage, setCurrentPage] = useState('dashboard');

  const renderPage = () => {
    switch (currentPage) {
      case 'dashboard':
        return <Dashboard />;
      case 'patients':
        return <PatientList />;
      case 'doctors':
        return <DoctorList />;
      case 'appointments':
        return <AppointmentList />;
      default:
        return <Dashboard />;
    }
  };

  return (
    <div className="app">
      <nav className="sidebar">
        <div className="logo">
          <h2>🏥 MediCore</h2>
          <p>Hospital ERP</p>
        </div>

        <ul className="nav-menu">
          <li
            className={currentPage === 'dashboard' ? 'active' : ''}
            onClick={() => setCurrentPage('dashboard')}
          >
            <span className="icon">📊</span>
            Dashboard
          </li>
          <li
            className={currentPage === 'patients' ? 'active' : ''}
            onClick={() => setCurrentPage('patients')}
          >
            <span className="icon">👥</span>
            Patients
          </li>
          <li
            className={currentPage === 'doctors' ? 'active' : ''}
            onClick={() => setCurrentPage('doctors')}
          >
            <span className="icon">👨‍⚕️</span>
            Doctors
          </li>
          <li
            className={currentPage === 'appointments' ? 'active' : ''}
            onClick={() => setCurrentPage('appointments')}
          >
            <span className="icon">📅</span>
            Appointments
          </li>
        </ul>

        <div className="sidebar-footer">
          <p>© 2024 MediCore</p>
          <p>v1.0.0</p>
        </div>
      </nav>

      <main className="main-content">
        {renderPage()}
      </main>
    </div>
  );
}

export default App;