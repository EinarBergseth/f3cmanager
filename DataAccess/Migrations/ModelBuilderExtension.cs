
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

        }

        /// <summary>
        /// Sets DateTimeKind for DateTime/DateTime? to UTC. 
        /// This way all DateTime/DateTime? objects read from the Db can easily be converted to ISO 8601 format.
        /// NB! If any DateTime/DateTime? objects are considered local time, then those entries needs to be handled individually wrt. DateTimeKind.
        /// </summary>
        public static void SetDateTimeKind(this ModelBuilder modelBuilder)
        {
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                        property.SetValueConverter(dateTimeConverter);
                }
            }
        }
    }
}