using DataAccessLayer.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TsukatTestTask.Entities;

namespace DataAccessLayer.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(Constant.MaxNameLength);
            builder.HasMany(e => e.Users).WithOne(e => e.Role).HasForeignKey(e=> e.RoleId);
        }
    }
}
