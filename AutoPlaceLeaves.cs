using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlaceLeaves : MonoBehaviour
{
	private ArrayList treeArray;
	public GameObject firstLeaves;
	public GameObject secondLeaves;
	public GameObject thirdLeaves;

    void Start()
    {
		AddLeaves();
    }

    public void AddLeaves()
	{
		// Grab the tree array from the terrain
		treeArray = new ArrayList(Terrain.activeTerrain.terrainData.treeInstances);

		// Place leaves at all the trees
		for (int i = 0; i <= (treeArray.Count - 1); i++)
		{
			switch (((TreeInstance)treeArray[i]).prototypeIndex)
			{
				case 0:
					{
						GameObject.Instantiate(firstLeaves, ((TreeInstance)treeArray[i]).position, Quaternion.Euler(0, 0, ((TreeInstance)treeArray[i]).rotation));
					}; break;

				case 1:
					{
						GameObject.Instantiate(secondLeaves, ((TreeInstance)treeArray[i]).position, Quaternion.Euler(0, 0, ((TreeInstance)treeArray[i]).rotation));
					}; break;

				case 2:
					{
						GameObject.Instantiate(thirdLeaves, ((TreeInstance)treeArray[i]).position, Quaternion.Euler(0, 0, ((TreeInstance)treeArray[i]).rotation));
					}; break;

				default:
					{
						return;
					}
			}
		}
	}
}
