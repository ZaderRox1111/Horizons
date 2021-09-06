using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class DetailAutoCompiler : MonoBehaviour
{
    // Using Serializable allows us to embed a class with sub properties in the inspector.
    [Serializable]
    public class DetailAttributes
    {
        public string name;
        public int detailLayer;
        public int textureLayer;
        [Range(0, 14)]
        public int detailStrength;
    }

    public List<DetailAttributes> listDetails = new List<DetailAttributes>();
    private Terrain terrain;
    private TerrainData terrainData;

    public void PaintDetails()
    {
        DetailAttributes currentDetail;

        // Get the attached terrain component
        terrain = GetComponent<Terrain>();

        // Get a reference to the terrain data
        terrainData = terrain.terrainData;

        // get the alhpa maps - i.e. all the ground texture layers
        float[,,] alphaMapData = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);

        for (int index = 0; index < listDetails.Count; index++)
        {
            currentDetail = listDetails[index];

            //get the detail map for the grass layer we're after
            int[,] map = terrainData.GetDetailLayer(0, 0, terrainData.detailWidth, terrainData.detailHeight, currentDetail.detailLayer);

            //now copy-paste the alpha map onto the detail map, pixel by pixel
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                for (int y = 0; y < terrainData.alphamapHeight; y++)
                {
                    //Check the Detail Resolution and the Control Texture Resolution in the terrain settings.
                    //By default the detail resolution is twice the alpha resolution! So every detail co-ordinate is going to have to affect a 2x2 square!
                    //Go change detail resolution on terrain data to 512 instead of 1024
                    map[x, y] = (int)alphaMapData[x, y, currentDetail.textureLayer] * currentDetail.detailStrength;
                }
            }
            terrainData.SetDetailLayer(0, 0, currentDetail.detailLayer, map);
        }
        
    }
}
