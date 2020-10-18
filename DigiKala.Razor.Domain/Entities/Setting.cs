using System.ComponentModel.DataAnnotations;

namespace DigiKala.Razor.Domain.Entities
{    
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام سایت")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string SiteName { get; set; }

        [Display(Name = "توضیح مختصر")]
        [DataType(DataType.MultilineText)]
        public string SiteDesc { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [DataType(DataType.MultilineText)]
        public string SiteKeys { get; set; }

        [Display(Name = "API")]
        public string SmsApi { get; set; }

        [Display(Name = "شماره فرستنده")]
        [MaxLength(15, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string SmsSender { get; set; }

        [Display(Name = "ایمیل فرستنده")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string MailAddress { get; set; }

        [Display(Name = "کلمه عبور ایمیل")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string MailPassword { get; set; }
    }
}
