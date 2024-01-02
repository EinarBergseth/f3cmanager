using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Models
{
    /// <summary>
    /// DB table Model for Competition Classes.
    /// </summary>
    [Table("competition_classes")]
    public class CompetitionClass : GuidIdModel
    {
        /// <summary>
        /// Id of related Event.
        /// </summary>
        [Required]
        [Column("event_id")]
        public string EventId { get; set; }

        /// <summary>
        /// Name of competition class (Eg. F3C).
        /// </summary>
        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// If true, exclude lowest and highest manouver scores from the total.
        /// </summary>
        [Required]
        [Column("exclude_lowest_highest_scores")]
        public bool ExcludeLowestHighestScores { get; set; }

        /// <summary>
        /// If true, normalize round scores.
        /// </summary>
        [Required]
        [Column("normalize_scores")]
        public bool NormalizeScores { get; set; }

       /// <summary>
        /// If true, exclude lowest round scores from the total.
        /// </summary>
        [Required]
        [Column("exclude_lowest_round_scores")]
        public bool ExcludeLowestRoundScores { get; set; }

        
        public class CompetitionClassConfiguration : IEntityTypeConfiguration<CompetitionClass>
        {
            public void Configure(EntityTypeBuilder<CompetitionClass> builder)
            {

            }
        }
    }
}