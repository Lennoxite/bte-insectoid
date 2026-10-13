using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace BTE_IST
{
    public class CompAbilityEffect_InjectEndogenes : CompAbilityEffect
    {
        public new CompProperties_AbilityInjectEndogenes Props => (CompProperties_AbilityInjectEndogenes)props;


        public XenotypeDef selectedXenotype;

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            Pawn bug = target.Pawn;
            if (bug == null)
            {
                return false;
            }
            if (!AbilityUtility.ValidateMustBeHuman(bug, throwMessages, this.parent))
            {
                return false;
            }

            return base.Valid(target, throwMessages);
        }
        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            XenotypeDef iX = target.Pawn.genes.Xenotype;
            for (var i = target.Pawn.genes.Endogenes.Count - 1; i >= 0; --i)
            {
                target.Pawn.genes.RemoveGene(target.Pawn.genes.Endogenes[i]);
            }
            target.Pawn.genes.SetXenotype(selectedXenotype);
            target.Pawn.health.AddHediff(HediffDefOf.XenogerminationComa);
            bool wasAlreadyBug = false;
            foreach (XenotypeDef x in Props.xenotypes)
            {
                if (iX == x)
                {
                    wasAlreadyBug = true;
                }
            }
            if (!wasAlreadyBug)
                target.Pawn.needs.mood.thoughts.memories.TryGainMemory(BTEIst_ThoughtDefOf.BTEIst_TransformedIntoBug);

            SoundDefOf.Designate_Tame.PlayOneShot(new TargetInfo(target.Cell, parent.pawn.Map));
            FleckMaker.AttachedOverlay(target.Pawn, FleckDefOf.FlashHollow, new Vector3(0f, 0f, 0.26f));


            Ability ab = target.Pawn.abilities.GetAbility(BTEIst_AbilityDefOf.BTEIst_InjectInsectoidGenes);
            if (ab != null)
            {
                ab.StartCooldown(900000);
            }
        }




    }
}
