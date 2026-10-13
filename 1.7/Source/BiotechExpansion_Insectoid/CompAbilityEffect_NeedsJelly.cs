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
    public class CompAbilityEffect_NeedsJelly : CompAbilityEffect
    {
        public new CompProperties_NeedsJelly Props
        {
            get
            {
                return (CompProperties_NeedsJelly)this.props;
            }
        }



        public override bool CanCast
        {
            get
            {
                return this.parent.pawn.health.hediffSet.HasHediff(BTEIst_HediffDefOf.BTEIst_JellyEnergized) && base.CanCast;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
        }

        public override bool GizmoDisabled(out string reason)
        {

            if (!this.parent.pawn.health.hediffSet.HasHediff(BTEIst_HediffDefOf.BTEIst_JellyEnergized))
            {

                reason = "Ability Disabled: Not metabolizing jelly.";
                return true;
            }

            reason = null;
            return false;
        }

        public override bool AICanTargetNow(LocalTargetInfo target)
        {
            return this.CanCast;
        }

    }
}
