using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiKala.Razor.Domain.Entities
{
    public class ProductGallery
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "تصویر گالری")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Img { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
