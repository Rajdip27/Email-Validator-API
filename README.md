# 📗 Email Validator API

A powerful ASP.NET Core API to validate email addresses in real-time using:

* ✅ RFC 5322 format validation
* ✅ DNS/MX record check
* ✅ Disposable domain detection (100K+ domains)
* ✅ Blacklisted domain validation
* ✅ Typos and domain suggestions
* ✅ Fully documented with Swagger and ReDoc
* ✅ No external API calls or dependencies

---

## 🚀 Getting Started

### 🔧 Prerequisites

* [.NET 7/8/9 SDK](https://dotnet.microsoft.com/)
* Visual Studio 2022+ or VS Code

---

### 🛠️ Installation

1. Clone the repository

```bash
git clone https://github.com/Rajdip27/Email-Validator-API
cd email-validator-api
```

2. Restore packages

```bash
dotnet restore
```

3. Run the API

```bash
dotnet run
```

---

## 📂 Project Structure

| Folder / File            | Description                                      |
| ------------------------ | ------------------------------------------------ |
| `Controllers/`           | API controller (`EmailValidatorController`)      |
| `Services/`              | Core validation logic (`EmailValidationService`) |
| `Models/`                | Input/output DTOs                                |
| `Helpers/`               | Helper classes for validation                    |
| `Program.cs`             | Middleware + Swagger + ReDoc setup               |
| `disposable_domains.txt` | List of disposable email domains                 |

---

## 🔗 API Endpoints

### `GET /api/EmailValidator/validate?email=example@example.com`

#### ✅ Input:

| Parameter | Type   | Required | Description       |
| --------- | ------ | -------- | ----------------- |
| `email`   | string | ✅ Yes    | Email to validate |

#### 📤 Sample Output (Valid Email):

```json
{
  "isValid": true,
  "isDisposable": false,
  "hasMxRecord": true,
  "isFormatValid": true,
  "isDomainValid": true,
  "errorMessage": null,
  "warnings": [],
  "didYouMean": null,
  "domain": "gmail.com",
  "validatedAt": "2025-08-03T04:26:24.1082346Z"
}
```

#### ❌ Sample Output (Invalid Email):

```json
{
  "isValid": false,
  "isDisposable": false,
  "hasMxRecord": false,
  "isFormatValid": false,
  "isDomainValid": false,
  "errorMessage": "Invalid email format",
  "warnings": [],
  "didYouMean": null,
  "domain": null,
  "validatedAt": "2025-08-03T04:26:24.1082346Z"
}
```

---

## 📜 API Documentation

### ✅ Swagger UI

* URL: [https://localhost:{port}/swagger](https://localhost:{port}/swagger)
* Usage: Interactive UI to test API with live input/output

### ✅ ReDoc UI (Default)

* URL: [https://localhost:{port}/](https://localhost:{port}/)
* Usage: Clean, modern API documentation format

---

## 🛡️ Security

* Built without external API calls for validation
* No user data is logged or stored
* Rate-limiting can be added easily with `AspNetCoreRateLimit` or middleware

---

## ✅ To Do (Optional Enhancements)

* [ ] Rate limiting with IP throttling
* [ ] Logging to file or DB
* [ ] Docker support
* [ ] Integration with Mailgun/SendGrid for SMTP verification
* [ ] CI/CD GitHub Actions for automated testing

---

## 📄 License

MIT License

---

## 👨‍💻 Author

Developed by \[Santanu Chandra]
Email: [srajdip920@gmail.com](mailto:srajdip920@gmail.com)
