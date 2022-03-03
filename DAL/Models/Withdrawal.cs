using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Withdrawal
    {
        public int WithdrawalId { get; set; }
        public decimal WithdrawalAmount { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public User User { get; set; }
    }
}
