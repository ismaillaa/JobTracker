# JobTracker API

A REST API for tracking job applications, built with ASP.NET Core, Entity Framework Core, PostgreSQL, and Docker.

## Tech Stack

- **ASP.NET Core 10** — Web API framework
- **Entity Framework Core** — ORM for database access
- **PostgreSQL** — Relational database
- **JWT Authentication** — Secure token-based auth
- **Clean Architecture** — Controllers, Services, DTOs, Models

## Features

- User registration and login with JWT tokens
- Create, read, and delete job applications
- Protected endpoints — authentication required
- Password hashing with BCrypt

## Project Structure

```
JobTracker/
├── Controllers/    # HTTP endpoints — thin, no business logic
├── Services/       # Business logic and database operations
├── Models/         # EF Core entities — map to database tables
├── DTOs/           # Request and response shapes
└── Data/           # DbContext — database session
```

## Getting Started

### Prerequisites

- .NET 10 SDK
- PostgreSQL
- Git

### Setup

1. Clone the repository

```
git clone https://github.com/ismaillaa/JobTracker.git
cd JobTracker
```

2. Create a PostgreSQL database named `jobtracker`

3. Create `appsettings.Development.json` with your credentials

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=jobtracker;Username=postgres;Password=YOUR_PASSWORD"
  },
  "Jwt": {
    "Key": "your-secret-key-minimum-32-characters"
  }
}
```

4. Run migrations

```
dotnet ef database update
```

5. Start the API

```
dotnet run
```

## API Endpoints

### Auth

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | /api/auth/register | Create account |
| POST | /api/auth/login | Login and get JWT token |

### Jobs (requires JWT)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/jobs | Get all job applications |
| GET | /api/jobs/{id} | Get single job application |
| POST | /api/jobs | Create job application |
| DELETE | /api/jobs/{id} | Delete job application |

## Usage Example

**Register**

```json
POST /api/auth/register
{
  "email": "user@example.com",
  "password": "yourpassword"
}
```

**Login**

```json
POST /api/auth/login
{
  "email": "user@example.com",
  "password": "yourpassword"
}
```

**Create a job application**

```json
POST /api/jobs
Authorization: Bearer YOUR_JWT_TOKEN

{
  "company": "Google",
  "position": "Backend Developer",
  "status": "Applied",
  "notes": "Dream job"
}
```

**Get all job applications**

```
GET /api/jobs
Authorization: Bearer YOUR_JWT_TOKEN
```

## Author

**Ismail Laaouan** — Computer Engineering Student at ENIAD Berkane  
[LinkedIn](https://www.linkedin.com/in/ismail-laaouan) · [GitHub](https://github.com/ismaillaa)