using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }//end class AccountMonetary
}
