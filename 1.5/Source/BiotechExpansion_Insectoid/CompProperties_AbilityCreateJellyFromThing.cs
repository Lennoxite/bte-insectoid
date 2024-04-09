using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE_IST
{
    public class CompProperties_AbilityCreateJellyFromThing : CompProperties_AbilityEffect
    {
        //public int amount = 15;
        public float fraction = 0.6f;
        public CompProperties_AbilityCreateJellyFromThing()
        {
            compClass = typeof(CompAbilityEffect_CreateJellyFromThing);
        }
    }
}
