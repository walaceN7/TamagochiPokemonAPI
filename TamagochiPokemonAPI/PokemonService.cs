using RestSharp;
using System.Text.Json;
using TamagochiPokemonAPI.Models;

namespace TamagochiPokemonAPI
{
    public static class PokemonService
    {
        public static Pokemon BuscarPokemon(string nomePokemon)
        {
            RestClient client = new($"https://pokeapi.co/api/v2/pokemon/{nomePokemon.ToLower()}");
            RestRequest request = new("", Method.Get);
            RestResponse response = client.Execute(request);

            return JsonSerializer.Deserialize<Pokemon>(response.Content);
        }

        public static bool ValidaNomePokemon(List<string> listaDePokemonsDisponiveis, string nomePokemon)
        {
            foreach (string nome in listaDePokemonsDisponiveis)
            {
                if (nomePokemon.Contains(nome, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            //if (!nomePokemon.Contains("BULBASAUR", StringComparison.InvariantCultureIgnoreCase) || !nomePokemon.Contains("CHARMANDER", StringComparison.InvariantCultureIgnoreCase)
            //    || !nomePokemon.Contains("SQUIRTLE", StringComparison.InvariantCultureIgnoreCase) || !nomePokemon.Contains("PIKACHU", StringComparison.InvariantCultureIgnoreCase))
            //{ 
            //    return false;
            //}
            return false;
        }
    }
}
