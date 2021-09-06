using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class PlayerSounds : MonoBehaviour
{
    private Transform player;
    private Terrain terrain;

    private int posX;
    private int posZ;
    //public int textureValuesSize;
    public float[] textureValues;

    public AudioClip[] randomWaterSounds;
    public AudioClip[] footstepSounds;
    private AudioSource source;
    private AudioSource footstepSource;
    public AudioMixerGroup output;

    public float checkTime = .25f;
    public float footstepsCheckTime = .5f;
    public float overlap = 0f;
    public float sprintPitch = 1.25f;
    public float walkingPitch = 0.75f;

    public float waterHeight = 16;
    private float yVal;
    public float jumpOffset = 1;

    private int randIndex;

    private void Start()
    {
        terrain = Terrain.activeTerrain;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(PlayRandomWaterAudio());
        StartCoroutine(PlayFootsteps());
    }

    IEnumerator PlayRandomWaterAudio()
    {
        while (true)
        {
            if (player.position.y < waterHeight)
            {
                randIndex = UnityEngine.Random.Range(0, randomWaterSounds.Length);

                source = gameObject.AddComponent<AudioSource>();
                source.clip = randomWaterSounds[randIndex];
                source.outputAudioMixerGroup = output;

                source.Play();

                Destroy(source, randomWaterSounds[randIndex].length);

                yield return new WaitForSeconds(randomWaterSounds[randIndex].length - overlap);
            } else
            {
                yield return new WaitForSeconds(checkTime);
            }
        }
    }

    IEnumerator PlayFootsteps()
    {
        while (true)
        {
            GetTerrainTexture();
            yVal = terrain.SampleHeight(new Vector3(player.position.x, 0, player.position.z));

            footstepSource = gameObject.AddComponent<AudioSource>();
            footstepSource.outputAudioMixerGroup = output;

            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") && player.position.y <= (yVal + jumpOffset))
            {
                if (Input.GetButton("Sprint"))
                {
                    footstepSource.pitch = sprintPitch;
                } else
                {
                    footstepSource.pitch = walkingPitch;
                }
                for (int index = 0; index < textureValues.Length; index++)
                {
                    try
                    {
                        if (textureValues[index] > 0)
                        {
                            footstepSource.PlayOneShot(footstepSounds[index], textureValues[index]);
                            Destroy(footstepSource, footstepsCheckTime);
                        }
                    } catch
                    {
                        Destroy(footstepSource, footstepsCheckTime);
                    }
                }
            }

            yield return new WaitForSeconds(footstepsCheckTime);
            Destroy(footstepSource);
        }
    }

    private void GetTerrainTexture()
    {
        ConvertPosition(player.position);
        CheckTexture();
    }

    void ConvertPosition(Vector3 playerPosition)
    {
        Vector3 terrainPosition = playerPosition - terrain.transform.position;

        Vector3 mapPosition = new Vector3
        (terrainPosition.x / terrain.terrainData.size.x, 0,
        terrainPosition.z / terrain.terrainData.size.z);

        float xCoord = mapPosition.x * terrain.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * terrain.terrainData.alphamapHeight;

        posX = (int)xCoord;
        posZ = (int)zCoord;
    }

    void CheckTexture()
    {
        float[,,] aMap = terrain.terrainData.GetAlphamaps(posX, posZ, 1, 1);

        for (int index = 0; index < textureValues.Length; index++)
        {
            textureValues[index] = aMap[0, 0, index];
        }
    }
}
