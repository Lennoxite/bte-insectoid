using System;
using System.Collections.Generic;
using Verse;
using RimWorld;
namespace BTE_IST
{

    public class HediffCompProperties_HediffOnRemovalWithJelly : HediffCompProperties
    {

        public HediffCompProperties_HediffOnRemovalWithJelly()
        {
            this.compClass = typeof(HediffComp_HediffOnRemovalWithJelly);
        }


        public HediffDef withoutJelly = null;
        public HediffDef withJelly = null;

    }
}