using Core.Model;

namespace PersonsApi.Services;

public class PersonService
{
    public async Task<Person> GetPerson(string pFirstName, string pLastName)
    {
        var vPerson = new Person()
        {
            FirstName = pFirstName,
            LastName = pLastName,
            DateOfBirth = new DateTime(1992, 1, 6)
        };
        
        return vPerson;
    }
}