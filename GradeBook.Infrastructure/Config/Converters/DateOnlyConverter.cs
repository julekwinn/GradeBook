
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace GradeBook.Infrastructure.Config.Converters;

public class DateOnlyConverterr : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverterr(): base(
        d=> d.ToDateTime(TimeOnly.MinValue),
        d=>DateOnly.FromDateTime(d))
    {

    }
}
