using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDistance : MonoBehaviour
{
    private GameObject GamePlayer;
    private ParticleSystem particle;
    private float distance;
    public float threshold;

    void Start()
    {
        GamePlayer = GameObject.FindGameObjectWithTag("Player");
        particle = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        ParticleSystem.EmissionModule emission;
        emission = particle.emission;

        distance = Vector2.Distance(GamePlayer.transform.position, gameObject.transform.position);
        if (distance < threshold)
        {
            emission.rateOverTimeMultiplier = 1;
        }
        if (distance > threshold)
        {
            emission.rateOverTimeMultiplier = 0;
        }
    }
}