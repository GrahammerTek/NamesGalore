using Verse;
using UnityEngine;

namespace NamesGalore
{
    public class NamesGaloreSettings : ModSettings
    {

        public string rootDir; // NOTE: no need to expose
        public bool international = false;
        public bool logging = false;
        public bool removeDefaultNames = false;
      
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref international, "international", false);
            Scribe_Values.Look(ref logging, "logging", false);
            Scribe_Values.Look(ref removeDefaultNames, "removeDefaultNames", false);
        }
    }

    class NamesGaloreMod : Mod
    {
        public static NamesGaloreSettings settings;

        public NamesGaloreMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<NamesGaloreSettings>();
        }

        public override string SettingsCategory() => "NG_SettingsCategoryLabel".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(inRect);
            listing.Label("NG_RestartNote".Translate(), 2f * Text.LineHeight);
            listing.GapLine();
            listing.Label("NG_InternationalNote".Translate());
            listing.CheckboxLabeled($"{"NG_EnableInternationalLabel".Translate()}: ", ref settings.international);
            listing.CheckboxLabeled($"{"NG_EnableLogging".Translate()}: ", ref settings.logging);
            listing.End();
            settings.Write();
        }
    }
    
}
