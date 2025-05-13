# 📚 MongoExample

A simple ASP.NET Core Web API project using **MongoDB** (running in Docker) to demonstrate basic **CRUD operations** on a `Book` collection.

---

## 🚀 Technologies

- [.NET 8 Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [MongoDB](https://www.mongodb.com/)
- [MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver/)
- [Docker](https://www.docker.com/)
- [Mongo Express (optional)](https://hub.docker.com/_/mongo-express)

---

## 🐳 Run MongoDB in Docker

```bash
docker run -d -p 27017:27017 --name mongo-db mongo

## 🔧 Configuration
## Update appsettings.json:
"MongoDB": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "BookDb",
  "CollectionName": "Books"
}


## 📁 Project Structure
MongoExample/
├── Controllers/
│   └── BookController.cs
├── Models/
│   └── Book.cs
├── Services/
│   └── BookService.cs
├── Program.cs
└── appsettings.json


## 📡 API Endpoints
| Method | Endpoint         | Description      |
| ------ | ---------------- | ---------------- |
| GET    | `/api/book`      | Get all books    |
| GET    | `/api/book/{id}` | Get a book by ID |
| POST   | `/api/book`      | Add a new book   |
| PUT    | `/api/book/{id}` | Update a book    |
| DELETE | `/api/book/{id}` | Delete a book    |

