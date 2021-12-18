using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Peep.Parrot.Infrastructure.Data.Utils;

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
            t => t.ToTimeSpan(),
            t => TimeOnly.FromTimeSpan(t))
    { }
}