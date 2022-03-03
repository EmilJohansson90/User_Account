using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; } = 0;
        public DateTime Created { get; set; } = DateTime.Now;
        public ICollection<Deposit>? Deposits { get; set; }
        public ICollection<Withdrawal>? Withdrawals { get; set; }
    }
}
