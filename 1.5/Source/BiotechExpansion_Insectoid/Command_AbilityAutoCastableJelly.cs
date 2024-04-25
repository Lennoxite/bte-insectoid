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
    public class Command_AbilityAutoCastableJelly : Command_Ability
    {
        protected CompAbilityEffect_CreateJellyFromThing comp;
        protected Rect autoRect;
        public Command_AbilityAutoCastableJelly(Ability ability, Pawn pawn) : base(ability, pawn)
        {
            comp = ability.CompOfType<CompAbilityEffect_CreateJellyFromThing>();
        }
        public override GizmoResult GizmoOnGUI(Vector2 topLeft, float maxWidth, GizmoRenderParms parms)
        {
            GizmoResult result = base.GizmoOnGUI(topLeft, maxWidth, parms);
            autoRect = new Rect(topLeft.x, topLeft.y, 24f, 24f);
            Widgets.DefIcon(autoRect, BTEIst_GeneDefOf.BTEIst_RapidEater);
            GUI.DrawTexture(new Rect(autoRect.center.x, autoRect.y, autoRect.width / 2f, autoRect.height / 2f), comp.autoCastMe ? Widgets.CheckboxOnTex : Widgets.CheckboxOffTex);
            if (Mouse.IsOver(autoRect))
            {
                Widgets.DrawHighlight(autoRect);
                string onOff = (comp.autoCastMe ? "On" : "Off");
                TooltipHandler.TipRegion(autoRect, () => "Auto cast for jelly transmutation. Will only target things with at least 9 total nutrition (like a full stack of meals or a giant corpse) and is restricted by food policies. Currently: " + onOff, 828267373);
            }
            return result;
        }


        protected override GizmoResult GizmoOnGUIInt(Rect butRect, GizmoRenderParms parms)
        {
            if (Widgets.ButtonInvisible(autoRect))
            {
                comp.autoCastMe = !comp.autoCastMe;
                if (comp.autoCastMe)
                {
                    SoundDefOf.Tick_High.PlayOneShotOnCamera();
                }
                else
                {
                    SoundDefOf.Tick_Low.PlayOneShotOnCamera();
                }
            }
            return base.GizmoOnGUIInt(butRect, parms);
        }

    }
}
