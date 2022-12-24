using TamagochiPokemonAPI.Models;

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

    public void MenuDetalhesPokemon(Mascote pokemon)
    {
        Console.Clear();
        Console.WriteLine(pokemon.ToString());

        ListarHabilidades(pokemon);

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

    public int MenuConsultarMascotes(List<Mascote> pokemons)
    {
        int totalPokemon = pokemons.Count;

        Console.Clear();
        Console.WriteLine($"Você possui {totalPokemon} Pokemon adotados.");

        if (totalPokemon == 0)
        {
            Console.WriteLine("\nPRECIONE ENTER PARA VOLTAR");
            Console.ReadKey();
            return -1;
        }

        for (int indicePokemon = 0; indicePokemon < totalPokemon; indicePokemon++)
        {
            Console.WriteLine($"{indicePokemon} - {pokemons[indicePokemon].Nome.ToUpper()}");
        }

        Console.WriteLine($"Qual Pokemon você deseja interagir?");

        int escolha = int.Parse(Console.ReadLine());

        if (escolha < 0 || escolha >= totalPokemon)
        {
            Console.WriteLine("\nOPÇÃO INVÁLIDA, PRESSIONE ENTER PARA VOLTAR");
            Console.ReadKey();
            return -1;
        }

        return escolha;
    }

    public void InteragirPokemon(Mascote pokemon)
    {
        string opcao = "";
        Console.Clear();
        Console.WriteLine($"{NomeJogador} VOCÊ DESEJA:");
        Console.WriteLine($"1 - SABER COMO {pokemon.Nome.ToUpper()} ESTÁ");
        Console.WriteLine($"2 - ALIMENTAR O(A) {pokemon.Nome.ToUpper()}");
        Console.WriteLine($"3 - BRINCAR COM {pokemon.Nome.ToUpper()}");
        Console.WriteLine($"4 - VOLTAR");

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

                if (!pokemon.SaudeMascote())
                {
                    GameOver(pokemon);
                }

                MenuDetalhesPokemonAdotado(pokemon);
                InteragirPokemon(pokemon);
                break;
            case "3":
                pokemon.BrincarMascote();

                if (!pokemon.SaudeMascote())
                {
                    GameOver(pokemon);
                }

                MenuDetalhesPokemonAdotado(pokemon);
                InteragirPokemon(pokemon);
                break;
            case "4":
                break;
            default:
                break;
        }

    }

    public static void MenuDetalhesPokemonAdotado(Mascote pokemon)
    {
        Console.Clear();
        Console.WriteLine(pokemon.ToString());

        TimeSpan idade = DateTime.Now.Subtract(pokemon.DataNascimento);

        Console.WriteLine($"Idade: {idade.Minutes} Anos em Pokemon Virtual\n");

        pokemon.VerificarFome();

        pokemon.VerificarHumor();

        ListarHabilidades(pokemon);

        Console.WriteLine("\n\nPrecione ENTER para VOLTAR");
        Console.ReadKey();
    }

    public void GameOver(Mascote mascote)
    {
        Console.WriteLine("\n-------------------------------------------------------------");
        Console.WriteLine("O mascote morreu de " + (mascote.Humor > 0 ? "fome" : "tristeza"));

        Console.WriteLine(@"
              #####      #     #     #  #######      #######  #     #  #######  ######  
             #     #    # #    ##   ##  #            #     #  #     #  #        #     # 
             #         #   #   # # # #  #            #     #  #     #  #        #     # 
             #  ####  #     #  #  #  #  #####        #     #  #     #  #####    ######  
             #     #  #######  #     #  #            #     #   #   #   #        #   #   
             #     #  #     #  #     #  #            #     #    # #    #        #    #  
              #####   #     #  #     #  #######      #######     #     #######  #     # ");
    }

    public static void ListarHabilidades(Mascote pokemon)
    {
        Console.WriteLine("\nHabilidades:");
        foreach (Abilities habilidade in pokemon.Habilidades)
        {
            Console.WriteLine(habilidade.ability.name.ToUpper());
        }
    }
}