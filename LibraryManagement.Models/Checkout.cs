using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Models;
public class Checkout
{
    public int CheckoutID { get; set; }
    public int BookID { get; set; } // Foreign key
    public String UserID { get; set; } // Foreign key
    public DateTime CheckoutDate { get; set; } // تاريخ الإعارة
    public DateTime DueDate { get; set; } // تاريخ الاستحقاق
    public bool IsReturned { get; set; } // حالة الإرجاع
    public DateTime? ReturnDate { get; set; } // تاريخ الإرجاع

    public Book Book { get; set; }
    public Users Users { get; set; }
    public Penalty Penalty { get; set; }  

    public ICollection<Penalty> Penalties { get; set; }
    public ICollection<Return> Returns { get; set; }

}
