using System;
using System.ComponentModel.DataAnnotations;
namespace BankAccounts.Models
{   public abstract class BaseEntity{}
    public class Transaction : BaseEntity
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }

         public int Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime  Date { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
      