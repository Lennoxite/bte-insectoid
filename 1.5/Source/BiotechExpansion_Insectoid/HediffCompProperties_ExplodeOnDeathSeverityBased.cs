using System;
using System.Collections.Generic;
using Verse;
using RimWorld;
namespace BTE_IST
{

	public class HediffCompProperties_ExplodeOnDeathSeverityBased : HediffCompProperties
	{

		public HediffCompProperties_ExplodeOnDeathSeverityBased()
		{
			this.compClass = typeof(HediffComp_ExplodeOnDeathSeverityBased);
		}


		public float radiusAtHalf = 4;
		public DamageDef damageType = null;

	}
}