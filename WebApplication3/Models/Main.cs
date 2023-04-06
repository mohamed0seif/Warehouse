using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Main
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("الاسم")]
        public string NameOperator { get; set; }

        [Required]
        [DisplayName("اسم المورد")]
        public string NameVendor { get; set; }

        [Required]
        [DisplayName("اسم المنتج")]
        public string NameProduct { get; set; }

        [Required]
        [DisplayName("سعر الوحدة")]
        public long UnitPrice { get; set; }

        [Required]
        [DisplayName("عدد الكيلوهات")]
        public long NumberOfKillos { get; set; }

        [Required]
        [DisplayName("القيمة")]
        public long Value { get; set; }

        [Required]
        [DisplayName("المبلغ المسدد")]
        public int Portion { get; set; }

        [Required]
        [DisplayName("المتبقي")]
        public long Remains { get; set; }

        [DisplayName("الوقت")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        [DisplayName("ملاحظات")]
        public string? Description { get; set; }

    }
}
