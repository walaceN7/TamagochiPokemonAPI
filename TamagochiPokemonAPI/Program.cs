using TamagochiPokemonAPI;
using TamagochiPokemonAPI.Models;

List<Pokemon> pokemons = new();
PokemonInterface menu = new();

bool jogar = true;
string opcao;

while (jogar)
{
    opcao = menu.MenuInicial();

    switch (opcao)
    {
        case "1":
            Pokemon pokemon = new();
            List<string> nomesDisponiveis = new() { "BULBASAUR", "CHARMANDER", "SQUIRTLE", "PIKACHU" };
            bool nomeValido = false;
            string opcaoSub = "";

            while (!nomeValido)
            {
                opcaoSub = menu.MenuAdocao(nomesDisponiveis);

                if (opcaoSub.ToUpper() == "VOLTAR")
                {
                    opcao = "3";
                    break;
                }

                nomeValido = PokemonService.ValidaNomePokemon(nomesDisponiveis, opcaoSub);

                if (!nomeValido)
                {
                    Console.WriteLine("\nPOKEMON INVALIDO, ESCOLHA UM DAS LISTAS, OU ESCOLHA VOLTAR\nPRESSIONE ENTER PARA TENTAR NOVAMENTE");
                    Console.ReadKey();
                }
            }

            while (opcao != "3")
            {
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
                        
                        opcao = "3";                        
                        break;

                    case "3":
                        opcao = "3";
                        break;
                    default:
                        Console.WriteLine("OPÇÃO INVÁLIDA");
                        break;
                }
            }
            break;
        case "2":
            menu.MenuConsultarMascotes(pokemons);
            //interação
            break;
        case "3":
            jogar = false;
            break;
        default:
            Console.WriteLine("OPÇÃO INVÁLIDA");
            break;
    }

}
