/*using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Peep.Parrot.Infrastructure.Data.Utils;

public class TimeOnlyConverter : ValueConverter<TimeOnly, DateTime>
{
    public TimeOnlyConverter() : base(
            t => t.ToDateTime(TimeOnly.MinValue),
            t => TimeOnly.FromDateTime(t))
    { }
}*/