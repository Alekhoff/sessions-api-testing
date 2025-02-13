namespace Core.Model;

public class Person
{
    public string FirstName { get; set; } = string.Empty;
    internal string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public string SayHello()
    {
        return $"Hello, my name is: {FirstName} {LastName}";
    }
}