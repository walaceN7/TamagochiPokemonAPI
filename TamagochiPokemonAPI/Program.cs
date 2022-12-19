using TamagochiPokemonAPI;
using TamagochiPokemonAPI.Models;

bool jogar = true;
string opcao;

while (jogar)
{
    List<Pokemon> pokemons = new();
    Console.Clear();
    Console.WriteLine("===  BEM-VINDO AO TAMAGOCHI POKEMON  ===");
    Console.WriteLine("1 - Adotar um Pokemon");
    Console.WriteLine("2 - Sair");
    Console.Write("\nEscolha uma opção: ");
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Pokemon pokemon = new();
            List<string> nomesDisponiveis = new() { "BULBASAUR", "CHARMANDER", "SQUIRTLE", "PIKACHU" };
            string nomePokemon = "";
            bool nomeValido = false;

            while (!nomeValido)
            {
                Console.Clear();
                Console.WriteLine("===  Escolha um Pokemon  ===");
                foreach (string nome in nomesDisponiveis)
                {
                    Console.WriteLine($"- {nome}");
                }
                Console.WriteLine("\n- VOLTAR");

                Console.Write("\nNome do Pokemon: ");
                nomePokemon = Console.ReadLine();

                if (nomePokemon.ToUpper() == "VOLTAR")
                {
                    opcao = "2";
                    break;
                }
                nomeValido = PokemonService.ValidaNomePokemon(nomesDisponiveis, nomePokemon);

                if (!nomeValido)
                {
                    Console.WriteLine("\nPOKEMON INVALIDO, ESCOLHA UM DAS LISTAS\nPRESSIONE ENTER PARA TENTAR NOVAMENTE");
                    Console.ReadKey();
                }
            }

            while (opcao != "2")
            {
                Console.Clear();
                Console.WriteLine($"1 - INFORMAÇÕES DO {nomePokemon.ToUpper()}");
                Console.WriteLine($"2 - ADOTAR {nomePokemon.ToUpper()}");
                Console.WriteLine("3 - VOLTAR");

                Console.Write("\nOpção: ");
                string opcaoSubMenu = Console.ReadLine();

                if (opcaoSubMenu.Equals("1") || opcaoSubMenu.Equals("2"))
                {
                    pokemon = PokemonService.BuscarPokemon(nomePokemon);
                }

                switch (opcaoSubMenu)
                {
                    case "1":
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
                        break;

                    case "2":
                        pokemons.Add(pokemon);

                        Console.Clear();
                        Console.WriteLine("POKEMON ADOTADO COM SUCESSO, O OVO ESTÁ CHOCANDO");
                        opcao = "2";

                        Console.WriteLine("\n\nPrecione ENTER para VOLTAR");
                        Console.ReadKey();
                        break;

                    case "3":
                        opcao = "2";
                        break;
                    default:
                        Console.WriteLine("OPÇÃO INVÁLIDA");
                        break;
                }
            }
            break;

        case "2":
            jogar = false;
            break;
        default:
            Console.WriteLine("OPÇÃO INVÁLIDA");
            break;
    }

}
