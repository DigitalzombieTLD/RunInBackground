using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace RunInBackground
{
    [HarmonyLib.HarmonyPatch(typeof(GameManager), "OnApplicationFocus")]
    public class FocusPatchGameManager
    {
        public static bool Prefix(ref GameManager __instance)
        {
            GameManager.m_IsPaused = false;
            GameManager.m_PausedWhenFocusLost = false;
            return false;
        }
    }


    [HarmonyLib.HarmonyPatch(typeof(AkSoundEngineController), "ActivateAudio")]
    public class FocusPatchWWISE
    {
        public static void Prefix(ref GameManager __instance, ref bool activate, ref bool renderAnyway)
        {
            if (activate == false)
            {
                activate = true;
            }
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
