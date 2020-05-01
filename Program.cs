using System;
using Domain.Entities;
using Application.Service;
using Application.Managers;

namespace Banco
{
    class Program
    {
        static AccountService accountManager;

        static void Main(string[] args)
        {
            Console.Write("Ingrese una cantidad de días: ");

            int days = int.Parse(Console.ReadLine());

            Console.Write("Ingrese un número de cuenta: ");
            string number_account = Console.ReadLine();

            Console.Write("Ingrese una cantidad: ");
            float amount = float.Parse(Console.ReadLine());

            accountManager = new AccountService();

            var account = accountManager.findOneByAccountNumber(number_account);

            if(account == null)
            {
                return;
            }

            if(days < 0) 
            {
                return;
            }

            if(amount < 0)
            {
                return;
            }

            verificateAmountValidInAccount(account, amount);

            account.Amount -= amount;

            var timeDeposit = new TimeDeposit(amount, days);

            var timeDepositManager = new TimeDepositManager();

            timeDepositManager.save(timeDeposit);

            account.timeDeposits.Add(timeDeposit);

            accountManager.save(account);

            string algo = Console.ReadLine();
            
            Console.WriteLine("Time deposit created by $ {0} to {1} days", amount, algo);
        }

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            string algo = txtForm1.Text;
            string algo2 = txtForm2.Text;
            var account = new Account(algo, algo2);
            accountManager.save(account);
        }

        public static bool verificateAmountValidInAccount(Account account, float amount)
        {
            return account.Amount >= amount;
        }
    }
}
