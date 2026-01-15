🏢 Employee Management System (EMS)
- A robust, scalable web application built with ASP.NET Core MVC using a strict 3-Tier Architecture. Designed to demonstrate enterprise-level patterns, clean code principles, and localization support.

📖 Overview
- This project is an Employee and Department management system that goes beyond simple CRUD. It focuses on separation of concerns by decoupling the Data Access Layer (DAL), Business Logic Layer (BLL), and Presentation Layer (PL). It features advanced concepts like Soft Delete, Global Query Filters, and Dynamic Localization (English/Arabic).

🏗️ Architecture
- The solution is divided into three distinct layers to ensure maintainability and testability:

1. DAL (Data Access Layer)
- Responsibility: Direct interaction with the database.

2. BLL (Business Logic Layer)
- Responsibility: Data processing, validation, and mapping.

3. PL (Presentation Layer)
- Responsibility: User Interface and Localization.

✨ Key Features
🌍 Globalization & Localization:

- Supports multi-language UI (English & Arabic).

- Automatically switches layout direction (LTR/RTL) based on culture.

- Cookie-based culture persistence.

🗑️ Soft Delete System:

- Entities are never physically deleted from the database.

- "Deleted" items are automatically filtered out of queries unless specifically requested.

🖼️ Image Handling:

- Secure file upload system for employee profile photos.

- Automatic cleanup of old images upon update or hard delete.

🛡️ Validation:

- Client-side validation (jQuery Unobtrusive).

- Server-side validation (Data Annotations & Custom Logic).

🛠️ Technology Stack
- Framework: .NET Core 8.0 (MVC)

- ORM: Entity Framework Core

- Database: SQL Server (Configured for In-Memory for dev/testing)

- Frontend: HTML5, CSS3, Bootstrap 5, Razor

- Tools: AutoMapper, Dependency Injection (DI)

🚀 Getting Started
Clone the repository

- git clone https://github.com/YourUsername/EmployeeManagementSystem.git
- Open the Solution Open Tiers.sln in Visual Studio 2022.

Restore Dependencies Visual Studio should do this automatically, or run:
- dotnet restore

Run the Application Press F5 or run:
- dotnet run --project Tiers.PL

Note: The project currently uses an In-Memory database for ease of demonstration. No SQL setup is required.

📸 Showcase
<video src="https://github.com/user-attachments/assets/4aed6c90-d76c-4103-befd-45892684a7fe" controls></video>

👨‍💻 Author
- Fady Tawadrous Ayoub

Role: Full Stack .NET Developer

Focus: Building scalable, clean, and maintainable web applications.
