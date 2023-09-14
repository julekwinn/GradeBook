
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace GradeBook.Infrastructure.Config.Converters;

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter(): base(
        d=> d.ToDateTime(TimeOnly.MinValue),
        d=>DateOnly.FromDateTime(d))
    {

    }
}
