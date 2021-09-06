using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatSound : MonoBehaviour
{
    public AudioSource source;

    public void PlayEatSound()
    {
        source.Play();
    }
}
