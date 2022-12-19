using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagochiPokemonAPI.Models
{
    public class Pokemon
    {
        public List<Abilities> abilities { get; set; }
        public string name { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
    }
}
