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
    public class Command_AbilityXenotypeSelector : Command_Ability
    {
        private Event gizEv;
        public Command_AbilityXenotypeSelector(Ability ability, Pawn pawn) : base(ability, pawn)
        {

        }
        private IEnumerable<FloatMenuOption> FloatMenuOptions
        {
            get
            {
                CompAbilityEffect_InjectEndogenes xenos = ability.CompOfType<CompAbilityEffect_InjectEndogenes>();
                if (xenos != null)
                {
                    foreach (XenotypeDef x in xenos.Props.xenotypes)
                    {
                        yield return new FloatMenuOption(x.label, delegate
                        {
                            xenos.selectedXenotype = x;
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
