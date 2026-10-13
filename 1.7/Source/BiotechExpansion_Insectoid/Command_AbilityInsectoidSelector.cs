using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using UnityEngine;
using Verse.Sound;

namespace BTE_IST
{
    public class Command_AbilityInsectoidSelector : Command_Ability
    {
        private Event gizEv;
        public Command_AbilityInsectoidSelector(Ability ability, Pawn pawn) : base(ability, pawn)
        {

        }
        private IEnumerable<FloatMenuOption> FloatMenuOptions
        {
            get
            {
                CompAbilityEffect_InjectInsectoidEgg bugs = ability.CompOfType<CompAbilityEffect_InjectInsectoidEgg>();
                if (bugs != null)
                {
                    foreach (BTEIst_BugBodySizePair x in bugs.Props.pawnkindPairs)
                    {
                        yield return new FloatMenuOption(x.pawnkind.label + " (" + x.bodySize + ")", delegate
                        {
                            bugs.thisBug = x.pawnkind;
                            bugs.bodySizeNeeded = x.bodySize;
                            base.ProcessInput(gizEv);
                        }
                        );
                    }

                }
            }
        }

        public override void ProcessInput(Event ev)
        {
            if (CurActivateSound != null)
            {
                CurActivateSound.PlayOneShotOnCamera();
            }
            gizEv = ev;
            List<FloatMenuOption> list = new List<FloatMenuOption>();
            list.AddRange(FloatMenuOptions);
            Find.WindowStack.Add(new FloatMenu(list));
        }
    }
}
