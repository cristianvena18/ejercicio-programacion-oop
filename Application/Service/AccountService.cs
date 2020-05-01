using Domain.Entities;

namespace Application.Service
{
    class AccountService
    {
        public Account findOneByAccountNumber(string accountNumber)
        {
            if(accountNumber == "1234")
            {
                var account = new Account();
                account.AccountNumber = accountNumber;
                account.Amount = 1000;
                return account;
            }
            return null;
        }

        public void save(Account account)
        {
            
        }
    }
}