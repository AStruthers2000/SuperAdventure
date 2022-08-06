using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Potion : Item
    {
        public int AmountToHeal { get; set; }
        public Location TeleportLocation { get; set; }

        public Potion(int id, string name, string namePlural, int amountToHeal, int price, Location teleportLocation = null) : base(id, name, namePlural, price)
        {
            AmountToHeal = amountToHeal;
            TeleportLocation = teleportLocation;
        }
    }
}
