using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Models;

public class Return
{
    public int ReturnID { get; set; }
    public int CheckoutID { get; set; } // Foreign key
    public DateTime ReturnDate { get; set; } // تاريخ الإرجاع
    public bool IsDamaged { get; set; } // حالة الكتاب عند الإرجاع
    public string Comments { get; set; } // ملاحظات عن الكتاب

    // Navigation Property
    public Checkout Checkout { get; set; }
}
