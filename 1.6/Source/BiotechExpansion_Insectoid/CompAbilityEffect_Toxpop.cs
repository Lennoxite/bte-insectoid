using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
namespace BTE_IST
{
    public class CompAbilityEffect_Toxpop : CompAbilityEffect
    {
        public new CompProperties_AbilityToxpop Props => (CompProperties_AbilityToxpop)props;

        public bool ShouldHaveInspectString
        {
            get
            {
                if (ModsConfig.BiotechActive)
                {
                    return parent.pawn.RaceProps.IsMechanoid;
                }
                return false;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            float JellyFactor = 1f;
            if (parent.pawn.health.hediffSet.HasHediff(BTEIst_HediffDefOf.BTEIst_JellyEnergized))
            {
                JellyFactor = Props.jellyBuffFactor;
            }
            GenExplosion.DoExplosion(target.Cell, parent.pawn.MapHeld, Props.smokeRadius*JellyFactor, DamageDefOf.Smoke, null, -1, -1f, null, null, null, null, null, 0f, 1, GasType.ToxGas);
        }

        public override void DrawEffectPreview(LocalTargetInfo target)
        {
            GenDraw.DrawRadiusRing(target.Cell, Props.smokeRadius);
        }

        public override string CompInspectStringExtra()
        {
            if (ShouldHaveInspectString)
            {
                if (parent.CanCast)
                {
                    return "AbilityMechSmokepopCharged".Translate();
                }
                return "AbilityMechSmokepopRecharging".Translate(parent.CooldownTicksRemaining.ToStringTicksToPeriod());
            }
            return null;
        }



    }
}
