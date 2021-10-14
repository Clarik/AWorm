using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    Transform end;
    public float minSpeed;
    public float maxSpeed;

    float speed;

    public float secondsToMaxDifficulty;

    Vector2 target;

    GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        end = GameObject.FindGameObjectWithTag("EnvironmentEndPoint").GetComponent<Transform>();
        target = new Vector3(end.position.x, transform.position.y, 1f);

        speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (transform.position.x <= end.position.x)
        {
            DestroyHeart();
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
    }

    void DestroyHeart()
    {
        Destroy(gameObject);
    }

    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

}
