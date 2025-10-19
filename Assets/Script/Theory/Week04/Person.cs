using System;
using UnityEngine;

public class Person : MonoBehaviour
{
    // C# �����ҧ private field ���� backing field ������ѵ��ѵ�
    //1. Auto-Implemented Property
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    //2. Full Property (�ٻẺ���) ���ٻẺ�������ó����ش ���������Ѻ����ͤس��ͧ��äǺ��������Ҷ֧���������ҧ�����´
    
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

    //3. Property Ẻ Read-Only (��ҹ�����ҧ����)
    //�Ըշ�� 1: �� public get; private set;
    public string IdCardNumber { get; private set; }
    //�Ըշ�� 2: �� public get; ���ҧ����
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

    //4. Property Ẻ Write-Only (��¹�����ҧ����)
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

    //5. Protected Property (����Ѻ���ʷ���׺�ʹ��ҹ��)
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
