using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace BTE_IST
{
    public class CompProperties_AbilityCreateJelly : CompProperties_AbilityEffect
    {
        public int amount = 15;
        public CompProperties_AbilityCreateJelly()
        {
            compClass = typeof(CompAbilityEffect_CreateJelly);
        }
    }
}
