using System;
using UnityEngine;

public class SavingsAccount : BankAccount
{
    // public: อัตราดอกเบี้ย
    public float InterrestRate;
    // Constructor ของ SavingsAccount
    public SavingsAccount(string accountNumer,string password, float initialBalance,string branchID, float interrestRate) : base(accountNumer, password,initialBalance, branchID)
    {
        InterrestRate = initialBalance;
    }

    //9. public: เมธอดสำหรับถอนเงินที่ถูกควบคุม
    //ใช้การห่อหุ้ม (Encapsulation) โดยตรวจสอบรหัสผ่านก่อน
    //ทดสอบการเข้าถึง protected method จากคลาสลูก
    public void WithdrawFunds(float amount, string password)
    {
        if (CheckPassword(password))
        {
            Withdraw(amount);
        }
        else
        {
            Debug.Log("Incorrect password");
        }
    }

    //8. public: เมธอดเฉพาะของ SavingsAccount
    //ทดสอบการเข้าถึง protected field จากคลาสลูก
    public void AddMounthlyInterrest()
    {
        float interest = _balance * InterrestRate;
        _balance += interest;
    }
}
