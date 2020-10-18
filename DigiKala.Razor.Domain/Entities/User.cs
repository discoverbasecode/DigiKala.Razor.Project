using System.ComponentModel.DataAnnotations;

namespace DigiKala.Razor.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(11, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Mobile { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "کد ملی")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Code { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string FullName { get; set; }

        [Display(Name = "کد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(6, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string ActiveCode { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Date { get; set; }

        public virtual Role Role { get; set; }

        public virtual Store Store { get; set; }
    }
}
