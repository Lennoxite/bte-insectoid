using System;
using RimWorld;
using Verse;


namespace BTE_IST
{
    public class HediffComp_HediffOnRemovalWithJelly : HediffComp
    {
        public HediffCompProperties_HediffOnRemovalWithJelly Props
        {
            get
            {
                return (HediffCompProperties_HediffOnRemovalWithJelly)this.props;
            }
        }

        public override void CompPostPostRemoved()
        {
            if (this.parent.pawn.health.hediffSet.HasHediff(BTEIst_HediffDefOf.BTEIst_JellyEnergized))
            {
                if (Props.withJelly != null)
                {
                    this.parent.pawn.health.AddHediff(Props.withJelly);
                }
            }
            else
            {
                if (Props.withoutJelly != null)
                {
                    this.parent.pawn.health.AddHediff(Props.withoutJelly);
                }

            }

        }

    }
}
