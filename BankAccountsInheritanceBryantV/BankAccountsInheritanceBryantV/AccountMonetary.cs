using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Grade: 9.8
//Observations:
//The requirements state that the Account base class should validate the intial balance is > 0.  Your program validates that the property setting is always > 0.
//This would cause the following bugs in your program:
//1. The initial balance could be set to a negative value because your constructor is setting the private instance variable.
//2. The balance could never be set to a negative account balance even though a balance can be negative.
//Your Debit method does not validate that the amount being withdrawn does not exceed the account balance.  You are checking that in a Withdrawl property, but this property is not useful
//as the amount withdrawn is passed as an argument to the debit method.
//The accountbalance property should be read only (there should be a get method but no set method)
//In your CalculateAnnualInterest method you are applying a credit, this would be a major bug because any time the program attempted to calculate interest, the account would be credited.
//What if there was a user interface just displaying the amount of interest, every time it used this method to calculate, the accountholder would get a credit! 
namespace LibraryFinancialAccount
{
    public class AccountMonetary
    {
        /*
         * private accountBalance; >= 0,
         * 
         * credit(deposit)[method], 
         * Withdraw(debit)[method], (ensure the account cannot go negative)"Debit amount exceeded acccount balance."
         * 
          DerivedClasses:
            Savings account:    earning interest(method), private interestRate
         *          SavingsAccount(dbl balance, dbl interestRate)
         *          Method: CalculateInterest: Calculate earned interest -> pass interest amount back to base.Credit to assign funds
            Checking account:   Fee Per transaction(method)
                    CheckingAccount(dbl balance, dbl feePerTransaction)
         *          Override 
         *--------------------------------------------------------------------------------------------------------------------------------          
         */
                    
        //Class account intstance Variables
        private decimal accountBalance;
        private decimal withdrawl;
        private decimal credit;
        private decimal errorCode = 0;

        private string exceptionLiteral = "Please enter a withdrawl amount that does not exceed the AccountBalance";

        public static string ExceptionCurrent = "Error";

        public static string PromptForInitializingBalance = "Please enter the value that the customer will be depositing to Open the account: ";
        public static string PromptForInitializingInterestRate = "Please enter the Interest Rate at which the savings account will grow";
        public static string PromptForInitializingChargeTransaction = "Please enter the rate at which the customer will be charged per transaction";

        public AccountMonetary(decimal balance)
        {
            accountBalance = balance;
        }//end constructor

        public decimal AccountBalance
        {
            get
            {
                return accountBalance;
            }//end get
            set
            {
                if (value >= 0)
                {
                    accountBalance = value;
                }//end if: property AccountBalance
            }//end set
                        
        }//end property AccountBalance

        public string AccountType()
        {
            return "default";
        }//end Property AccountType

        public decimal Withdrawl
        {
            get
            {
                return withdrawl;
            }// end get
            set
            {
                if (value < AccountBalance)
                {
                    withdrawl = value;
                }
                else
                {
                    exceptionLiteral = "";
                    Console.WriteLine(exceptionLiteral);
                    
                 }
            }//end set
        }// end Property Withdrawl

        public virtual decimal Credit(decimal creditAmount)
        {//credit account/add funds
            AccountBalance += creditAmount;
            return AccountBalance;

        }//end Method Credit

        public virtual decimal Debit(decimal withdrawlAmount)
        {
            withdrawl = withdrawlAmount;

                return AccountBalance - Withdrawl;
            
        }// end method Debit 


       public static string ExceptionLiteralNumberOutOfRange()
        {
           //string exceptionLiteralNumberOutOfRange = "Please Enter a number within range with respect to your AccountBalance."
           return "Please Enter a number within range with respect to your AccountBalance.";
        }// end ExceptionLiteralOutOfRange

        public static string ConsoleAppMessageLiteralDebitOrCredit()
       {
           return "Please Select 1 to Debit or remove funds from the account & Select 0 to Credit or Add funds to the Account:";
       }//end static ConsoleAppMessageLiteralDebitOrCredit

        public static string CheckingOrSavings()
        {
            return "For a Checking/Spending account (Charges Included) select 1, For a Savings account that builds interest select 0.";
        }//end string CheckingOrSavings

        public static string ConsoleAppLiteralWelcomeMessage()
        {
            return "Hello & Welcome, Open Bank Accounts with FunTrust Application.";
        }

        public static string ConsoleAppMessageLiteralDebitPrompt()
        {
            return "Please Enter the value to be Debited or withdrawn from the account";
        }

        public static string ConsoleAppMessageLiteralCreditPrompt()
        {
            return "Please Enter the value to be Credited or Added to the account";
        }

        //switch statement for ConsoleApplications Debit/Credit - 1/0
        public void SwitchCreditDebit(int debCred01)
        {
            switch (debCred01)
            {
                case 0:
                    {//Credit
                        decimal decCxInput;
                        string strCxInput;
                        //prompt amount for Credit
                        Console.WriteLine(AccountMonetary.ConsoleAppMessageLiteralCreditPrompt());

                        //string to decimal from console app input
                        decCxInput =
                            AccountMonetary.ConsoleAppInputToDecimal(Console.ReadLine());

                        //insert value into Method 
                        Console.WriteLine("New Balance:\t" + this.AccountBalance);
                        this.Credit(decCxInput);
                        break;
                        
                    }//end '0' credit Switch
                case 1:
                    {//Debit
                        decimal decCxInput;
                        string strCxInput;
                        //prompt amount for Debit
                        Console.WriteLine(AccountMonetary.ConsoleAppMessageLiteralDebitPrompt());

                        decCxInput =
                            AccountMonetary.ConsoleAppInputToDecimal(Console.ReadLine());

                        //insert value into method
                        this.Credit(decCxInput);
                        break;
                    }// end '1' debit switch
                default:
                    {
                        Console.WriteLine("Amount OUT OF RANGE");
                        Console.WriteLine("Account Balance: \t" +AccountBalance);
                        break;
                    }//end default
                    Console.WriteLine("Account Balance: \t" + AccountBalance);
                     
            }//end switch block
        }// end SwitchCreditDebit method: decimal

        public virtual string ToString()
        {

            return this.AccountBalance.ToString();
        }

        public static int ConsoleAppInputToInt(string consoleUserInput)
        {
            string strCxInput = consoleUserInput;
            int intCxInput;

            //type change
            strCxInput = Console.ReadLine();
            int.TryParse(strCxInput, out intCxInput);

            return intCxInput;
           }//end ConsoleAppResponseInt

        public static double ConsoleAppInputToDouble(string consoleUserInput)
        {
            string strCxInput = consoleUserInput;
            double dblCxInput;

            //type change
            strCxInput = Console.ReadLine();
            double.TryParse(strCxInput, out dblCxInput);

            return dblCxInput;
        }//end ConsoleAppResponseDbl

        public static decimal ConsoleAppInputToDecimal(string consoleUserInput)
        {
            string strCxInput = consoleUserInput;
            decimal decCxInput;

            //type change
            strCxInput = Console.ReadLine();
            decimal.TryParse(strCxInput, out decCxInput);

            return decCxInput;
        }//end ConsoleAppResponseDec

    }//end class AccountMonetary










    class SavingsAccount : AccountMonetary
    {
        decimal interestRate;
        string accountType;
        DateTime timeStamp = new DateTime();
        

        //Constructor
        public SavingsAccount(decimal balance, decimal interestR): base (balance)
        {

            interestRate = interestR;

        }//end constructor

        public decimal ProjectedBalance()
        {
            return this.AccountBalance * (this.InterestRate + 1);
        }

        public decimal InterestRate
        {
            get
            {
                return interestRate;
            }
            set
            {
                if(value <0)
                {
                    interestRate = value;
                }
                else
                {
                   Console.WriteLine( AccountMonetary.ExceptionLiteralNumberOutOfRange());
                }
            }
        }//end property InterestRate

        public string AccountType()
        {
            return "Savings";
        }//End Property AccountType


        public decimal CalculateAnnualInterest()
        {//returns the AccountBalance after 1year of interest
            decimal annualInterest;

            annualInterest = AccountBalance * InterestRate;
            base.Credit(annualInterest);

            return AccountBalance;
        }//end method CalculateAnnualInterest

        

        public override string ToString()
        {

            return this.AccountType() + "\t" + this.AccountBalance.ToString() + "\t" + this.InterestRate.ToString() +
                "\nTotal in One Year, based on current Account Balance & Interest Rate: \n" + this.ProjectedBalance().ToString() ;
        }//end toString override



    }//end class SavingsAccount:AccountMonetary

    class CheckingAccount : AccountMonetary
    {

        decimal chargeTransactionAmount;

        public CheckingAccount(decimal balance, decimal chargeTransaction) :base(balance)
        {
            chargeTransactionAmount = chargeTransaction;
        }

        public decimal ChargeTransactionAmount
        {
            get
            {
                return chargeTransactionAmount;
            }
            set
            {
                if(value>0)
                {
                    chargeTransactionAmount = value;
                }
            }//end set
    }//end Property ChargeTransactionAmount

        public override decimal Credit(decimal creditAmount)
        {
            //subtract charge
            AccountBalance = AccountBalance - ChargeTransactionAmount;

            return base.Credit(creditAmount);
        }

        public override decimal Debit(decimal withdrawlAmount)
        {
            //subtract charge
            AccountBalance = AccountBalance - ChargeTransactionAmount;
            return base.Debit(withdrawlAmount);
        }



    
    }//end class CheckingAccount:AccountMonetary


} //end NameSpace: LibraryFinancialAccount
