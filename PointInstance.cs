using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInstance : MonoBehaviour
{
    private GameObject gameManager;
    private ScoreManager scoreManager;
    private PointParticles particles;
    private GameObject daddy;
    private MeshRenderer meshRenderer;
    private GameObject player;
    private EatSound eatSound;

    public int scoreAdd = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        eatSound = player.GetComponent<EatSound>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        scoreManager = gameManager.GetComponent<ScoreManager>();
        particles = gameObject.GetComponentInChildren<PointParticles>();
        daddy = gameObject.transform.parent.gameObject;
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    public void OnTriggerEnter(Collider other)
    {
        scoreManager.AddPoint(scoreAdd);
        StartCoroutine(ParticlesAndDestroy());
    }

    private IEnumerator ParticlesAndDestroy()
    {
        particles.Particles();
        eatSound.PlayEatSound();
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(daddy);
    }
}
