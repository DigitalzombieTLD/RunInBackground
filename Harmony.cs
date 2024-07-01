using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace RunInBackground
{
    [HarmonyLib.HarmonyPatch(typeof(GameManager), "OnApplicationFocus")]
    public class FocusPatch
    {
        public static bool Prefix(ref GameManager __instance)
        {
            GameManager.m_IsPaused = false;
            GameManager.m_PausedWhenFocusLost = false;
            return false;
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(GameManager), "Awake")]
    public class AwakePatch
    {
        public static void Postfix(ref GameManager __instance)
        {
            Application.runInBackground = true;           
        }
    }
}
