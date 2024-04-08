using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
namespace BTE_IST
{
    public class CompAbilityEffect_CreateJelly : CompAbilityEffect
    {
        public new CompProperties_AbilityCreateJelly Props => (CompProperties_AbilityCreateJelly)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            CreateJelly();
        }

        public Thing CreateJelly()
        {
            var jelly = GenSpawn.Spawn(ThingDefOf.InsectJelly, parent.pawn.Position, parent.pawn.Map);
            jelly.stackCount = Props.amount;
            return jelly;

        }




    }
}
