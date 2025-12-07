# 🏥 MediCore Hospital ERP System

A full-stack Hospital Management System built with **ASP.NET Core**, **React**, and **PostgreSQL**.

![MediCore Banner](https://img.shields.io/badge/MediCore-Hospital%20ERP-blue?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=flat-square)
![React](https://img.shields.io/badge/React-18-blue?style=flat-square)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-14+-green?style=flat-square)

---

## 📖 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [API Endpoints](#api-endpoints)
- [Screenshots](#screenshots)
- [Troubleshooting](#troubleshooting)
- [Contributing](#contributing)
- [License](#license)

---

## 🎯 Overview

**MediCore** is a modern Hospital ERP (Enterprise Resource Planning) system designed to streamline healthcare operations. It provides comprehensive management of patients, doctors, and appointments with an intuitive user interface.

### Key Highlights

✅ Complete CRUD operations for Patients, Doctors, and Appointments  
✅ Real-time dashboard with statistics  
✅ Appointment scheduling with status management  
✅ RESTful API architecture  
✅ Responsive design  
✅ PostgreSQL database with Entity Framework Core  

---

## ✨ Features

### 👥 Patient Management
- Add, edit, and delete patient records
- Store comprehensive patient information (name, DOB, gender, contact details)
- Search and filter patients
- View patient appointment history

### 👨‍⚕️ Doctor Management
- Manage doctor profiles
- Specialization tracking
- View doctor schedules
- Contact information management

### 📅 Appointment System
- Schedule appointments between patients and doctors
- Date and time selection
- Status tracking (Scheduled, Completed, Cancelled)
- Notes and special instructions
- Real-time availability checking

### 📊 Dashboard
- Total patients count
- Total doctors count
- Total appointments
- Today's appointments
- Quick action buttons

---

## 🛠️ Tech Stack

### Backend
- **Framework**: ASP.NET Core 8.0 Web API
- **ORM**: Entity Framework Core 8.0
- **Database**: PostgreSQL 14+
- **Architecture**: RESTful API
- **Design Pattern**: Repository Pattern with DTOs

### Frontend
- **Framework**: React 18
- **Build Tool**: Vite
- **Styling**: Custom CSS
- **HTTP Client**: Fetch API
- **State Management**: React Hooks (useState, useEffect)

### Development Tools
- **IDE**: Visual Studio Code / Visual Studio 2022
- **API Testing**: Swagger UI
- **Database Management**: pgAdmin 4
- **Version Control**: Git

---

## 📋 Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or higher
- [Node.js 18.x](https://nodejs.org/) or higher
- [PostgreSQL 14+](https://www.postgresql.org/download/)
- [Git](https://git-scm.com/downloads)
- A code editor (VS Code recommended)

### Verify Installations
```bash
# Check .NET version
dotnet --version

# Check Node.js version
node --version

# Check npm version
npm --version

# Check PostgreSQL
psql --version
```

---

## 🚀 Installation

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/medicore-erp.git
cd medicore-erp
```

### 2. Backend Setup
```bash
# Navigate to backend folder
cd MediCore.API

# Restore NuGet packages
dotnet restore

# Install Entity Framework tools (if not already installed)
dotnet tool install --global dotnet-ef
```

### 3. Frontend Setup
```bash
# Navigate to frontend folder (from root)
cd ../frontend

# Install npm packages
npm install
```

---

## 🗄️ Database Setup

### 1. Create PostgreSQL Database

Open **pgAdmin** or use **psql**:
```sql
CREATE DATABASE medicoredb;
```

### 2. Configure Connection String

Update `appsettings.json` in `MediCore.API` folder:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=medicoredb;Username=postgres;Password=YOUR_PASSWORD"
  }
}
```

**⚠️ Important**: Replace `YOUR_PASSWORD` with your PostgreSQL password.

### 3. Run Migrations
```bash
# From MediCore.API folder
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will create all necessary tables and seed initial data (2 doctors).

---

## ▶️ Running the Application

### Start Backend (Terminal 1)
```bash
# From MediCore.API folder
dotnet run
```

Backend will run on: `http://localhost:5099`

### Start Frontend (Terminal 2)
```bash
# From frontend folder
npm run dev
```

Frontend will run on: `http://localhost:5173`

### Access the Application

Open your browser and navigate to:
- **Frontend**: http://localhost:5173
- **Backend API**: http://localhost:5099
- **Swagger UI**: http://localhost:5099/swagger

---

## 📁 Project Structure
```
MediCore/
├── MediCore.API/                 # Backend API
│   ├── Controllers/              # API Controllers
│   │   ├── PatientsController.cs
│   │   ├── DoctorsController.cs
│   │   └── AppointmentsController.cs
│   ├── Models/                   # Domain Models
│   │   ├── Patient.cs
│   │   ├── Doctor.cs
│   │   └── Appointment.cs
│   ├── DTOs/                     # Data Transfer Objects
│   │   ├── PatientDto.cs
│   │   ├── DoctorDto.cs
│   │   └── AppointmentDto.cs
│   ├── Data/                     # Database Context
│   │   └── ApplicationDbContext.cs
│   ├── Program.cs                # Application Entry Point
│   ├── appsettings.json          # Configuration
│   └── MediCore.API.csproj       # Project File
│
└── frontend/                     # React Frontend
    ├── src/
    │   ├── components/           # React Components
    │   │   ├── Dashboard.jsx
    │   │   ├── Patients/
    │   │   │   ├── PatientList.jsx
    │   │   │   └── PatientForm.jsx
    │   │   ├── Doctors/
    │   │   │   ├── DoctorList.jsx
    │   │   │   └── DoctorForm.jsx
    │   │   └── Appointments/
    │   │       ├── AppointmentList.jsx
    │   │       └── AppointmentForm.jsx
    │   ├── services/             # API Services
    │   │   └── api.js
    │   ├── App.jsx               # Main App Component
    │   ├── App.css               # Styles
    │   └── main.jsx              # React Entry Point
    ├── package.json
    └── vite.config.js
```

---

## 🔌 API Endpoints

### Patients

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/patients` | Get all patients |
| GET | `/api/patients/{id}` | Get patient by ID |
| POST | `/api/patients` | Create new patient |
| PUT | `/api/patients/{id}` | Update patient |
| DELETE | `/api/patients/{id}` | Delete patient |

### Doctors

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/doctors` | Get all doctors |
| GET | `/api/doctors/{id}` | Get doctor by ID |
| POST | `/api/doctors` | Create new doctor |
| PUT | `/api/doctors/{id}` | Update doctor |
| DELETE | `/api/doctors/{id}` | Delete doctor |

### Appointments

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/appointments` | Get all appointments |
| GET | `/api/appointments/{id}` | Get appointment by ID |
| POST | `/api/appointments` | Create appointment |
| PATCH | `/api/appointments/{id}/status` | Update status |
| DELETE | `/api/appointments/{id}` | Delete appointment |
| GET | `/api/appointments/stats` | Get statistics |

### Example Request

**Create Patient:**
```json
POST /api/patients
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "dateOfBirth": "1990-05-15",
  "gender": "Male",
  "phone": "123-456-7890",
  "email": "john.doe@example.com",
  "address": "123 Main St, City, State"
}
```

**Create Appointment:**
```json
POST /api/appointments
Content-Type: application/json

{
  "patientId": 1,
  "doctorId": 1,
  "appointmentDate": "2024-12-10",
  "appointmentTime": "14:30",
  "notes": "Regular checkup"
}
```

---

## 📸 Screenshots

### Dashboard
```
┌──────────────────────────────────────────────────┐
│  🏥 MediCore Hospital ERP                        │
│  Hospital Management System                      │
│                                                  │
│  ┌──────────┐ ┌──────────┐ ┌──────────┐        │
│  │ 👥  42   │ │ 👨‍⚕️  12  │ │ 📅  128  │        │
│  │ Patients │ │ Doctors  │ │ Appts    │        │
│  └──────────┘ └──────────┘ └──────────┘        │
│                                                  │
│  Quick Actions:                                  │
│  [Manage Patients] [Manage Doctors] [View Appts]│
└──────────────────────────────────────────────────┘
```

### Patient Management
- Clean table view with all patient information
- Add/Edit/Delete functionality
- Form validation

### Appointment Scheduling
- Patient and doctor selection dropdowns
- Date and time pickers
- Status management (Scheduled/Completed/Cancelled)

---

## 🐛 Troubleshooting

### Common Issues

#### 1. **Database Connection Failed**

**Error**: `Could not connect to PostgreSQL`

**Solution**:
- Verify PostgreSQL is running
- Check connection string in `appsettings.json`
- Test with: `psql -U postgres`

#### 2. **CORS Error**

**Error**: `blocked by CORS policy`

**Solution**:
- Verify `Program.cs` has correct CORS configuration
- Check frontend URL matches allowed origins
- Default: `http://localhost:5173`

#### 3. **DateTime/Timezone Error**

**Error**: `Cannot write DateTime with Kind=Unspecified`

**Solution**: Already fixed with:
```csharp
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
```

#### 4. **Port Already in Use**

**Backend Error**: `Address already in use`

**Solution**:
```bash
# Windows
netstat -ano | findstr :5099
taskkill /PID <PID> /F

# Linux/Mac
lsof -ti:5099 | xargs kill -9
```

#### 5. **Migration Errors**

**Solution**:
```bash
# Reset database
dotnet ef database drop --force
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 🔧 Configuration

### Backend Configuration

**appsettings.json:**
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=medicoredb;Username=postgres;Password=yourpassword"
  }
}
```

### Frontend Configuration

**src/services/api.js:**
```javascript
const API_BASE_URL = 'http://localhost:5099/api';
```

Change this if your backend runs on a different port.

---

## 📊 Database Schema

### Patients Table
```sql
CREATE TABLE "Patients" (
    "Id" SERIAL PRIMARY KEY,
    "FirstName" VARCHAR(50) NOT NULL,
    "LastName" VARCHAR(50) NOT NULL,
    "DateOfBirth" TIMESTAMP NOT NULL,
    "Gender" VARCHAR(10),
    "Phone" VARCHAR(20),
    "Email" VARCHAR(100),
    "Address" TEXT,
    "CreatedAt" TIMESTAMP NOT NULL
);
```

### Doctors Table
```sql
CREATE TABLE "Doctors" (
    "Id" SERIAL PRIMARY KEY,
    "FirstName" VARCHAR(50) NOT NULL,
    "LastName" VARCHAR(50) NOT NULL,
    "Specialization" VARCHAR(100),
    "Phone" VARCHAR(20),
    "Email" VARCHAR(100),
    "CreatedAt" TIMESTAMP NOT NULL
);
```

### Appointments Table
```sql
CREATE TABLE "Appointments" (
    "Id" SERIAL PRIMARY KEY,
    "PatientId" INTEGER NOT NULL,
    "DoctorId" INTEGER NOT NULL,
    "AppointmentDate" TIMESTAMP NOT NULL,
    "AppointmentTime" VARCHAR(10) NOT NULL,
    "Status" VARCHAR(20) NOT NULL,
    "Notes" TEXT,
    "CreatedAt" TIMESTAMP NOT NULL,
    FOREIGN KEY ("PatientId") REFERENCES "Patients"("Id") ON DELETE CASCADE,
    FOREIGN KEY ("DoctorId") REFERENCES "Doctors"("Id") ON DELETE CASCADE
);
```

---

## 🎓 Learning Resources

This project demonstrates:

- **Backend**: RESTful API design, Entity Framework Core, PostgreSQL
- **Frontend**: React Hooks, Component Architecture, State Management
- **Full-Stack**: API Integration, CORS, Error Handling
- **Database**: Migrations, Relationships, Seeding

### Key Concepts Covered

1. **ASP.NET Core Web API**
   - Controllers and Actions
   - Dependency Injection
   - Async/Await patterns
   - Error handling

2. **Entity Framework Core**
   - Code-First approach
   - Migrations
   - LINQ queries
   - Relationships (One-to-Many)

3. **React**
   - Functional components
   - useState and useEffect hooks
   - Form handling
   - API integration

4. **PostgreSQL**
   - Database design
   - Foreign keys
   - Queries

---

## 🚧 Future Enhancements

- [ ] User authentication and authorization (JWT)
- [ ] Role-based access control (Admin, Doctor, Receptionist)
- [ ] Medical records management
- [ ] Prescription management
- [ ] Billing and invoicing
- [ ] Report generation (PDF)
- [ ] Email notifications
- [ ] SMS reminders
- [ ] Calendar view for appointments
- [ ] Search and filtering
- [ ] Pagination
- [ ] Dark mode
- [ ] Multi-language support

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Author

**Your Name**
- GitHub: [@Sayeed-titan](https://github.com/Sayeed-titan)
- Email: your.email@example.com

---

## 🙏 Acknowledgments

- Built with guidance from Claude AI
- Inspired by real-world hospital management systems
- Thanks to the open-source community

---

## 📞 Support

For support, email your.email@example.com or open an issue on GitHub.

---

## 🌟 Star This Repository

If you found this project helpful, please consider giving it a ⭐!

---

**Happy Coding! 🚀**

---

*Last Updated: December 2024*