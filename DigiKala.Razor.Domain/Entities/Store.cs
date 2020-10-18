using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiKala.Razor.Domain.Entities
{
    public class Store
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل معتبر وارد کنید")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Mail { get; set; }

        [Display(Name = "نام فروشگاه")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "آدرس فروشگاه")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "شماره های تماس")]
        [MaxLength(40, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Tel { get; set; }

        [Display(Name = "فایل لوگو")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Logo { get; set; }

        [Display(Name = "سایر توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Desc { get; set; }

        [Display(Name = "فعالسازی موبایل")]
        public bool MobileActivate { get; set; }

        [Display(Name = "فعالسازی ایمیل")]
        public bool MailActivate { get; set; }

        [Display(Name = "کد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(6, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string MailActivateCode { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<StoreCategory> StoreCategories { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
