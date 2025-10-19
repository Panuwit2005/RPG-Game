using System;
using UnityEngine;

public class Person : MonoBehaviour
{
    // C# จะสร้าง private field ชื่อ backing field ให้โดยอัตโนมัติ
    //1. Auto-Implemented Property
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    //2. Full Property (รูปแบบเต็ม) เป็นรูปแบบที่สมบูรณ์ที่สุด เหมาะสำหรับเมื่อคุณต้องการควบคุมการเข้าถึงข้อมูลอย่างละเอียด
    
    private int _heartRate;
    public int HeartRate
    {
        get
        {
            return _heartRate;
        }
        set
        {
            if (value >= 40 && value <= 250)
            {
                Debug.Log($"HeartRate is set to {value}");
                _heartRate = value;
            }
            else
            {
                Debug.Log($"HeartRate should be 40 - 250");
            }
        }
    }

    //3. Property แบบ Read-Only (อ่านได้อย่างเดียว)
    //วิธีที่ 1: ใช้ public get; private set;
    public string IdCardNumber { get; private set; }
    //วิธีที่ 2: ใช้ public get; อย่างเดียว
    public DateTime BirthDay { get;}

    public int Age
    {
        get
        {
            int _age = DateTime.Today.Year - BirthDay.Year;
            return _age;
        }
    }
    public float weightInKG;
    public float heightInMeters;
    public float Bmi => weightInKG / (heightInMeters * heightInMeters);

    public Person(string idCardNumver, DateTime birthDay)
    {
        IdCardNumber = idCardNumver;
        BirthDay = birthDay;
    }

    //4. Property แบบ Write-Only (เขียนได้อย่างเดียว)
    private string _password;
    public string Password
    {
        set
        {
            if(value.Length >= 8)
            {
                _password = value;
                Debug.Log($"Change Password Successfully!");
            }
            else
            {
                Debug.LogWarning("Password must be at least 8 characters long!!");
            }
        }
    }

    //5. Protected Property (สำหรับคลาสที่สืบทอดเท่านั้น)
    private string _employeeId;
    public string EmployeeId
    {
        get
        {
            return _employeeId;
        }
        protected set
        {
            _employeeId = value;
        }
    } 
}
