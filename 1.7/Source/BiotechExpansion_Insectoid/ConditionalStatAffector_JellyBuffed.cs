using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
namespace BTE_IST
{
    public class ConditionalStatAffector_JellyBuffed : ConditionalStatAffecter // Not used since it might be rather expensive tps wise.
    {
        public override string Label
        {
            get
            {
                return "While Metabolizing Jelly";
            }
        }

        public override bool Applies(StatRequest req)
        {
            if (!ModsConfig.BiotechActive)
            {
                return false;
            }
            Pawn pawn;
            if (req.HasThing && (pawn = (req.Thing as Pawn)) != null)
            {
                if (pawn.health.hediffSet.HasHediff(BTEIst_HediffDefOf.BTEIst_JellyEnergized))
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
