using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoadManager
{
    [SerializeField] private static AudioSource audio;

    private static float volume = 0.3f;

    public static void Save(float vol)
    {
        PlayerPrefs.SetFloat("Vol", vol);
    }

    public static float Load()
    {

            return volume = PlayerPrefs.GetFloat("Vol");
        }
     
}
