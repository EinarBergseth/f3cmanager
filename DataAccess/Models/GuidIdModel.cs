using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public abstract class GuidIdModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }
    }
}