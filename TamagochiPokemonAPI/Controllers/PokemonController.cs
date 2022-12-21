using TamagochiPokemonAPI.Models;
using TamagochiPokemonAPI.Services;
using TamagochiPokemonAPI.Views;

namespace TamagochiPokemonAPI.Controllers;

public class PokemonController
{
    List<Pokemon> pokemons { get; set; }
    PokemonInterface menu { get; set; }
    int escolha;

    public PokemonController()
    {
        pokemons = new();
        menu = new();
    }

    public void Jogar()
    {
        bool jogar = true;
        string opcao;

        while (jogar)
        {
            opcao = menu.MenuInicial();

            switch (opcao)
            {
                case "1":
                    opcao = MenuAdocaoIniciar();
                    break;
                case "2":
                    menu.MenuConsultarMascotes(pokemons);
                    break;
                case "3":
                    jogar = false;
                    break;
                default:
                    Console.WriteLine("OPÇÃO INVÁLIDA");
                    break;
            }
        }
    }

    public string MenuAdocaoIniciar()
    {
        bool nomeValido = false;
        bool continua = true;
        string opcaoSub = "";
        List<string> nomesDisponiveis = new() { "BULBASAUR", "CHARMANDER", "SQUIRTLE", "PIKACHU" };

        while (!nomeValido)
        {
            menu.MenuAdocao(nomesDisponiveis);
            opcaoSub = Console.ReadLine();

            if (opcaoSub.ToUpper() == "VOLTAR")
            {
                return "3";
            }

            nomeValido = ValidaNomePokemon(nomesDisponiveis, opcaoSub);

            if (!nomeValido)
            {
                Console.WriteLine("\nPOKEMON INVALIDO, ESCOLHA UM DAS LISTAS, OU ESCOLHA VOLTAR\nPRESSIONE ENTER PARA TENTAR NOVAMENTE");
                Console.ReadKey();
            }
        }

        while (continua)
        {
            Pokemon pokemon = new();

            string opcaoSubMenu = menu.MenuSaberMais(opcaoSub);

            if (opcaoSubMenu.Equals("1") || opcaoSubMenu.Equals("2"))
            {
                pokemon = PokemonService.BuscarPokemon(opcaoSub);
            }

            switch (opcaoSubMenu)
            {
                case "1":
                    menu.MenuDetalhesPokemon(pokemon);
                    break;

                case "2":
                    pokemons.Add(pokemon);
                    menu.SucessoAdocao();

                    return "3";

                case "3":
                    return "3";
                default:
                    Console.WriteLine("OPÇÃO INVÁLIDA");
                    break;
            }
        }

        return "3";
    }

    public static bool ValidaNomePokemon(List<string> listaDePokemonsDisponiveis, string nomePokemon)
    {
        return listaDePokemonsDisponiveis.FirstOrDefault(nome => nome == nomePokemon.ToUpper()) != null ? true : false;
    }
}
