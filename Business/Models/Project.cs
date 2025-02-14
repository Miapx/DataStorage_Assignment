using Data.Entities;

namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }


    //public string CustomerName { get; set; } = null!;
    public CustomerEntity Customer { get; set; } = null!;

    //public string StatusName { get; set; } = null!;
    public StatusTypeEntity Status { get; set; } = null!;

    //public string Name { get; set; } = null!;
    //public string Email { get; set; } = null!;
    public UserEntity User { get; set; } = null!;

    //public string ProductName { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;
}
