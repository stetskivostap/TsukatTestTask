using DataAccessLayer.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TsukatTestTask.Entities;

namespace DataAccessLayer.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(Constant.MaxNameLength);
            builder.Property(e => e.Email).HasMaxLength(Constant.MaxNameLength + 10);
            builder.Property(e => e.Age).HasMaxLength(Constant.MaxAgeLength);
        }
    }
}
