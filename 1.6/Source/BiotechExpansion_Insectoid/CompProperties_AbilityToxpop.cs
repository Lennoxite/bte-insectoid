using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace BTE_IST
{
    public class CompProperties_AbilityToxpop : CompProperties_AbilityEffect
    {
        public float smokeRadius;
        public float jellyBuffFactor = 2f;
        public CompProperties_AbilityToxpop()
        {
            compClass = typeof(CompAbilityEffect_Toxpop);
        }
    }
}
