namespace OutPost.Domain.Entities;


public class Courier
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public DateOnly DateOfHire { get; set; }
    public bool IsHired { get; set; }

    private Courier() { }

    public Courier (string name, DateOnly dateOfHire)
    {
        Name = name;
        DateOfHire = dateOfHire;
        IsHired = true;
    }
}
