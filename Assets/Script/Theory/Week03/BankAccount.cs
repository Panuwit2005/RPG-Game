using System;
using UnityEngine;

public class BankAccount 
{
    // public: ��Ҷ֧��ҡ�ء��� (�Ţ���ѭ���Ҹ�ó�)
    public string AccountNumber;
    // protected: ��Ҷ֧��㹤��� BankAccount ��Ф��ʷ���׺�ʹ���ҹ�� (�ʹ�Թ��������´��͹)
    protected float _balance;
    // internal: ��Ҷ֧��੾��� Assembly ���ǡѹ (��Ҥ�����ǡѹ) �� �������Ң�
    internal string BranchID;
    // private: ��Ҷ֧��੾��㹤��� BankAccount ��ҹ�� (���ʼ�ҹ����Ӥѭ)
    private string _passwordHash;
    // Constructor �ͧ Base Class
 
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

    // public: ���ʹ����Ѻ�ҡ�Թ (�ء����ͧ����)
    public void Deposit(float amount)
    {
        if (amount > 0)
        {
            _balance += amount;
        }
    }
    // protected: ���ʹ����Ѻ�͹�Թ (������������١���¡��)
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
    //4. private: ���ʹ����Ѻ��Ǩ�ͺ���ʼ�ҹ
    // ����������� (Encapsulation)
    // ���ͻ���ͧ�������Ӥѭ���������Ҷ֧��ҡ��¹͡��º���ʼ�ҹ����Ѻ�ҡѺ���ʼ�ҹ��������
    private bool VerifyPassword(string password)
    {
        return password == _passwordHash;
    }
    public bool CheckPassword(string password)
    {
        return VerifyPassword(password);
    }
    //5. public: ���ʹ��������¡ private method �ҡ��¹͡
    // ����������� (Encapsulation)
    // ���ͻ���ͧ�������Ӥѭ���������§������ʼ�ҹ�١��ͧ�������
    
}
