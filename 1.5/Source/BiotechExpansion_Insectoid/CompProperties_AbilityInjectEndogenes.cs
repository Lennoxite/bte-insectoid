using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE_IST
{
    public class CompProperties_AbilityInjectEndogenes : CompProperties_AbilityEffect
    {
        public CompProperties_AbilityInjectEndogenes()
        {
            compClass = typeof(CompAbilityEffect_InjectEndogenes);
        }

        public List<XenotypeDef> xenotypes;
    }
}
