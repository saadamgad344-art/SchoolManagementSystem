# 🏫 School Management System API

A RESTful Web API for managing school operations including students, teachers, grades, and schools.
Built with **ASP.NET Core** and secured with **JWT Authentication**.

---

## 📡 API Endpoints

### Auth
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Auth/register` | Register new user |
| POST | `/api/Auth/login` | Login & get JWT token |

### Students
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Students` | Get all students |
| POST | `/api/Students` | Add new student |
| GET | `/api/Students/{id}` | Get student by ID |
| PUT | `/api/Students/{id}` | Update student |
| DELETE | `/api/Students/{id}` | Delete student |

### Teachers
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Teachers` | Get all teachers |
| POST | `/api/Teachers` | Add new teacher |
| GET | `/api/Teachers/{id}` | Get teacher by ID |
| PUT | `/api/Teachers/{id}` | Update teacher |
| DELETE | `/api/Teachers/{id}` | Delete teacher |

### Schools
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Schools` | Get all schools |
| POST | `/api/Schools` | Add new school |
| GET | `/api/Schools/{id}` | Get school by ID |
| PUT | `/api/Schools/{id}` | Update school |
| DELETE | `/api/Schools/{id}` | Delete school |

### Grades
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Grades` | Get all grades |
| POST | `/api/Grades` | Add new grade |
| GET | `/api/Grades/{id}` | Get grade by ID |
| PUT | `/api/Grades/{id}` | Update grade |
| DELETE | `/api/Grades/{id}` | Delete grade |

---

## 🛠️ Tech Stack

| Technology | Purpose |
|------------|---------|
| ASP.NET Core Web API | REST API & routing |
| Entity Framework Core | ORM & database operations |
| SQL Server | Data persistence |
| JWT Authentication | Secure endpoints |
| Swagger / Swashbuckle | API documentation |

---

## 📸 API Documentation (Swagger)

![Swagger Auth & Grades](./screenshots/swagger_1.png)
![Swagger Schools & Students](./screenshots/swagger_2.png)
![Swagger Students & Teachers](./screenshots/swagger_3.png)

---

## ⚙️ Getting Started

### Prerequisites
- .NET 6+ SDK
- SQL Server
- Postman (for testing)

### Setup
```bash
# Update connection string in appsettings.json
dotnet ef database update
dotnet run
# API: https://localhost:7000
# Swagger UI: https://localhost:7000/swagger
```

---

## 👤 Author

**Amgad Saad** — Full Stack .NET Developer | Riyadh, Saudi Arabia 🇸🇦

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0A66C2?style=flat&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/amgad-saad-a1a2a531a/)
[![GitHub](https://img.shields.io/badge/GitHub-181717?style=flat&logo=github&logoColor=white)](https://github.com/saadamgad344-art)
