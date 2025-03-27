using StarWars.Data;
using StarWars.Models;
using StarWars.Services.External;

namespace StarWars.Services;

public class StarWarsService(EfDbContext pContext, SwapiHttpClient pHttpClient)
{
    public static string GetJedi()
    {
        return "Obi-Wan Kenobi";
    }
    public async Task<List<PersonModel>> GetAllPeople(CancellationToken ct)
    {
        var vList = new List<PersonModel>();
        await foreach (var person in pHttpClient.GetAllDataFromEndpointAsync<PersonModel>("people", ct))
        {
            Console.WriteLine($"Name: {person.Name}");
            
            if (!string.IsNullOrEmpty(person.Homeworld))
            {
                person.HomeworldDetails = await pHttpClient.FetchResourceAsync<PlanetModel>(person.Homeworld, ct);
            }

            
            vList.Add(person);
        }

        return vList;
    }
}