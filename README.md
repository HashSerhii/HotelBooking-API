# HotelBooking API

![.NET 8](https://img.shields.io/badge/.NET%208.0-512BD4?style=flat&logo=dotnet)
![License](https://img.shields.io/badge/license-MIT-blue)

A robust RESTful API for a hotel booking management system. Built with **.NET 8** using **Clean Architecture** principles and **CQRS** pattern.

## Features

### Authentication & Security
* **JWT Authentication:** Secure access using JSON Web Tokens.
* **RBAC:** Role-Based Access Control (`Admin` and `User` roles).

### Hotel Management
* **Search:** Filter hotels by Name or City.
* **CRUD Operations:** Full control over hotel profiles.
* **Statistics:** View hotel capacity statistics.

### Rooms & Bookings
* **Inventory:** Dynamic room management.
* **Booking Logic:** Prevents double-booking for overlapping dates.
* **History:** Users can view their past and upcoming bookings.

### Reviews
* **Feedback System:** Authenticated users can leave ratings and reviews.

---

## Tech Stack & Architecture

* **Framework:** .NET 8 (ASP.NET Core Minimal APIs)
* **Architecture:** Clean Architecture
* **Pattern:** CQRS (using MediatR)
* **Data Access:** Entity Framework Core
* **Database:** SQL Server / PostgreSQL
* **Documentation:** Swagger UI / OpenAPI

---

## Getting Started

1.  **Clone the repository**
    ```bash
    git clone [https://github.com/HashSerhii/HotelBooking-API.git](https://github.com/HashSerhii/HotelBooking-API.git)
    ```

2.  **Configure Database**
    Update your connection string in `appsettings.json`.

3.  **Run Migrations & Start**
    ```bash
    dotnet ef database update --project HotelBooking.Infrastructure --startup-project HotelBooking.Api
    dotnet run --project HotelBooking.Api
    ```

---
*Developed as a portfolio project demonstrating modern .NET best practices.*