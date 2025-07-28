using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;

namespace BTE_IST
{


    [DefOf]
    public static class BTEIst_AbilityDefOf
    {
        static BTEIst_AbilityDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(BTEIst_AbilityDefOf));
        }

        public static AbilityDef BTEIst_InjectInsectoidGenes;
        public static AbilityDef BTEIst_JellyTransmutationer; 
        public static AbilityDef BTEIst_InjectInsectoidEgg;
    }
}
