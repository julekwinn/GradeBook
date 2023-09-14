
using System.Net;

namespace Gradebook.Domain.Exceptions
{
    public abstract class GradeBookException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        public GradeBookException(string message) : base(message) 
        {

        }

    }
}
