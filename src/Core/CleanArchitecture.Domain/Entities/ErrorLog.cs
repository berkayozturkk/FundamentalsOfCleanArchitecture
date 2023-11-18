using CleanArchitecture.Domain.Abstraction;

namespace CleanArchitecture.Domain.Entities;

public sealed class ErrorLog : Entity
{
    public string ErrorMessage { get; set; }
    public string StackTree { get; set; }
    public string RequestPath { get; set; }
    public string RequestMethod { get; set; }
    public DateTime TimeStamp { get; set; }
}
