using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse.AI;
using Verse;

namespace BTE_IST
{
    public class JobGiver_TransmuteFood : ThinkNode_JobGiver
    {

        public bool forceScanWholeMap;

        public override float GetPriority(Pawn pawn)
        {
            Ability ab = pawn.abilities.GetAbility(BTEIst_AbilityDefOf.BTEIst_JellyTransmutationer);
            if (ab == null) // Ability not found.
                return 0f;

            if (!ab.CanCast) // Ability must be castable now.
            {
                return 0f;
            }

            if (!ab.CompOfType<CompAbilityEffect_CreateJellyFromThing>().autoCastMe)  // Ability must have autocast set up.
                return 0f;

                return 8f;
        }
        protected override Job TryGiveJob(Pawn pawn)
        {
            Ability ab = pawn.abilities.GetAbility(BTEIst_AbilityDefOf.BTEIst_JellyTransmutationer);
            if (ab == null) // Ability not found.
                return null;
            CompAbilityEffect_CreateJellyFromThing abComp = ab.CompOfType<CompAbilityEffect_CreateJellyFromThing>();
            if (!abComp.autoCastMe) // Ability must have autocast set up.
            {
                return null;
            }
            if (!ab.CanCast) // Ability must be castable now.
            {
                return null;
            }

            FoodPreferability foodPreferability = FoodPreferability.DesperateOnly;
            Thing fd = FoodUtility.BestFoodSourceOnMap(pawn, pawn, true, out var foodDef, FoodPreferability.MealLavish, false, false, true, false, false, false, false, false, false, false, false, foodPreferability, 9f, false);
            if (fd == null)
            {
                return null;
            }
            else
            {
                return ab.GetJob(fd, fd);
            }
        }

    }
}
