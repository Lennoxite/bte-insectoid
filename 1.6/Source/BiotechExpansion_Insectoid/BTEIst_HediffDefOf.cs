using RimWorld;
using Verse;

namespace BTE_IST
{
	[DefOf]
	public static class BTEIst_HediffDefOf
	{
		static BTEIst_HediffDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(BTEIst_HediffDefOf));
		}

		public static HediffDef BTEIst_JellyEnergized;
        public static HediffDef BTEIst_GestatingInsectoid;


    }
}