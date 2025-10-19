using System;
using UnityEditor;
using UnityEngine;

public class BankAccountGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //1. ÊÃéÒ§ Object ¢Í§ºÑ­ªÕ¸¹Ò¤ÒÃ·ÑèÇä» (Base Class)
        BankAccount genaralAccount = new BankAccount("Pxwit-1234","***",300,"บางบัว");
        genaralAccount.AccountNumber = "EDokGam-54465654";
        genaralAccount.BranchID = "Kaset";
        
        genaralAccount.Deposit(20);

        //2. ÅÍ§à¢éÒ¶Ö§¿ÔÅ´ìáÅÐàÁ¸Í´·ÕèÁÕ¡ÒÃ¡ÓË¹´ÃÐ´Ñº¡ÒÃà¢éÒ¶Ö§µèÒ§æ
        Debug.Log("password is " + genaralAccount.CheckPassword("***"));

        //3. àÃÕÂ¡àÁ¸Í´·Õèãªé¡ÒÃËèÍËØéÁÇèÒ¨Ðà¢éÒ¶Ö§ÃËÑÊ¼èÒ¹ä´éÍÂèÒ
        SavingsAccount savingsAccount = new SavingsAccount("Bo-6544", "****", 500, "SPU", 0.03f);
        Debug.Log(savingsAccount.AccountNumber);
        Debug.Log(savingsAccount.BranchID);
        genaralAccount.Deposit(500);

        //6. ÊÃéÒ§ Object ¢Í§ºÑ­ªÕÍÍÁ·ÃÑ¾Âì


        //7. ÅÍ§à¢éÒ¶Ö§¿ÔÅ´ìáÅÐàÁ¸Í´·ÕèÁÕ¡ÒÃ¡ÓË¹´ÃÐ´Ñº¡ÒÃà¢éÒ¶Ö§µèÒ§æ
        // protected: äÁèÊÒÁÒÃ¶à¢éÒ¶Ö§ä´é¨Ò¡ÀÒÂ¹Í¡
        // myAccount._balance = 2000; // ERROR!
        // myAccount.Withdraw(100); // ERROR!

        // private: äÁèÊÒÁÒÃ¶à¢éÒ¶Ö§ä´é¨Ò¡ÀÒÂ¹Í¡
        // myAccount._passwordHash = "new_pass"; // ERROR!
        // myAccount.VerifyPassword("password"); // ERROR!

        //10. àÃÕÂ¡àÁ¸Í´·Õèãªé¡ÒÃËèÍËØéÁ
        savingsAccount.WithdrawFunds(200f, "***");
        savingsAccount.WithdrawFunds(200f, "****");
        savingsAccount.WithdrawFunds(1500, "****");

        savingsAccount.AddMounthlyInterrest();
    }


}
