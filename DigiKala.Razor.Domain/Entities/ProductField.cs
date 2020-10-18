using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiKala.Razor.Domain.Entities
{
    public class ProductField
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int FieldId { get; set; }

        [Display(Name = "مقدار مشخصه")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Value { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("FieldId")]
        public virtual Field Field { get; set; }
    }
}
