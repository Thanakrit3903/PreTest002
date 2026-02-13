CREATE TABLE Members (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(100) UNIQUE NOT NULL,
    PasswordHash TEXT NOT NULL, -- เก็บข้อมูลที่เข้ารหัสแล้ว 
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);