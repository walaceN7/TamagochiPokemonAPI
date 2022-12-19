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
            return listaDePokemonsDisponiveis.Where(nome => nome == nomePokemon.ToUpper()).FirstOrDefault() != null ? true : false;
        }
    }
}
