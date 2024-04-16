using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, full =>
            {
                full.Property(f=>f.FirstName).HasMaxLength(30);
                full.Property(f => f.FirstName).HasColumnName("PassFirstName");

                full.Property(f=>f.LastName).IsRequired();
                full.Property(f=>f.LastName).HasColumnName("PassLastName");
               
            });
            /* une seul table passenger traveller staff discriminator name ustravller
            //savoir si traveller ou staff      //nom de la colone
                builder.HasDiscriminator<string>("IsTraveller")
                // prend 1 si traveller
                .HasValue<Traveller>("1")
                // prend 2 si staff
                .HasValue<Staff>("2")
                // 0 sinon 
                .HasValue<Passenger>("0");
            */
        }
    }
}
