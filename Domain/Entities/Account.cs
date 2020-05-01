using System.Collections.Generic;

namespace Domain.Entities
{
    class Account 
    {
        public float Amount { get; set; }

        public List<TimeDeposit> timeDeposits;

        public string AccountNumber { get; set; }

        public Account()
        {
            this.timeDeposits = new List<TimeDeposit>();
        }
    }
}