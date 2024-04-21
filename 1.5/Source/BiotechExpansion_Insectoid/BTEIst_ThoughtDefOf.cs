using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;

namespace BTE_IST
{


    [DefOf]
    public static class BTEIst_ThoughtDefOf
    {
        static BTEIst_ThoughtDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(BTEIst_ThoughtDefOf));
        }

        public static ThoughtDef BTEIst_TransformedIntoBug;
    }
}
