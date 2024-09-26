using Core.Entities;

namespace Entities.Concrete;

public class Customer : IEntity
{
    public string CustomerId { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public int CartId { get; set; }
}