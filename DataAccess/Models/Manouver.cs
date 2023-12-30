
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Models
{
    [Table("manouvers")]
    public class Manouver : GuidIdModel
    {
        [Required]
        [Column("name")]
        public string Name { get; set; } = "";

        [Required]
        [Column("factor")]
        public int Factor { get; set; }

        public class ManouverConfiguration : IEntityTypeConfiguration<Manouver>
        {
            public void Configure(EntityTypeBuilder<Manouver> builder)
            {

            }
        }
    }
}