# 📊 Workforce Analytics Dashboard

[![Live Demo](https://img.shields.io/badge/Live-Dashboard-blue?logo=azure-devops&logoColor=white)](https://workforce-analytics-web-bqguhmaxdtbycwfd.canadacentral-01.azurewebsites.net/)
[![GitHub](https://img.shields.io/badge/Repo-GitHub-green?logo=github)](https://github.com/adampodolak/workforce-analytics-dashboard)
[![Project Board](https://img.shields.io/badge/SDLC-Project%20Board-yellow?logo=github)](https://github.com/users/adampodolak/projects/5)

![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?logo=bootstrap&logoColor=white)
![Chart.js](https://img.shields.io/badge/chart.js-F5788D.svg?logo=chart.js&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework_Core-512BD4?logo=dotnet&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-336791?logo=postgresql&logoColor=white)
![Visual Studio 2022](https://img.shields.io/badge/Visual_Studio-5C2D91?logo=visualstudio&logoColor=white)
![Git](https://img.shields.io/badge/Git-F05032?logo=git&logoColor=white)
![Azure](https://img.shields.io/badge/azure-%230072C6.svg?logo=microsoftazure&logoColor=white)



---

### 🚀 Summary

The **Workforce Analytics Dashboard** is a fully responsive, cloud-hosted analytics platform that enables organizations to monitor, analyze, and optimize their workforce data through interactive KPIs, visualizations, and CRUD (create, read, update, delete) operations. This full-stack project was built to demonstrate my applied skills in software engineering, cloud deployment, multi-tier architecture, and modern development lifecycles. **Fully deployed and accessible live via Azure App Services.**

---

### 🛠 Tech Stack

| Layer              | Tech Used |
|--------------------|-----------|
| **Frontend**       | ASP.NET Core MVC, Bootstrap 5 |
| **Backend**        | ASP.NET Core 8 ( C# ), Entity Framework Core |
| **Database**       | PostgreSQL (Hosted on Railway) |
| **Hosting**        | Azure App Service |
| **DevOps**         | Azure DevOps, GitHub Projects |
| **Deployment**     | CI/CD Pipeline via GitHub Actions |
| **Version Control**| Git, GitHub |
| **Architecture**   | Classic 3-Tier MVC (Model/View/Controller) |

---

### 🎯 Key Features

✅ Full CRUD operations for employee management  
✅ KPI dashboards with calculated business metrics (e.g. turnover rate, tenure, average salary)  
✅ Dynamic filtering, sorting, and XML exporting  
✅ Responsive UI for mobile & desktop  
✅ Live production deployment on Azure with CI/CD pipelines
✅ Full SDLC project board for transparent software lifecycle management  
✅ PostgreSQL relational database integration  
✅ Modular and scalable backend API structure

---

### 📈 Live Demo

🌐 **[Access the Live Dashboard here](https://workforce-analytics-web-bqguhmaxdtbycwfd.canadacentral-01.azurewebsites.net/)**  
Fully functional live version with CRUD functionality enabled for demo purposes.

---

### 🗂️ Full Project Board (SDLC)

📅 **[View full project development board on GitHub Projects](https://github.com/users/adampodolak/projects/5)**  
Includes all tracked SDLC phases:

---

### 🏗️ Architecture Diagram

The application follows a classic 3-tier MVC architecture, fully deployed in the cloud:

TODO

---

### 🖥️ Installation & Local Development

> Clone, build, and run the project locally to explore the full source code.

#### ⚙️ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (with ASP.NET & web development workload)
- PostgreSQL (local instance or cloud-hosted)
- [Railway](https://railway.app/) account (optional for managed DB)

#### 🔧 Clone Repository

```bash
git clone https://github.com/adampodolak/workforce-analytics-dashboard.git
```

```Bash
cd workforce-analytics-dashboard
```

🔑 Configure Database Connection
1️⃣ Create a local or cloud PostgreSQL database.
2️⃣ Update the connection string inside appsettings.json:

```Bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=your_host;Port=5432;Database=your_db;Username=your_user;Password=your_password"
  }
}
```

For production deployment, connection strings are injected via Azure App Service configurations.

🏗️ Apply EF Core Migrations
```bash
dotnet ef database update
```
(Ensure EF Core tools are installed: dotnet tool install --global dotnet-ef)

🚀 Run the Application
```bash
dotnet run
```

The app will launch at: https://localhost:5001/

---

This project demonstrates hands-on experience with full-stack .NET development, cloud deployment pipelines, SQL database design, and practical application of SDLC methodologies.

