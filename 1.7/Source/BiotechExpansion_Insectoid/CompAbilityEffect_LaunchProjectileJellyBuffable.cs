using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BTE_IST
{
    public class CompAbilityEffect_LaunchProjectileJellyBuffable : CompAbilityEffect
    {
        public new CompProperties_AbilityLaunchProjectileJellyBuffable Props => (CompProperties_AbilityLaunchProjectileJellyBuffable)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            LaunchProjectile(target);
        }

        private void LaunchProjectile(LocalTargetInfo target)
        {
            if (Props.projectileDef != null)
            {
                Pawn pawn = parent.pawn;
                ThingDef t = Props.projectileDef;
                if (pawn.health.hediffSet.HasHediff(BTEIst_HediffDefOf.BTEIst_JellyEnergized))
                {
                    t = Props.jellyBuffProjectileDef;
                }
                ((Projectile)GenSpawn.Spawn(t, pawn.Position, pawn.Map)).Launch(pawn, pawn.DrawPos, target, target, ProjectileHitFlags.IntendedTarget);

            }
        }

        public override bool AICanTargetNow(LocalTargetInfo target)
        {
            return target.Pawn != null;
        }
    }

}
