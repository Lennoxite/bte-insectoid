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
			if (thing.def == ThingDefOf.InsectJelly)
			{
				this.pawn.health.AddHediff(BTEIst_HediffDefOf.BTEIst_JellyEnergized);
			}	
		}
	}
}
