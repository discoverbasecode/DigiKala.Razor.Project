using System.ComponentModel.DataAnnotations;

namespace DigiKala.Razor.Domain.Dtos
{
    public class DtoActivate
    {
        [Display(Name = "کد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [Phone(ErrorMessage = "فقط عدد می توانید وارد کنید")]
        [MaxLength(6, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [MinLength(6, ErrorMessage = "مقدار {0} نباید کم تر از {1} کاراکتر باشد")]
        public string ActiveCode { get; set; }
    }
}