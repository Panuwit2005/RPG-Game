using System;
using UnityEngine;

public class BankAccount 
{
    // public: เข้าถึงได้จากทุกที่ (เลขที่บัญชีสาธารณะ)
    public string AccountNumber;
    // protected: เข้าถึงได้ในคลาส BankAccount และคลาสที่สืบทอดไปเท่านั้น (ยอดเงินที่ละเอียดอ่อน)
    protected float _balance;
    // internal: เข้าถึงได้เฉพาะใน Assembly เดียวกัน (ธนาคารเดียวกัน) เช่น ข้อมูลสาขา
    internal string BranchID;
    // private: เข้าถึงได้เฉพาะในคลาส BankAccount เท่านั้น (รหัสผ่านที่สำคัญ)
    private string _passwordHash;
    // Constructor ของ Base Class
 
    public BankAccount(string accountNumer, string password, float initialBalance, string branchID)
    {
        AccountNumber = accountNumer;
        _balance = initialBalance;
        BranchID = branchID;
        _passwordHash = password;

    }

    public BankAccount()
    {

    }

    // public: เมธอดสำหรับฝากเงิน (ทุกคนต้องทำได้)
    public void Deposit(float amount)
    {
        if (amount > 0)
        {
            _balance += amount;
        }
    }
    // protected: เมธอดสำหรับถอนเงิน (มีไว้ให้คลาสลูกเรียกใช้)
    protected bool Withdraw(float amount)
    {
        if(amount > 0 && _balance >= amount)
        {
            _balance -= amount;
            Debug.Log($"Withdraw {amount}. New balance" + $" {_balance}");
            return true;
        }
        Debug.Log("Insufficient funds or invalid amount.");
        return false;
    }
    //4. private: เมธอดสำหรับตรวจสอบรหัสผ่าน
    // ใช้การห่อหุ้ม (Encapsulation)
    // เพื่อปกป้องข้อมูลสำคัญเพื่อไม่เข้าถึงได้จากภายนอกเทียบรหัสผ่านที่รับมากับรหัสผ่านที่เก็บไว้
    private bool VerifyPassword(string password)
    {
        return password == _passwordHash;
    }
    public bool CheckPassword(string password)
    {
        return VerifyPassword(password);
    }
    //5. public: เมธอดที่ใช้เรียก private method จากภายนอก
    // ใช้การห่อหุ้ม (Encapsulation)
    // เพื่อปกป้องข้อมูลสำคัญช่วยรู้เพียงว่ารหัสผ่านถูกต้องหรือไม่
    
}
