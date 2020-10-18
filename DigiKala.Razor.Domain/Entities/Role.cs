using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigiKala.Razor.Domain.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(20, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
