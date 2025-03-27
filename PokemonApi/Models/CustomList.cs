using System.Collections;

namespace PokemonApi.Models;

public class CustomList : IEnumerable<CustomList>
{
    public IEnumerator<CustomList> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}