using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public Transform RoadStart;
    public Transform RoadEnd;

    public float minSpeed;
    public float maxSpeed;

    float speed;

    public float secondsToMaxDifficulty;

    public GameObject road;


    private void Start()
    {
        speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
    }

    void FixedUpdate()
    {
        if(transform.position == RoadEnd.position)
        {
            NewRoad();
        }
        transform.position = Vector2.MoveTowards(transform.position, RoadEnd.position, speed * Time.fixedDeltaTime);
    }

    void NewRoad()
    {
        Instantiate(road, RoadStart.position, Quaternion.identity);
        Destroy(gameObject);
    }

    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
