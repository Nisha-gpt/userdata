# UserData C# Console Application

This is a console-based C# project demonstrating reading and writing user data using:
- JSON files
- XML files
- Class inheritance (`Admin`, `RegularUser`)
- Console I/O
- Newtonsoft.Json package for serialization/deserialization

---

## 📌 GitHub Repository

🔗 [https://github.com/Nisha-gpt/userdata]

---

## ✅ Version History

### 🔹 V1: Initial Setup
- Created console project with folder structure
- Added base model classes: `User`, `ContactDetails`
- Added initial `users.json` with sample data

### 🔹 V2: XML Reader
- Created `sample.xml`
- Used `XmlDocument` to read and display user info from XML

### 🔹 V3: Add User via Console
- Prompted user to input Name, Age, City, Nationality, Phone, Email
- Created `User` object and added it to `users.json`

### 🔹 V4: Display Users from JSON
- Read and deserialized the full `users.json`
- Displayed each user's info using a loop

### 🔹 V5: Inheritance with Admin & RegularUser
- Created `Admin` and `RegularUser` classes inheriting from `User`
- Created `users_extended.json` including a `UserType` field
- Used conditional deserialization to read based on type
- Displayed Admin and RegularUser data accordingly

---

## 🧪 Technologies Used

- C# (.NET 9 )
- Newtonsoft.Json
- System.Xml
- Git + GitHub for version control
- Windows 11 & Terminal

---

## 📝 Done by

Nisha Murali  
