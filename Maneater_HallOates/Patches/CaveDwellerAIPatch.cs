using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Maneater_HallOates.Patches
{
    [HarmonyPatch(typeof(CaveDwellerAI))]
    internal class CaveDwellerAIPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void OverrideBabyCryingAudio(CaveDwellerAI __instance)
        {
            
            if (__instance.babyCrying && __instance.babyCryingAudio.clip != ManeaterHallOatesBase.newCryingSound[0])
            {
                Debug.Log("Setting Baby Crying to the Dulcet tones of Hall and Oates");
                __instance.babyCryingAudio.Stop();
                __instance.babyCryingAudio.clip = ManeaterHallOatesBase.newCryingSound[0];
                __instance.babyCryingAudio.Play();
            }

            if (__instance.babyCrying && __instance.babyCryingAudio.clip != ManeaterHallOatesBase.newCryingSound[0])
            {
                Debug.Log("Clip not set");
            }
        }


    }
}
