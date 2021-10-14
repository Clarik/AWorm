using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public Transform[] spawnLocation;
    public GameObject[] heart;

    public float minTime;
    public float maxTime;

    private float startTimeBtwSpawn;

    private void Start()
    {
        startTimeBtwSpawn = Random.Range(minTime, maxTime);
    }
    private void FixedUpdate()
    {
        if (startTimeBtwSpawn <= 0f)
        {
            CreateHeart();
            startTimeBtwSpawn = Random.Range(minTime, maxTime);
        }
        else
        {
            startTimeBtwSpawn -= Time.fixedDeltaTime;
        }
    }

    void CreateHeart()
    {
        if (heart.Length > 0 && spawnLocation.Length > 0)
        {
            Instantiate(heart[Random.Range(0, heart.Length)], spawnLocation[Random.Range(0, spawnLocation.Length)].position, Quaternion.identity);
        }
    }
}
