using UnityEngine;

public class SpawnEnvironment : MonoBehaviour
{
    public Transform[] spawnLocation;
    public GameObject[] environment;

    public float timeBtwSpawn;
    private float startTimeBtwSpawn;

    private void Start()
    {
        startTimeBtwSpawn = timeBtwSpawn;
    }
    private void FixedUpdate()
    {
        if (startTimeBtwSpawn <= 0f)
        {
            CreateEnvironment();
            startTimeBtwSpawn = timeBtwSpawn;
        }
        else
        {
            startTimeBtwSpawn -= Time.fixedDeltaTime;
        }
    }

    void CreateEnvironment()
    {
        if(environment.Length > 0 && spawnLocation.Length > 0)
        {
            Instantiate(environment[Random.Range(0, environment.Length)], spawnLocation[Random.Range(0, spawnLocation.Length)].position, Quaternion.identity);
        }
    }
}
