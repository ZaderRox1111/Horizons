using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacePlayer : MonoBehaviour
{
    private Transform player;
    private Terrain terrain;

    public float minHeight = 16;

    private float terrainWidth;
    private float terrainLength;
    private float xTerrainPos;
    private float zTerrainPos;

    private float randX, randZ, yVal;

    private Vector3 newPos;

    void Start()
    {
        terrain = Terrain.activeTerrain;

        //Get terrain size
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        //Get terrain position
        xTerrainPos = terrain.transform.position.x;
        zTerrainPos = terrain.transform.position.z;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        GeneratePosition();
        player.position = newPos;
    }

    private void GeneratePosition()
    {
        do
        {
            randX = Random.Range((int)xTerrainPos, (int)(xTerrainPos + terrainWidth));
            randZ = Random.Range((int)zTerrainPos, (int)(zTerrainPos + terrainLength));
            yVal = terrain.SampleHeight(new Vector3(randX, 0, randZ));
        } while (yVal < minHeight);

        yVal += 5;

        newPos = new Vector3(randX, yVal, randZ);
    }
}
