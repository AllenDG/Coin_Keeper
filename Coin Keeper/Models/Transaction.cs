using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coin_Keeper.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="Please select a category.")]
        //CategoryId
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Amount.")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWithIcon {
            get
            {
                return Category == null ? "" : Category.Icon + "" + Category.Title;
            }
                }
        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null ||Category.Type =="Expense" ) ? "- ": "+ ") + Amount.ToString("C0");
            }
        }

    }

  
}
