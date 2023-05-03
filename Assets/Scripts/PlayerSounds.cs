using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip footstepClip;
    public AudioClip sheathClip;

    private AudioSource footstep;
    private AudioSource sheath;
    void Start()
    {
        footstep = gameObject.AddComponent<AudioSource>();
        footstep.name = "footstep";
        footstep.clip = footstepClip;

        sheath = gameObject.AddComponent<AudioSource>();
        sheath.name = "sheath";
        sheath.clip = sheathClip;
    }
    public void FootStep()
    {
        footstep.Play();
    }

    public void Sheath()
    {
        sheath.Play();
    }
}
