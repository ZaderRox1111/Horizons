using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawnPoints : MonoBehaviour
{
    public GameObject prefab;
    private Terrain terrain;
    public Transform parent;

    public float minHeight = 16;
    public int numPoints;

    private float terrainWidth;
    private float terrainLength;

    private float xTerrainPos;
    private float zTerrainPos;

    private float randX, randZ, yVal;
    private float newX, newZ, newY;

    private float[] generatedPos = new float[3];
    private float[] newPos = new float[3];

    void Start()
    {
        terrain = Terrain.activeTerrain;

        //Get terrain size
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        //Get terrain position
        xTerrainPos = terrain.transform.position.x;
        zTerrainPos = terrain.transform.position.z;

        SpawnPoints();
    }

    private float[] GeneratePosition()
    {
        //Generate random x,z,y position on the terrain
        newX = Random.Range((int)xTerrainPos, (int)(xTerrainPos + terrainWidth));
        newZ = Random.Range((int)zTerrainPos, (int)(zTerrainPos + terrainLength));
        newY = terrain.SampleHeight(new Vector3(newX, 0, newZ));

        newPos[0] = newX;
        newPos[1] = newY;
        newPos[2] = newZ;

        return newPos;
    }

    void generateObjectOnTerrain()
    {
        do
        {
            generatedPos = GeneratePosition();
            randX = generatedPos[0];
            yVal = generatedPos[1];
            randZ = generatedPos[2];
        } while (yVal < minHeight);

        //Debug.Log(string.Format("{0} {1} {2}", randX, yVal, randZ));
        //Generate the Prefab on the generated position
        Instantiate(prefab, new Vector3(randX, yVal, randZ), Quaternion.identity, parent);
    }

    void SpawnPoints()
    {
        for (int index = 0; index < numPoints; index++)
        {
            generateObjectOnTerrain();
        }
    }
}
