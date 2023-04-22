using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource footStep;
    void Start()
    {
        footStep = GetComponent<AudioSource>();


    }
    public void FootStep()
    {
        footStep.Play();
    }
}
