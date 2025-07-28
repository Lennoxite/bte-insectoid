using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BTE_IST
{
    public class CompProperties_InjectInsectoidEgg : CompProperties_AbilityEffect
    {
        public CompProperties_InjectInsectoidEgg()
        {
            compClass = typeof(CompAbilityEffect_InjectInsectoidEgg);
        }

        public List<BTEIst_BugBodySizePair> pawnkindPairs;
    }
}
