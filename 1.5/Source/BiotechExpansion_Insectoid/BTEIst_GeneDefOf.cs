using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BTE_IST
{
    [DefOf]
    public class BTEIst_GeneDefOf
    {
        static BTEIst_GeneDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(BTEIst_GeneDefOf));
        }

        public static GeneDef BTEIst_RapidEater;

    }
}
