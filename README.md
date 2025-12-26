# 🍳 Cooking Assistant

An AI-powered cooking assistant that helps you manage your pantry and suggests recipes based on what you have.

## Features

- ✅ Pantry Management (add, update, delete items)
- ✅ Track expiration dates
- ✅ Get alerts for expiring items
- 🚧 AI Chat for recipe suggestions (coming soon)
- 🚧 React Frontend (coming soon)
- 🚧 Webhooks & Notifications (coming soon)

## Tech Stack

- **Backend**: .NET 8 Web API
- **Database**: SQLite with Entity Framework Core
- **Frontend**: React (coming soon)
- **AI**: OpenAI API (coming soon)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Run Locally

```bash
cd src/CookingAssistant.API
dotnet run
```

Open Swagger: `http://localhost:5000/swagger`

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/pantry` | Get all pantry items |
| GET | `/api/pantry/expiring` | Get items expiring soon |
| POST | `/api/pantry` | Add a new item |
| PUT | `/api/pantry/{id}` | Update an item |
| DELETE | `/api/pantry/{id}` | Delete an item |

## Project Structure

```
├── src/
│   ├── CookingAssistant.API/          # Web API
│   ├── CookingAssistant.Core/         # Domain models, DTOs
│   └── CookingAssistant.Infrastructure/ # Database, services
└── README.md
```

## License

MIT
