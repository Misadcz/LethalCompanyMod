using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalCompanyMod.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalCompanyMod
{
    [BepInPlugin(modGUID,modName,modVersion)]
    public class ModBase : BaseUnityPlugin 
    {
        private const string modGUID = "Misadcz.FirstMod";
        private const string modName = "First LC Mod";
        private const string modVersion = "1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ModBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("This mod is loaded!");

            harmony.PatchAll(typeof(ModBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));


        }
    }
}
