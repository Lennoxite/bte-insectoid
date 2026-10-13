using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BTE_IST
{
    public class CompProperties_AbilityLaunchProjectileJellyBuffable : CompProperties_AbilityEffect
    {
        public ThingDef projectileDef;
        public ThingDef jellyBuffProjectileDef;

        public CompProperties_AbilityLaunchProjectileJellyBuffable()
        {
            compClass = typeof(CompAbilityEffect_LaunchProjectileJellyBuffable);
        }
    }

}
