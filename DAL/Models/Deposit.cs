using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Deposit
    {
        public int DepositId { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public User User { get; set; }
    }
}
