using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Models
{
    /// <summary>
    /// DB table Model for users.
    /// </summary>
    [Table("users")]
    public class User : GuidIdModel
    {
        /// <summary>
        /// First Name of user.
        /// </summary>
        [Required]
        [Column("first_name")]
        [MaxLength(100)]
        public string FirstName { get; set; } = "";

        /// <summary>
        /// SurName of user.
        /// </summary>
        [Required]
        [Column("surname")]
        [MaxLength(100)]
        public string SurName { get; set; } = "";

        /// <summary>
        /// Email address of user.
        /// </summary>
        [Required]
        [Column("email")]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";

        /// <summary>
        /// Phone No. of user.
        /// </summary>
        [Required]
        [Column("phone")]
        [MaxLength(100)]
        public string Phone { get; set; } = "";

        /// <summary>
        /// Street address of user.
        /// </summary>
        [Required]
        [Column("address")]
        [MaxLength(200)]
        public string Address { get; set; } = "";

        public virtual ICollection<Event>? Events { get; set; }

        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {

            }
        }
    }
}