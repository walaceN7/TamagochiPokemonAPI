
namespace TamagochiPokemonAPI.Models;

public class Mascote
{
    public List<Abilities> Habilidades { get; set; }
    public string Nome { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }
    public int Alimentacao { get; set; }
    public int Humor { get; set; }
    public int Sono { get; set; }
    public DateTime DataNascimento { get; set; }

    public Mascote()
    {
        Random valorRandomico = new();
        Alimentacao = valorRandomico.Next(2, 10);
        Humor = valorRandomico.Next(2, 10);
        Sono = valorRandomico.Next(2, 10);
        DataNascimento = DateTime.Now;
    }

    public void VerificarFome()
    {
        if (Alimentacao <= 3 && Alimentacao > 0)
        {
            Console.WriteLine($"{Nome.ToUpper()} está com MUITA FOME");
        }
        else if (Alimentacao > 3 && Alimentacao <= 6)
        {
            Console.WriteLine($"{Nome.ToUpper()} está com FOME");
        }
        else
        {
            Console.WriteLine($"{Nome.ToUpper()} está SEM FOME");
        }
    }
    public void AlimentarMascote()
    {
        this.Alimentacao++;
    }

    public void VerificarHumor()
    {
        if (Humor <= 3 && Humor > 0)
        {
            Console.WriteLine($"{Nome.ToUpper()} está MUITO TRISTE");
        }
        else if (Humor > 3 && Humor <= 5)
        {
            Console.WriteLine($"{Nome.ToUpper()} está TRISTE");
        }
        else if (Humor > 5 && Humor <= 7)
        {
            Console.WriteLine($"{Nome.ToUpper()} está FELIZ");
        }
        else
        {
            Console.WriteLine($"{Nome.ToUpper()} está MUITO FELIZ");
        }
    }

    public void BrincarMascote()
    {
        Humor++;
        Alimentacao--;
    }

    public void VerificarSono()
    {
        if (Sono <= 3 && Sono > 0)
        {
            Console.WriteLine($"{Nome.ToUpper()} está com MUITO SONO");
        }
        else if (Sono > 3 && Sono <= 5)
        {
            Console.WriteLine($"{Nome.ToUpper()} está com SONO");
        }
        else
        {
            Console.WriteLine($"{Nome.ToUpper()} está DESCANSADO");
        }

    }

    public void DormirMascote()
    {
        Sono++;
        Humor++;
        Alimentacao--;
    }

    public bool SaudeMascote()
    {
        return (this.Alimentacao > 0 && this.Humor > 0);
    }
}
