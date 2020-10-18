using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiKala.Razor.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int StoreId { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Date { get; set; }

        [Display(Name = "ساعت ثبت")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Time { get; set; }

        [Display(Name = "نام محصول")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "تصویر شاخص")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Img { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "قیمت قبل")]
        public int DeletePrice { get; set; }

        [Display(Name = "موجودی")]
        public int Exist { get; set; }

        [Display(Name = "عدم نمایش")]
        public bool NotShow { get; set; }

        [Display(Name = "سایر توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Desc { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }

        public virtual ICollection<ProductGallery> ProductGalleries { get; set; }

        public virtual ICollection<ProductField> ProductFields { get; set; }
    }
}
