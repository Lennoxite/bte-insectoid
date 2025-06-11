using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BTE_IST
{
    public class CompAbilityEffect_DeleteSelf : CompAbilityEffect
    {
        public new CompProperties_AbilityDeleteSelf Props => (CompProperties_AbilityDeleteSelf)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
           if (this.parent.pawn.abilities.GetAbility(this.Props.newerAbility) != null)
            {
                this.parent.pawn.abilities.RemoveAbility(this.parent.def);
            }    

        }




    }
}
