using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BTE_IST
{
    public class CompProperties_NeedsJelly : CompProperties_AbilityEffect
    {
        public CompProperties_NeedsJelly()
        {
            compClass = typeof(CompAbilityEffect_NeedsJelly);
        }
    }
}
