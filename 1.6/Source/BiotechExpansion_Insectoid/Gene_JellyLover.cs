using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace BTE_IST
{
	class Gene_JellyLover : Gene
	{
		public override void Notify_IngestedThing(Thing thing, int numTaken)
		{
			HediffDef hediff = BTEIst_HediffDefOf.BTEIst_JellyEnergized;
			GeneJellyHediffGiver modE = def.GetModExtension<GeneJellyHediffGiver>();
			if (modE != null)
			{
				hediff = modE.hediff;
			}	

            if (thing.def == ThingDefOf.InsectJelly)
			{
				Hediff he = this.pawn.health.GetOrAddHediff(hediff);
				he.Severity += numTaken * 0.05f;
			}	
		}
	}
}
