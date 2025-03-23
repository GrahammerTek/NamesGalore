using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace NamesGalore
{
	[HarmonyPatch(typeof(PawnBioAndNameGenerator), "TryGetRandomUnusedSolidBioFor")]
	public class PawnBioAndNameGenerator_TryGetRandomUnusedSolidBioFor
	{
		public static void Postfix(ref PawnBio result, ref bool __result)
		{
			if (__result && result != null && !Prefs.PreferredNames.Contains(result.name.ToStringFull))
			{
				result = null;
				__result = false;
			}
		}
	}
	[HarmonyPatch(typeof(PawnBioAndNameGenerator), "TryGetRandomUnusedSolidName")]
	public class PawnBioAndNameGenerator_TryGetRandomUnusedSolidName
	{
		public static void Postfix(ref NameTriple __result)
		{
			if (__result != null && !Prefs.PreferredNames.Contains(__result.ToStringFull))
			{
				__result = null;
			}
		}
	}
}
