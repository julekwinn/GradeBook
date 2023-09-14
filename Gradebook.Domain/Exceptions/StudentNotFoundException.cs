using System.Net;
namespace Gradebook.Domain.Exceptions
{
    public class StudentNotFoundException : GradeBookException
    {
        public int Id { get; set; }
        public StudentNotFoundException(int id) : base($"Student with ID{id} not Found") 
        {
            Id = id;
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}
