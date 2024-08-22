using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Maneater_HallOates.Patches;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maneater_HallOates
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ManeaterHallOatesBase : BaseUnityPlugin
    {
        private const string modGUID = "dukeofbiscuits.ManeaterHallOates";
        private const string modName = "Maneater Hall and Oates";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ManeaterHallOatesBase Instance;

        internal ManualLogSource mls;

        internal static List<AudioClip> newCryingSound;
        internal static AssetBundle Bundle; 

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("Whoa. Here she comes. dukeofbiscuits.ManeaterHallOates is loaded.");

            mls.LogInfo("Hall and Oates incoming");

            harmony.PatchAll(typeof(CaveDwellerAIPatch));

            mls = Logger;

            newCryingSound = new List<AudioClip>();

            string FolderLocation = Instance.Info.Location;
            FolderLocation = FolderLocation.TrimEnd("Maneater_HallOates.dll".ToCharArray());
            Bundle = AssetBundle.LoadFromFile(FolderLocation + "cryingaudio");
            mls.LogInfo("Folder: " + FolderLocation);
            if (Bundle != null)
            {
                mls.LogInfo("Successfully loaded asset bundle");
                newCryingSound = Bundle.LoadAllAssets<AudioClip>().ToList();
            }
            else
            {
                mls.LogError("Failed to Load asset");
            }
        }


    }
}
