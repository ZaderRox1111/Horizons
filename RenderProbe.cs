using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderProbe : MonoBehaviour
{
    private GameObject player;
    private ReflectionProbe probe;
    private float distance;
    public float threshold = 50;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        probe = gameObject.GetComponent<ReflectionProbe>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, gameObject.transform.position);

        if (distance < threshold)
        {
            probe.RenderProbe();
        }
    }
}
