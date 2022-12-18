using Newtonsoft.Json.Linq;
using RestSharp;

Console.WriteLine("===  BEM-VINDO AO TAMAGOCHI POKEMON  ===");
Console.Write("--- Escolha um Pokemon pelo seu id: ");
int id = int.Parse(Console.ReadLine());
Console.WriteLine();

InvocarGet(id);

static void InvocarGet(int id)
{
    if (id > 0)
    {
        RestClient client = new($"https://pokeapi.co/api/v2/pokemon-form/{id}");
        RestRequest request = new("", Method.Get);
        RestResponse response = client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            JObject parsed = JObject.Parse(response.Content);

            foreach (var pair in parsed)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
        else
        {
            Console.WriteLine(response.ErrorMessage);
        }
        Console.ReadKey();
    }    
}
