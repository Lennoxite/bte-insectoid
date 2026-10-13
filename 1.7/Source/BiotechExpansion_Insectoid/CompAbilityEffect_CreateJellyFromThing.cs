using RimWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace BTE_IST
{
    public class CompAbilityEffect_CreateJellyFromThing : CompAbilityEffect
    {
        public bool autoCastMe = false;

        public new CompProperties_AbilityCreateJellyFromThing Props => (CompProperties_AbilityCreateJellyFromThing)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            Thing jelly = CreateJelly(target.Thing);

            while (jelly.stackCount > jelly.def.stackLimit)
            {
                jelly.stackCount -= jelly.def.stackLimit;
                var nJelly = GenSpawn.Spawn(ThingDefOf.InsectJelly, parent.pawn.Position, parent.pawn.Map, WipeMode.VanishOrMoveAside);
                nJelly.stackCount = jelly.def.stackLimit;
            }

            target.Thing.Destroy();
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            Thing thing = target.Thing;
            if (thing == null)
            {
                return false;
            }
            if (!thing.def.IsNutritionGivingIngestible)
            {
                if (throwMessages)
                    Messages.Message("Target isn't an edible food.", thing, MessageTypeDefOf.RejectInput, historical: false);
                return false;
            }

            return base.Valid(target, throwMessages);
        }

        public Thing CreateJelly(Thing target)
        {
            float stack = Props.fraction*(target.stackCount * target.def.ingestible.CachedNutrition)/0.05f;

            var jelly = GenSpawn.Spawn(ThingDefOf.InsectJelly, parent.pawn.Position, parent.pawn.Map, WipeMode.VanishOrMoveAside);
            jelly.stackCount = Mathf.FloorToInt(stack);
            return jelly;

        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref autoCastMe, "autoCastJellyMaking", false);
        }



    }
}
