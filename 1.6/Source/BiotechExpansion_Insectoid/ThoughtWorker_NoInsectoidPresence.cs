using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
namespace BTE_IST
{
    public class ThoughtWorker_NoInsectoidPresence : ThoughtWorker
	{
		protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
		{
			if (!other.RaceProps.Humanlike || other.Dead)
			{
				return false;
			}
			if (!RelationsUtility.PawnsKnowEachOther(pawn, other))
			{
				return false;
			}
			if (PawnHasInsectoidPresence(pawn)) //Pawn must NOT have gene to react this way.
			{
				return false;
			}
			if (!PawnHasInsectoidPresence(other))
            {
				return false;
            }
			if (PawnUtility.IsBiologicallyBlind(pawn))
			{
				return false;
			}
			if (pawn.story.traits.HasTrait(TraitDefOf.Kind) && !pawn.Inhumanized())
			{
				return false;
			}
			if (pawn.Ideo != null && pawn.Ideo.IdeoApprovesOfBlindness() && !RelationsUtility.IsDisfigured(other, pawn, true) && (PawnUtility.IsBiologicallyBlind(other) || ThoughtWorker_Precept_HalfBlind.IsHalfBlind(other)))
			{
				return false;
			}
			return true;
		}

		private bool PawnHasInsectoidPresence(Pawn pwn)
        {
			return pwn.genes.HasGene(BTEIst_GeneDefOf.BTEIst_InsectoidPresence);
        }
	}
}
