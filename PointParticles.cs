using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointParticles : MonoBehaviour
{
    private ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        particles = gameObject.GetComponent<ParticleSystem>();
    }

    public void Particles()
    {
        particles.Play();
    }
}
