using RestSharp;
using System.Net.Http.Json;
using System.Text.Json;
using TamagochiPokemonAPI.Models;

namespace TamagochiPokemonAPI.Services
{
    public static class PokemonService
    {
        public static Pokemon BuscarPokemon(string nomePokemon)
        {
            //HttpClient client = new();
            //client.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
            //return await client.GetFromJsonAsync<Pokemon>($"{nomePokemon.ToLower()}");

            RestClient client = new($"https://pokeapi.co/api/v2/pokemon/{nomePokemon.ToLower()}");
            RestRequest request = new("", Method.Get);
            RestResponse response = client.Execute(request);

            return JsonSerializer.Deserialize<Pokemon>(response.Content);
        }        
    }
}
