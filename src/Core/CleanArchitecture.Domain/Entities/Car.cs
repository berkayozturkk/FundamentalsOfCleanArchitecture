using CleanArchitecture.Domain.Abstraction;

namespace CleanArchitecture.Domain.Entities;

internal sealed class Car : Entity
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string EnginePower { get; set; }
}
