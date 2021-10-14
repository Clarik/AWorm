using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public Transform[] spawnLocation;
    public GameObject[] spike;

    public float timeBtwSpawn;
    private float startTimeBtwSpawn;
    public float minTime;
    public float minEachTime;

    public WormSpawner ws;

    private void Start()
    {
        startTimeBtwSpawn = timeBtwSpawn;
    }
    private void FixedUpdate()
    {
        if (startTimeBtwSpawn <= 0f)
        {
            CreateSpike();
            startTimeBtwSpawn = timeBtwSpawn;
            if (timeBtwSpawn > minTime)
                timeBtwSpawn -= minEachTime;
        }
        else
        {
            startTimeBtwSpawn -= Time.fixedDeltaTime;
        }
    }

    void CreateSpike()
    {
        if (spike.Length > 0 && spawnLocation.Length > 0)
        {
            if(ws.WormLoc() == 1)
                return;
            int randomNum = Random.Range(0, spawnLocation.Length);
            Instantiate(spike[Random.Range(0, spike.Length)], spawnLocation[randomNum].position, Quaternion.identity);
        }
    }
}
