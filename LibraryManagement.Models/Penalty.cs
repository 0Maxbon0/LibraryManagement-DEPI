using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Models;
public class Penalty
{
    public int PenaltyID { get; set; }
    public int CheckoutID { get; set; } // Foreign key
    public decimal Amount { get; set; } // مبلغ الجزاء
    public DateTime PenaltyDate { get; set; } // تاريخ فرض الجزاء
    public bool IsPaid { get; set; } // حالة الدفع

    public Checkout Checkout { get; set; }
}
