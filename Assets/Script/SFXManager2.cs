using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager2 : MonoBehaviour
{
    public AudioClip katana;
    public AudioClip katana_Taking;
    public AudioClip GunCleaner;
    public AudioClip GunCleaner2;
    public AudioClip Mop;
    public AudioClip Syringe;

    public AudioSource audio_F;

    void Start()
    {
    }

    void Update()
    {
    }

    public void SoundManager_F(string audioName)
    {

        if (audioName == "katana")
        {
            audio_F.PlayOneShot(katana);
        }

        if (audioName == "katana_Taking")
        {
            audio_F.PlayOneShot(katana_Taking);
        }

        if (audioName == "GunCleaner")
        {
            audio_F.PlayOneShot(GunCleaner);
        }
        if (audioName == "GunCleaner2")
        {
            audio_F.PlayOneShot(GunCleaner2);
        }

        if (audioName == "Mop")
        {
            audio_F.PlayOneShot(Mop);
        }

        if (audioName == "Syringe")
        {
            audio_F.PlayOneShot(Syringe);
        }
    }
}
