using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip Jump;
    public AudioClip FootStep;
    public AudioClip Touch;

    public AudioSource audio_F;

    void Start()
    {
    }

    void Update()
    {
    }

    public void SoundManager_F(string audioName)
    {

        if (audioName == "Jump")
        {
            audio_F.PlayOneShot(Jump);
        }

        if (audioName == "FootStep")
        {
            audio_F.PlayOneShot(FootStep);
        }

        if (audioName == "Touch")
        {
            audio_F.PlayOneShot(Touch);
        }
    }
}
