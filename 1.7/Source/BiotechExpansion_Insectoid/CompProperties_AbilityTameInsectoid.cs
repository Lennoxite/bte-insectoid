using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace BTE_IST
{
    public class CompProperties_AbilityTameInsectoid : CompProperties_AbilityEffect
    {
        public CompProperties_AbilityTameInsectoid()
        {
            compClass = typeof(CompAbilityEffect_TameInsectoid);
        }
    }
}
