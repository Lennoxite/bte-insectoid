using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using Verse.Sound;
using static UnityEngine.GraphicsBuffer;

namespace BTE_IST
{
    public class CompAbilityEffect_InjectInsectoidEgg : CompAbilityEffect
    {
        public new CompProperties_InjectInsectoidEgg Props => (CompProperties_InjectInsectoidEgg)props;


        public PawnKindDef thisBug = PawnKindDefOf.Megaspider;
        public float bodySizeNeeded = 1.0f;
        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            Pawn bug = target.Pawn;
            if (bug == null)
            {
                return false;
            }
            
            if (bug.BodySize < bodySizeNeeded)
            {
                if (throwMessages)
                    Messages.Message("Target isn't big enough.", null, MessageTypeDefOf.RejectInput, historical: false);

                return false;
            }

            return base.Valid(target, throwMessages);
        }
        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);

            SoundDefOf.Bloodfeed_Cast.PlayOneShot(new TargetInfo(target.Cell, parent.pawn.Map));
            FleckMaker.AttachedOverlay(target.Pawn, FleckDefOf.FlashHollow, new Vector3(0f, 0f, 0.26f));

            Hediff_GestatingInsectoid newBug = (Hediff_GestatingInsectoid)target.Pawn.health.AddHediff(BTEIst_HediffDefOf.BTEIst_GestatingInsectoid);

            newBug.parent = this.parent.pawn;
            newBug.bugSpawn = thisBug;


        }




    }
}
