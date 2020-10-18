using DigiKala.Razor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigiKala.Razor.Data.DataBaseContext
{
    public class DigiKalaContext:DbContext
    {
        public DigiKalaContext(DbContextOptions<DigiKalaContext>opt):base(opt)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=DigiKalaRazor_DB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        
        #region DbSet Config

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldCategory> FieldCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductField> ProductFields { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<StoreCategory> StoreCategories { get; set; }

        #endregion
    }



}