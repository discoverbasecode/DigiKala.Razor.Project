using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiKala.Razor.Domain.Entities
{
    public class StoreCategory
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "تاریخ")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Date { get; set; }

        [Display(Name = "ساعت")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Time { get; set; }

        [Display(Name = "تأیید")]
        public bool IsActive { get; set; }

        [Display(Name = "سایر توضیحات")]
        public string Desc { get; set; }

        [Display(Name = "تصویر مدارک")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Img { get; set; }

        [ForeignKey("UserId")]
        public virtual Store Store { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
