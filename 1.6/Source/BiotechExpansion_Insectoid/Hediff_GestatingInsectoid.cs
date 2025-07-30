using RimWorld;
using UnityEngine;
using Verse;
using static UnityEngine.GraphicsBuffer;
using Verse.Sound;

namespace BTE_IST
{
    public class Hediff_GestatingInsectoid : HediffWithComps
    {
        public PawnKindDef bugSpawn = PawnKindDefOf.Megaspider;
        //public Pawn parent = null;
        public Faction parent = null;
        public override string Label
        {
            get
            {
                return LabelBase + BugType;
            }
        }

        private string bugType = null;

        public string BugType
        {
            get
            {
                if (bugType == null)
                {
                    if (parent != null)
                    {
                        if (parent == Faction.OfPlayer)
                            bugType = " [friendly " + bugSpawn.label + "]";
                    }
                    bugType = " [" + bugSpawn.label + "]";

                }

                return bugType;
            }
        }


        public override void PostAdd(DamageInfo? dinfo)
        {
            base.PostAdd(dinfo);
        }

        public override void TickInterval(int delta)
        {
            base.TickInterval(delta);

            if (Severity >= 1.0f)
            {
                if (pawn.Map != null)
                {
                    Faction newFaction = Faction.OfInsects;
                    if (parent != null)
                    {
                        newFaction = parent;
                    }
                    Pawn newPawn = PawnGenerator.GeneratePawn(new PawnGenerationRequest(bugSpawn, newFaction));
                    if (!GenAdj.TryFindRandomAdjacentCell8WayWithRoom(pawn.SpawnedParentOrMe, out var result))
                    {
                        result = pawn.PositionHeld;
                    }

                    Pawn finalPawn = (Pawn)GenSpawn.Spawn(newPawn, result, pawn.MapHeld);


                    IntVec3 positionHeld = pawn.PositionHeld;
                    Map mapHeld = pawn.MapHeld;
                    CellRect cellRect = new CellRect(positionHeld.x, positionHeld.z, 3, 3);
                    for (int i = 0; i < 5; i++)
                    {
                        IntVec3 randomCell = cellRect.RandomCell;
                        if (randomCell.InBounds(mapHeld) && GenSight.LineOfSight(randomCell, positionHeld, mapHeld))
                        {
                            FilthMaker.TryMakeFilth(randomCell, mapHeld, ThingDefOf.Filth_Blood);
                        }
                    }

                    if (newFaction == Faction.OfPlayer)
                    {

                        SoundDefOf.Designate_Tame.PlayOneShot(new TargetInfo(positionHeld, pawn.Map));
                    }
                    SoundDefOf.CocoonDestroyed.PlayOneShot(new TargetInfo(positionHeld, pawn.Map));

                    FleckMaker.AttachedOverlay(pawn, FleckDefOf.FlashHollow, new Vector3(0f, 0f, 0.26f));
                }    
             
                pawn.Kill(null);
                pawn.health.RemoveHediff(this);
            }    
        }


        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_References.Look(ref parent, "parent", false);
            Scribe_Defs.Look(ref bugSpawn, "bugSpawn");
        }
    }
}
    