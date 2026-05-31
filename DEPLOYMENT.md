\# Hotel Management System — Deployment Guide



\## System Requirements

\- OS: Windows 10 / Windows 11 (64-bit)

\- RAM: Minimum 4 GB

\- Storage: 500 MB free disk space

\- .NET 10 Runtime (or use self-contained EXE)



\## Step-by-Step Installation



\### Step 1 — Extract the Project

1\. Download the ZIP file

2\. Extract it to any folder on your machine

&#x20;  Example: C:\\Users\\YourName\\Desktop\\HMS



\### Step 2 — Install .NET Runtime

1\. Go to https://dotnet.microsoft.com/download

2\. Download .NET 10 Runtime

3\. Run the installer and follow the instructions



\### Step 3 — Run the Application

1\. Open the extracted folder

2\. Double-click HMS.exe

3\. The application will start automatically



\## Database Setup

\- No manual database setup is required

\- On first launch, the application automatically

&#x20; creates the hotel.sqlite database file

\- 9 sample rooms and a default admin account

&#x20; are seeded automatically on first run



\## Default Login Credentials

| Field    | Value    |

|----------|----------|

| Username | admin    |

| Password | admin123 |



\## Database Migration

\- The hotel.sqlite file is already included

&#x20; in the project folder

\- To deploy on another machine, simply copy

&#x20; the entire project folder



\## Troubleshooting

\- If the application does not open, install

&#x20; .NET 10 Runtime from the link above

\- If a database error occurs, delete the

&#x20; hotel.sqlite file — the application will

&#x20; recreate it automatically on next launch

