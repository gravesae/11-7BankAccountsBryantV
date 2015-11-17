using LibraryFinancialAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountsInheritanceBryantV
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;

            while(loop == true)
            { 
            
            string strCxInput;
            decimal decCxInput;
            int intCxInput;

            Console.WriteLine(AccountMonetary.ConsoleAppLiteralWelcomeMessage());
            Console.WriteLine(AccountMonetary.CheckingOrSavings());

              intCxInput = 
            AccountMonetary.ConsoleAppInputToInt(Console.ReadLine());

                switch(intCxInput)
                {
                    default:
                        {

                    //initialize object
                    //Bank Account Initializer with account balance in contructor
                    AccountMonetary BankAccount = new AccountMonetary(50);

                    Console.WriteLine(BankAccount.ToString());


                    //Account Action, prompted for Debit or Credit Action (1[debit] or 0[credit])
                    break;
                        }//end default
                    case 0://Savings
                        {
                            //prompt for initial amount & interest rate
                            //dec savingsInterestRate & savingsInitialBalance go in Constructor
                            string balPrompt = AccountMonetary.PromptForInitializingBalance;
                            Console.WriteLine(balPrompt);

                            decimal savingsInitialBalance =
                    AccountMonetary.ConsoleAppInputToDecimal(Console.ReadLine());

                            Console.WriteLine(AccountMonetary.PromptForInitializingInterestRate);

                            decimal savingsInterestRate =
                     AccountMonetary.ConsoleAppInputToDecimal(Console.ReadLine());


                            //Initialize Object of SavingsAccount
                                SavingsAccount SavingsAccount = new SavingsAccount(savingsInitialBalance, savingsInterestRate);
                    
                            
                     
                    //Choose Debit or Credit
                    Console.WriteLine(AccountMonetary.ConsoleAppMessageLiteralDebitOrCredit());
                                        Console.Read();
                    
                                        int switchValueResponse =
                                        AccountMonetary.ConsoleAppInputToInt(Console.ReadLine());
                    

                          
                                        SavingsAccount.SwitchCreditDebit(switchValueResponse);


                            //Print Account Info
                                        SavingsAccount.ToString();
                                        Console.Read();

                                        break;
                        }//end savings Switch
                    case 1:
                        {//Checking Switch block
                            //prompt for initial amount & transaction charge amount 
                            //dec checkingTransactionCharge & savingsInitialBalance go in Constructor
                            Console.WriteLine(AccountMonetary.PromptForInitializingBalance);

                            decimal checkingInitialBalance = 
                                AccountMonetary.ConsoleAppInputToDecimal(Console.ReadLine());

                            Console.WriteLine(AccountMonetary.PromptForInitializingChargeTransaction);

                            decimal checkingTransactionCharge =
                                AccountMonetary.ConsoleAppInputToDecimal(Console.ReadLine());

                            AccountMonetary CheckingAccount = new CheckingAccount(checkingInitialBalance, checkingTransactionCharge);
                            //--------------------------------------

                            //Choose Debit or Credit
                            Console.WriteLine(AccountMonetary.ConsoleAppMessageLiteralDebitOrCredit());
                            Console.Read();

                            int switchValueResponse =
                            AccountMonetary.ConsoleAppInputToInt(Console.ReadLine());

                            CheckingAccount.SwitchCreditDebit(switchValueResponse);

                            //Print Account Info
                            CheckingAccount.ToString();
                            Console.Read();

                            break;
                        }//end checking switch

                }//end switch block

            




            
}

        }
    }
}
