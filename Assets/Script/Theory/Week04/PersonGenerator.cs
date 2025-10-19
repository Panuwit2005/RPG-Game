using System;
using UnityEngine;

public class PersonGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("--- Creating a new Person object ---");
        // สร้าง Object ของ Person โดยใช้ constructor
        // ต้องใส่ค่า IdCardNumber และ HeightInMeters เข้าไป
        DateTime date = new DateTime(1896, 4,12);
        Person p1 = new Person("3100804153", date);
        // 1. Auto-Implemented Property: FirstName, LastName
        // ตั้งค่าชื่อและนามสกุล

        p1.FirstName = "Sax";
        p1.LastName = "Zofone";
        Debug.Log($"Full name of P1 : {p1.FirstName} {p1.LastName}");

        Debug.Log("--- Setting Properties ---");
        // 2. Full Property: HeartRate
        // ตั้งค่าอายุที่ถูกต้อง
        p1.HeartRate = 80;
        Debug.Log($"Current HeartRate : {p1.HeartRate}");
        // ลองตั้งค่าอายุที่ผิดพลาด (จะแสดงข้อความเตือน)
        p1.HeartRate = 20;
        Debug.Log($"Current HeartRate : {p1.HeartRate}");
        // 3. Read-Only Properties: IdCardNumber, HeightInMeters, Bmi
        // IdCardNumber และ HeightInMeters ถูกตั้งค่าตอนสร้าง Object แล้ว
        Debug.Log($"ID Card Number : {p1.IdCardNumber}");
        Debug.Log($"Age : {p1.Age}");

        // กำหนดค่า WeightInKg เพื่อให้ Bmi คำนวณได้
        p1.weightInKG = 68;
        p1.heightInMeters = 1.75f;
        // Bmi เป็น Read-Only และคำนวณจากค่า Weight และ Height
        Debug.Log($"Bmi : {p1.Bmi:F2}");
        // ลองพยายามแก้ไขค่า Read-Only (จะเกิด Compile Error)
        //p1.IdCardNumber = "9999999999999"; // ERROR!
        //p1.HeightInMeters = 1.80; // ERROR!

        // 4. Write-Only Property: Password
        // ตั้งค่ารหัสผ่านที่ถูกต้อง (ความยาว 8 ตัวอักษรขึ้นไป)
        p1.Password = "5tr0n9_p455w0rd";
        // ลองตั้งค่ารหัสผ่านที่สั้นเกินไป
        p1.Password = "123321";
        // ลองพยายามอ่านค่ารหัสผ่านกลับมา (จะเกิด Compile Error)
        // string password = p1.Password; // ERROR!
    }
}
