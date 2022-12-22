using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiPokemonAPI.Models;
using TamagochiPokemonAPI.Services;

namespace TamagochiPokemonAPI.Views;

public class PokemonInterface
{
    private string NomeJogador { get; set; }
    public PokemonInterface()
    {
        BoasVindas();
    }

    public void BoasVindas()
    {
        Console.Clear();
        Console.WriteLine(@" 
     #######                                                                    
        #       ##    #    #    ##     ####    ####   #####   ####   #    #  # 
        #      #  #   ##  ##   #  #   #    #  #    #    #    #    #  #    #  # 
        #     #    #  # ## #  #    #  #       #    #    #    #       ######  # 
        #     ######  #    #  ######  #  ###  #    #    #    #       #    #  # 
        #     #    #  #    #  #    #  #    #  #    #    #    #    #  #    #  # 
        #     #    #  #    #  #    #   ####    ####     #     ####   #    #  #");

        Console.WriteLine("\n\nQual é seu name?");
        NomeJogador = Console.ReadLine().ToUpper();
    }

    public string MenuInicial()
    {
        Console.Clear();
        Console.WriteLine("===      MENU INICIAL    ===");
        Console.WriteLine($"{NomeJogador} você deseja:");
        Console.WriteLine("1 - Adotar um Pokemon");
        Console.WriteLine("2 - Ver seus Pokemons");
        Console.WriteLine("3 - Sair");

        Console.Write("\nOpção: ");
        return Console.ReadLine();
    }

    public void MenuAdocao(List<string> nomesPokemons)
    {
        Console.Clear();
        Console.WriteLine("===  Escolha um Pokemon  ===");
        foreach (string nome in nomesPokemons)
        {
            Console.WriteLine($"- {nome}");
        }
        Console.WriteLine("\n- VOLTAR");

        Console.Write("\nOpção: ");
    }

    public string MenuSaberMais(string pokemon)
    {
        Console.Clear();
        Console.WriteLine($"1 - INFORMAÇÕES DO {pokemon.ToUpper()}");
        Console.WriteLine($"2 - ADOTAR {pokemon.ToUpper()}");
        Console.WriteLine("3 - VOLTAR");
        Console.Write("\nOpção: ");

        return Console.ReadLine().ToUpper();
    }

    public void MenuDetalhesPokemon(Pokemon pokemon)
    {
        Console.Clear();
        Console.WriteLine($"Nome do Pokemon: {pokemon.name.ToUpper()}");
        Console.WriteLine($"Altura: {pokemon.height}");
        Console.WriteLine($"Peso: {pokemon.weight}");

        Console.WriteLine("\nHabilidades:");
        foreach (Abilities habilidade in pokemon.abilities)
        {
            Console.WriteLine(habilidade.ability.name.ToUpper());
        }

        Console.WriteLine("\n\nPrecione ENTER para VOLTAR");
        Console.ReadKey();
    }

    public void SucessoAdocao()
    {
        Console.Clear();
        Console.WriteLine($"{NomeJogador} Pokemon ADOTADO COM SUCESSO, O OVO ESTÁ CHOCANDO: ");

        Console.WriteLine(@"
              ███╗
             ██████╗
            ████████╗
            ████████║
            ████████║
            ╚█████╔╝
             ╚════╝");

        Console.WriteLine("\n\nPrecione ENTER para VOLTAR");
        Console.ReadKey();
    }

    public void MenuConsultarMascotes(List<Pokemon> pokemons)
    {
        int totalPokemon = pokemons.Count;


        Console.Clear();
        Console.WriteLine($"Você possui {totalPokemon} Pokemon adotados.");

        if (totalPokemon == 0)
        {
            Console.WriteLine("\nPRECIONE ENTER PARA VOLTAR");
            Console.ReadKey();
            return;
        }

        for (int indicePokemon = 0; indicePokemon < totalPokemon; indicePokemon++)
        {
            Console.WriteLine($"{indicePokemon} - {pokemons[indicePokemon].name.ToUpper()}");
        }

        Console.WriteLine($"Qual Pokemon você deseja interagir?");
        InteragirPokemon(pokemons[Convert.ToInt32(Console.ReadLine())]);
    }

    public void InteragirPokemon(Pokemon pokemon)
    {
        string opcao = "";
        Console.Clear();
        Console.WriteLine($"{NomeJogador} VOCÊ DESEJA:");
        Console.WriteLine($"1 - SABER COMO {pokemon.name.ToUpper()} ESTÁ");
        Console.WriteLine($"2 - ALIMENTAR O(A) {pokemon.name.ToUpper()}");
        Console.WriteLine($"3 - BRINCAR COM {pokemon.name.ToUpper()}");
        Console.WriteLine($"4 - FAZER O(A) {pokemon.name.ToUpper()} DORMIR");
        Console.WriteLine($"5 - VOLTAR");

        Console.Write("Sua escolha: ");
        opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                MenuDetalhesPokemonAdotado(pokemon);
                InteragirPokemon(pokemon);
                break;
            case "2":
                pokemon.AlimentarMascote();
                MenuDetalhesPokemonAdotado(pokemon);
                InteragirPokemon(pokemon);
                break;
            case "3":
                pokemon.BrincarMascote();
                MenuDetalhesPokemonAdotado(pokemon);
                InteragirPokemon(pokemon);
                break;
            case "4":
                pokemon.DormirMascote();
                MenuDetalhesPokemonAdotado(pokemon);
                InteragirPokemon(pokemon);
                break;
            case "5":
                break;
            default:
                break;
        }

    }

    public static void MenuDetalhesPokemonAdotado(Pokemon pokemon)
    {
        Console.Clear();
        Console.WriteLine($"Nome do Pokemon: {pokemon.name.ToUpper()}");
        Console.WriteLine($"Altura: {pokemon.height}");
        Console.WriteLine($"Peso: {pokemon.weight}");

        TimeSpan idade = DateTime.Now.Subtract(pokemon.DataNascimento);

        Console.WriteLine($"Idade: {idade.Minutes} Anos em Pokemon Virtual");

        pokemon.VerificarFome();

        pokemon.VerificarHumor();

        pokemon.VerificarSono();

        Console.WriteLine("\nHabilidades:");
        foreach (Abilities habilidade in pokemon.abilities)
        {
            Console.WriteLine(habilidade.ability.name.ToUpper());
        }

        Console.WriteLine("\n\nPrecione ENTER para VOLTAR");
        Console.ReadKey();
    }
}