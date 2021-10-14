using UnityEngine;

public class WormMovement : MonoBehaviour
{
    Transform end;

    public float minSpeed;
    public float maxSpeed;

    float speed;

    public float secondsToMaxDifficulty;

    Vector3 target;

    GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        end = GameObject.FindGameObjectWithTag("EnvironmentEndPoint").GetComponent<Transform>();
        target = new Vector3(end.position.x, transform.position.y, 1f);
        speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.IsGameStart())
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= end.position.x)
        {
            DestroyWorm();
        }
    }

    void DestroyWorm()
    {
        Destroy(gameObject);
    }

    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
