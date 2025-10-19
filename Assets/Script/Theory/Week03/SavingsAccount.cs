using System;
using UnityEngine;

public class SavingsAccount : BankAccount
{
    // public: �ѵ�Ҵ͡����
    public float InterrestRate;
    // Constructor �ͧ SavingsAccount
    public SavingsAccount(string accountNumer,string password, float initialBalance,string branchID, float interrestRate) : base(accountNumer, password,initialBalance, branchID)
    {
        InterrestRate = initialBalance;
    }

    //9. public: ���ʹ����Ѻ�͹�Թ���١�Ǻ���
    //����������� (Encapsulation) �µ�Ǩ�ͺ���ʼ�ҹ��͹
    //���ͺ�����Ҷ֧ protected method �ҡ�����١
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

    //8. public: ���ʹ੾�Тͧ SavingsAccount
    //���ͺ�����Ҷ֧ protected field �ҡ�����١
    public void AddMounthlyInterrest()
    {
        float interest = _balance * InterrestRate;
        _balance += interest;
    }
}
