namespace Labatym12
{ 
    enum AccountType
    {
        Текущий_счет,
        Сберегательный_счет
    }
    class BankAccount
    {
        private static int numberOfBankAccounts;
        private decimal accountBalance;
        readonly int accountNumber;
        readonly AccountType bankAccountType;


        public decimal AccountBalance
        {
            get
            {
                return accountBalance;
            }
        }



        public static bool operator ==(BankAccount firstBankAccount, BankAccount secondBankAccount)
        {
            return ((firstBankAccount.accountNumber == secondBankAccount.accountNumber) && (firstBankAccount.accountBalance == secondBankAccount.accountBalance) && (firstBankAccount.bankAccountType == secondBankAccount.bankAccountType));
        }
        public static bool operator !=(BankAccount firstBankAccount, BankAccount secondBankAccount)
        {
            return ((firstBankAccount.accountNumber != secondBankAccount.accountNumber) || (firstBankAccount.accountBalance != secondBankAccount.accountBalance) || (firstBankAccount.bankAccountType != secondBankAccount.bankAccountType));
        }


        public override bool Equals(object obj)
        {
            if (obj is BankAccount bankAccount)
            {
                if ((accountNumber == bankAccount.accountNumber) && (accountBalance == bankAccount.accountBalance) && (bankAccountType == bankAccount.bankAccountType))
                {
                    return true;
                }
            }

            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"{bankAccountType} №{accountNumber:D4} содержит {accountBalance} рублей";
        }


        private void ChangeNumberOfBankAccounts()
        {
            numberOfBankAccounts++;
        }
        public bool WithdrawMoneyFromAccount(decimal withdrawalAmount)
        {
            if ((accountBalance - withdrawalAmount > 0) && (withdrawalAmount > 0))
            {
                accountBalance -= withdrawalAmount;
                return true;
            }

            return false;
        }
        public bool PutMoneyIntoAccount(decimal depositedAmoun)
        {
            if (depositedAmoun > 0)
            {
                accountBalance += depositedAmoun;
                return true;
            }

            return false;
        }
        public bool TransferringMoney(BankAccount withdrawalAccount, decimal withdrawalAmount)
        {
            if ((withdrawalAmount > 0) && (withdrawalAccount.AccountBalance - withdrawalAmount > 0))
            {
                accountBalance += withdrawalAmount;
                withdrawalAccount.accountBalance -= withdrawalAmount;
                return true;
            }

            return false;
        }



        public BankAccount(decimal accountBalance)
        {
            this.accountBalance = accountBalance;
            bankAccountType = AccountType.Текущий_счет;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        public BankAccount(AccountType bankAccountType)
        {
            this.bankAccountType = bankAccountType;
            accountBalance = 0;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        public BankAccount(decimal accountBalance, AccountType bankAccountType)
        {
            this.accountBalance = accountBalance;
            this.bankAccountType = bankAccountType;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        public BankAccount()
        {
            accountBalance = 0;
            bankAccountType = AccountType.Текущий_счет;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
    }
}