# Grand Hotel Management System (HMS)

A full-featured Hotel Management System built with **C# .NET 10 WinForms** and **SQLite** database.
No .NET runtime installation required — the app is self-contained.

---

## Features

| Module | Description |
|---|---|
| **Login** | Secure login with BCrypt hashed passwords |
| **Dashboard** | Live stats: available rooms, occupied, check-ins, revenue |
| **Room Management** | Add / edit / delete rooms with type, floor, price, capacity, status |
| **Customer Details** | Full customer records with CNIC, phone, nationality, search |
| **Booking Management** | Create / update / cancel bookings with auto price calculation |
| **Check In / Check Out** | Tab view of reserved & active guests, one-click check-in/out |
| **Billing** | Generate itemised bills with tax, discount, payment method, print |
| **User Management** | Admin-only: manage staff accounts and roles |

---

## Default Login

| Field | Value |
|---|---|
| Username | `admin` |
| Password | `admin123` |

---

## Project Structure

```
HMS/
├── HMS.sln
└── HMS/
    ├── Program.cs
    ├── GlobalUsings.cs
    ├── HMS.csproj
    ├── Database/
    │   ├── hotel.sqlite          ← auto-created on first run
    │   ├── DbConnection.cs
    │   ├── DbInitializer.cs
    │   ├── BaseRepository.cs
    │   ├── UserRepository.cs
    │   ├── RoomRepository.cs
    │   ├── CustomerRepository.cs
    │   ├── BookingRepository.cs
    │   └── BillRepository.cs
    ├── Models/
    │   ├── User.cs
    │   ├── Room.cs
    │   ├── Customer.cs
    │   ├── Booking.cs
    │   └── Bill.cs
    └── Forms/
        ├── LoginForm.cs / .Designer.cs / .resx
        ├── MainForm.cs / .Designer.cs / .resx
        ├── RoomManagementForm.cs / .Designer.cs / .resx
        ├── CustomerForm.cs / .Designer.cs / .resx
        ├── BookingForm.cs / .Designer.cs / .resx
        ├── CheckInOutForm.cs / .Designer.cs / .resx
        ├── BillingForm.cs / .Designer.cs / .resx
        └── UserManagementForm.cs / .Designer.cs / .resx
```

---

## How to Open in Visual Studio

1. Open **Visual Studio 2022** (or later)
2. Click **File → Open → Project/Solution**
3. Select `HMS.sln`
4. Press **F5** to build and run

> NuGet packages will restore automatically:
> - `BCrypt.Net-Next` – password hashing
> - `System.Data.SQLite.Core` – embedded SQLite database

---

## How to Publish (Self-Contained EXE – No .NET Required)

Open **Package Manager Console** or a terminal inside the project folder and run:

```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

The output EXE in `bin\Release\net10.0-windows\win-x64\publish\` runs on any Windows PC **without** .NET installed.

---

## Database

- SQLite database at `Database\hotel.sqlite` (auto-created on first run)
- Pre-seeded with 9 sample rooms across 4 floors
- Default admin account created automatically
- No external database server needed

---

## Room Types & Pricing (Default)

| Type | Price/Night |
|---|---|
| Standard | Rs. 3,500 |
| Deluxe | Rs. 6,000 – 6,500 |
| Suite | Rs. 12,000 – 15,000 |
| Presidential Suite | Rs. 25,000 |

---

## Workflow

1. **Login** → Dashboard
2. **Add Rooms** → Room Management
3. **Add Customers** → Customer Details
4. **Create Booking** → Bookings (select customer + room + dates)
5. **Check In Guest** → Check In / Check Out → Reserved tab → select → Check In
6. **Check Out Guest** → Check In / Check Out → Checked-In tab → select → Check Out
7. **Generate Bill** → Billing → select booking → fill charges → Generate Bill
