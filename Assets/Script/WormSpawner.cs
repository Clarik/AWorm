using UnityEngine;
using UnityEngine.UI;

public class WormSpawner : MonoBehaviour
{

    public float timeBtwSpawn;
    private float startTimeBtwSpawn;
    public float minTime;
    public float minEachTime;


    public float exclamationMarkTime;
    private float startExclamationMarkTime;

    public Image[] exclamationMark;
    public Transform[] spawnPos;

    public GameObject worm;

    private bool go;
    private int randomPos;

    private void Start()
    {
        go = true;
        foreach (Image mark in exclamationMark)
        {
            mark.enabled = false;
        }
        startExclamationMarkTime = exclamationMarkTime;
        startTimeBtwSpawn = timeBtwSpawn;
    }

    private void FixedUpdate()
    {
        if (startTimeBtwSpawn <= 0)
        {
            if (!go)
            {
                if (startExclamationMarkTime <= 0)
                {
                    exclamationMark[randomPos].enabled = false;
                    SpawnWorm();

                }
                else
                {
                    startExclamationMarkTime -= Time.fixedDeltaTime;
                }
            }
            else
            {
                go = false;
                randomPos = Random.Range(0, spawnPos.Length);
                exclamationMark[randomPos].enabled = true;
                if (timeBtwSpawn > minTime)
                    timeBtwSpawn -= minEachTime;
            }
        }
        else
        {
            startTimeBtwSpawn -= Time.fixedDeltaTime;
        }
    }

    void SpawnWorm()
    {
        Vector3 spawnLoc = new Vector3(spawnPos[randomPos].position.x, spawnPos[randomPos].position.y, 1f);
        Instantiate(worm, spawnLoc, Quaternion.identity);
        startTimeBtwSpawn = timeBtwSpawn;
        startExclamationMarkTime = exclamationMarkTime;
        go = true;
    }

    public int WormLoc()
    {
        return randomPos;
    }
}