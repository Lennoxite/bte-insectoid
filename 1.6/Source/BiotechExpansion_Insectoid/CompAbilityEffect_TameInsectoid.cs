using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using Verse.Sound;
using static UnityEngine.GraphicsBuffer;

namespace BTE_IST
{
    public class CompAbilityEffect_TameInsectoid : CompAbilityEffect
    {
        public new CompProperties_AbilityTameInsectoid Props => (CompProperties_AbilityTameInsectoid)props;

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            Pawn bug = target.Pawn;
            if (bug == null)
            {
                return false;
            }
            if (!AbilityUtility.ValidateMustBeAnimal(bug, throwMessages, parent))
            {
                return false;
            }
            if (!bug.RaceProps.Insect)
            {
                if (throwMessages)
                    Messages.Message("Target isn't an insect.", bug, MessageTypeDefOf.RejectInput, historical: false);
                return false;
            }

            return base.Valid(target, throwMessages);
        }
        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            target.Pawn.SetFaction(Faction.OfPlayer);
            SoundDefOf.Designate_Tame.PlayOneShot(new TargetInfo(target.Cell, parent.pawn.Map));
            
        }




    }
}
