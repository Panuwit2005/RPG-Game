using System;
using UnityEngine;

public class PersonGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("--- Creating a new Person object ---");
        // ���ҧ Object �ͧ Person ���� constructor
        // ��ͧ����� IdCardNumber ��� HeightInMeters ����
        DateTime date = new DateTime(1896, 4,12);
        Person p1 = new Person("3100804153", date);
        // 1. Auto-Implemented Property: FirstName, LastName
        // ��駤�Ҫ�����й��ʡ��

        p1.FirstName = "Sax";
        p1.LastName = "Zofone";
        Debug.Log($"Full name of P1 : {p1.FirstName} {p1.LastName}");

        Debug.Log("--- Setting Properties ---");
        // 2. Full Property: HeartRate
        // ��駤�����ط��١��ͧ
        p1.HeartRate = 80;
        Debug.Log($"Current HeartRate : {p1.HeartRate}");
        // �ͧ��駤�����ط��Դ��Ҵ (���ʴ���ͤ�����͹)
        p1.HeartRate = 20;
        Debug.Log($"Current HeartRate : {p1.HeartRate}");
        // 3. Read-Only Properties: IdCardNumber, HeightInMeters, Bmi
        // IdCardNumber ��� HeightInMeters �١��駤�ҵ͹���ҧ Object ����
        Debug.Log($"ID Card Number : {p1.IdCardNumber}");
        Debug.Log($"Age : {p1.Age}");

        // ��˹���� WeightInKg ������� Bmi �ӹǳ��
        p1.weightInKG = 68;
        p1.heightInMeters = 1.75f;
        // Bmi �� Read-Only ��Фӹǳ�ҡ��� Weight ��� Height
        Debug.Log($"Bmi : {p1.Bmi:F2}");
        // �ͧ��������䢤�� Read-Only (���Դ Compile Error)
        //p1.IdCardNumber = "9999999999999"; // ERROR!
        //p1.HeightInMeters = 1.80; // ERROR!

        // 4. Write-Only Property: Password
        // ��駤�����ʼ�ҹ���١��ͧ (������� 8 ����ѡ�â���)
        p1.Password = "5tr0n9_p455w0rd";
        // �ͧ��駤�����ʼ�ҹ�������Թ�
        p1.Password = "123321";
        // �ͧ��������ҹ������ʼ�ҹ��Ѻ�� (���Դ Compile Error)
        // string password = p1.Password; // ERROR!
    }
}
