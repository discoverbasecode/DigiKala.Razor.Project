using System.ComponentModel.DataAnnotations;

namespace DigiKala.Razor.Domain.Dtos
{
    public class DtoResetPassword
    {
        [Display(Name = "کد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [Phone(ErrorMessage = "فقط عدد می توانید وارد کنید")]
        [MaxLength(6, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(6, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]
        public string ActiveCode { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(4, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تایید کلمه عبور")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور همخوانی ندارند")]
        public string ConfirmPassword { get; set; }
    }
}