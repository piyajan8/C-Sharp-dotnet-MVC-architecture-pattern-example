# 🍜 เกมหาของกิน (Food Quiz Game)

## 🛠️เทคโนโลยีที่ใช้

- **Backend**: ASP.NET Core 8.0 MVC
- **Database**: Entity Framework Core with In-Memory Database
- **Frontend**: Razor Views + Tailwind CSS
- **Language**: C# with .NET 8.0

## 🚀 วิธีการรัน

### Prerequisites
- .NET 8.0 SDK

### การติดตั้งและรัน

1. **Clone โปรเจกต์**
   ```bash
   git clone <repository-url>
   cd FoodQuizGame
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore FoodQuizGame
   ```

3. **Build โปรเจกต์**
   ```bash
   dotnet build FoodQuizGame
   ```

4. **รันแอปพลิเคชัน**
   ```bash
   dotnet run --project FoodQuizGame
   ```

5. **เปิดเบราว์เซอร์**
   - ไปที่ `https://localhost:5001` หรือ `http://localhost:5000`
   - หรือดูใน Terminal สำหรับ URL ที่แสดง

### Development Mode (Auto-reload)
```bash
dotnet watch --project FoodQuizGame
```

## 🎮 วิธีเล่น

1. **หน้าเริ่มเกม**: ใส่ชื่อ (หรือไม่ใส่ก็ได้) แล้วกดเริ่มเกม
2. **หน้าเล่นเกม**: ตอบคำถาม 5 ข้อ โดยเลือกตัวเลือกที่ถูกต้อง
   - ✅ **ตอบถูก**: ได้คะแนน + ไปคำถามถัดไป
   - ❌ **ตอบผิด**: ไม่ได้คะแนน แต่ไปคำถามถัดไปได้เลย
3. **หน้าผลลัพธ์**: ดูคะแนนและข้อความกำลังใจ พร้อมเล่นใหม่ได้

## 📊 คำถามในเกม

1. 🍛 อาหารไทยที่มีกะทิ น้ำตาล และเครื่องเทศ
2. 👑 ผลไม้ "ราชาแห่งผลไม้"
3. 🍮 ของหวานไทยจากไข่แดงและน้ำตาล
4. 🍕 อาหารจานด่วนจากอิตาลี
5. 🍵 เครื่องดื่มจากการหมักใบชา

## 🏗️ โครงสร้างโปรเจกต์

```
FoodQuizGame/
├── Controllers/
│   └── GameController.cs          # Logic ควบคุมเกม
├── Models/
│   ├── Question.cs                # โมเดลคำถาม
│   ├── GameSession.cs             # โมเดลเซสชันเกม
│   └── ViewModels/                # ViewModels สำหรับ Views
├── Views/
│   └── Game/
│       ├── Start.cshtml           # หน้าเริ่มเกม
│       ├── Play.cshtml            # หน้าเล่นเกม
│       └── Result.cshtml          # หน้าผลลัพธ์
├── Data/
│   └── ApplicationDbContext.cs    # Database Context + Seed Data
└── Program.cs                     # Configuration
```