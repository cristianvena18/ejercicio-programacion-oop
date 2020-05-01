using System;
using Domain.Entities;
using Application.Service;
using Application.Managers;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese una cantidad de días: ");

            int days = int.Parse(Console.ReadLine());

            Console.Write("Ingrese un número de cuenta: ");
            string number_account = Console.ReadLine();

            Console.Write("Ingrese una cantidad: ");
            float amount = float.Parse(Console.ReadLine());

            var accountManager = new AccountService();

            var account = accountManager.findOneByAccountNumber(number_account);

            if(account == null)
            {
                Console.WriteLine("El numero de cuenta no se encontró");
                return;
            }

            if(days < 0) 
            {
                Console.WriteLine("El numero de días no puede ser negativo!");
                return;
            }

            if(amount < 0)
            {
                Console.WriteLine("El monto no puede ser negativo!");
                return;
            }

            if(!verificateAmountValidInAccount(account, amount))
            {
                Console.WriteLine("El numero de cuenta no se tiene la cantidad de dinero necesaria para realizar el plazo fijo");
            }

            account.Amount -= amount;

            var timeDeposit = new TimeDeposit(amount, days);

            var timeDepositManager = new TimeDepositManager();

            timeDepositManager.save(timeDeposit);

            account.timeDeposits.Add(timeDeposit);

            accountManager.save(account);

            string algo = Console.ReadLine();
            
            Console.WriteLine("Time deposit created by $ {0} to {1} days", amount, algo);
        }

        public static bool verificateAmountValidInAccount(Account account, float amount)
        {
            return account.Amount >= amount;
        }
    }
}
