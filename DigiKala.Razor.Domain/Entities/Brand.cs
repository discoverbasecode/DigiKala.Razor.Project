using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiKala.Razor.Domain.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "برند")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "لوگو")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Img { get; set; }

        [Display(Name = "عدم نمایش")]
        public bool NotShow { get; set; }

        public int? StoreId { get; set; }

        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
