โปรเจคทดสอบตำแหน่ง Full-stack Developer (Angular + .NET + PostgreSQL)

## 🛠 Tech Stack
- **Frontend:** Angular 21+
- **Backend:** .NET Core / Web API (version 8)
- **Database:** PostgreSQL

## 🚀 How to Run

### 1. Database Setup
- ใช้ไฟล์ในโฟลเดอร์ `/DB/User.sql` เพื่อสร้าง Table และข้อมูลเริ่มต้นใน PostgreSQL

### 2. Backend Setup
- เข้าไปที่โฟลเดอร์ `backEnd`
- แก้ไข Connection String ใน `appsettings.json` ให้ตรงกับฐานข้อมูลของคุณ
- รันคำสั่ง `dotnet run` หรือ ปุ่ม start run
**Swagger
`http://localhost:5000`

### 3. Frontend Setup
- เข้าไปที่โฟลเดอร์ `frontEnd`
- รันคำสั่ง `npm install` เพื่อติดตั้ง dependencies
- รันคำสั่ง `ng serve` และเปิดเบราว์เซอร์ไปที่ `http://localhost:4200`
