using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace JustPassionSkillIcons;

public class JustPassionSkillIconsMod : Mod
{
    public JustPassionSkillIconsMod(ModContentPack content) : base(content)
    {
        new Harmony("tiagocc0.justpassionskillicons").PatchAll();
    }
}

// the game caches these icons at startup before mod textures are ready, so they are set again on the first draw
public static class PassionIcons
{
    static bool done;

    public static void Refresh()
    {
        if (done)
        {
            return;
        }
        done = true;
        SkillUI.PassionMinorIcon = ContentFinder<Texture2D>.Get("UI/Icons/PassionMinor");
        SkillUI.PassionMajorIcon = ContentFinder<Texture2D>.Get("UI/Icons/PassionMajor");
        // readonly fields, 1.7 allows writing them through reflection
        AccessTools.Field(typeof(WidgetsWork), nameof(WidgetsWork.PassionWorkboxMinorIcon)).SetValue(null, ContentFinder<Texture2D>.Get("UI/Icons/PassionMinorGray"));
        AccessTools.Field(typeof(WidgetsWork), nameof(WidgetsWork.PassionWorkboxMajorIcon)).SetValue(null, ContentFinder<Texture2D>.Get("UI/Icons/PassionMajorGray"));
    }
}

[HarmonyPatch(typeof(SkillUI), nameof(SkillUI.DrawSkill), typeof(SkillRecord), typeof(Rect), typeof(SkillUI.SkillDrawMode), typeof(string))]
public static class SkillUI_DrawSkill_Patch
{
    public static void Prefix() => PassionIcons.Refresh();
}

[HarmonyPatch(typeof(WidgetsWork), nameof(WidgetsWork.DrawWorkBoxFor))]
public static class WidgetsWork_DrawWorkBoxFor_Patch
{
    public static void Prefix() => PassionIcons.Refresh();
}
