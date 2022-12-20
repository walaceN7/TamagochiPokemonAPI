using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagochiPokemonAPI.Models;

namespace TamagochiPokemonAPI;

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

    public string MenuAdocao(List<string> nomesPokemons)
    {
        Console.Clear();
        Console.WriteLine("===  Escolha um Pokemon  ===");
        foreach (string nome in nomesPokemons)
        {
            Console.WriteLine($"- {nome}");
        }
        Console.WriteLine("\n- VOLTAR");

        Console.Write("\nOpção: ");
        return Console.ReadLine();
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

    public void MenuDetalhesPokemonAdotado(Pokemon pokemon)
    {
        Console.Clear();
        Console.WriteLine($"Nome do Pokemon: {pokemon.name.ToUpper()}");
        Console.WriteLine($"Altura: {pokemon.height}");
        Console.WriteLine($"Peso: {pokemon.weight}");

        TimeSpan idade = DateTime.Now.Subtract(pokemon.DataNascimento);

        Console.WriteLine($"Idade: {idade.Minutes} Anos em Pokemon Virtual");

        if (pokemon.VerificarFome())
            Console.WriteLine($"{pokemon.name.ToUpper()} Está com fome!");
        else
            Console.WriteLine($"{pokemon.name.ToUpper()} Está alimentado!");

        if (pokemon.Humor > 5)
            Console.WriteLine($"{pokemon.name.ToUpper()} Está feliz!");
        else
            Console.WriteLine($"{pokemon.name.ToUpper()} Está triste!");

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

    public int MenuConsultarMascotes(List<Pokemon> Pokemons)
    {
        Console.Clear();
        Console.WriteLine($"Você possui {Pokemons.Count} Pokemon adotados.");
        
        for (int indicePokemon = 0; indicePokemon < Pokemons.Count; indicePokemon++)
        {
            Console.WriteLine($"{indicePokemon} - {Pokemons[indicePokemon].name.ToUpper()}");
        }

        Console.WriteLine($"Qual Pokemon você deseja interagir?");
        return Convert.ToInt32(Console.ReadLine());
    }
}