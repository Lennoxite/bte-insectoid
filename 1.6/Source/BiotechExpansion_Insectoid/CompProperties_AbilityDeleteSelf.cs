using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE_IST
{
    public class CompProperties_AbilityDeleteSelf : CompProperties_AbilityEffect
    {
        public CompProperties_AbilityDeleteSelf()
        {
            compClass = typeof(CompAbilityEffect_DeleteSelf);
        }

        public AbilityDef newerAbility;

    }
}
