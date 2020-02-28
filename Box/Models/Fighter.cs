using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box.Models
{
    public class Fighter: BaseHuman
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Health { get; set; }
        public int MaxDamage { get; set; }
    }
}
