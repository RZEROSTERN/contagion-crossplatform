using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contagion_CrossPlatform
{
    class PowerUps
    {
        public PowerUps() { }
    }

    class PlasmaPowerUp : PowerUps
    {
        public PlasmaPowerUp() { }

        public static void AssignPowerUp(Hero hero, Tiles tile)
        {
            if(tile.Active == true)
            {
                if (hero.SpecialAmmo == 0)
                    hero.SpecialAmmo = 100;
                else
                    hero.SpecialAmmo = hero.SpecialAmmo + 100;

                hero.HasSpecialAmmo = true;
            }

            tile.Active = false;
        }
    }

    class OneUpPowerUp : PowerUps
    {
        public OneUpPowerUp() { }

        public static void OneUp(Hero hero, Tiles tile)
        {
            if(tile.Active == true)
                hero.Lives = hero.Lives + 1;

            tile.Active = false;
        }
    }
}
