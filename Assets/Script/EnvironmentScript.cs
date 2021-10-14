using UnityEngine;

public class EnvironmentScript : MonoBehaviour
{
    Transform end;
    public float minSpeed;
    public float maxSpeed;

    float speed;

    public float secondsToMaxDifficulty;

    Vector2 target;

    SpriteRenderer sr;

    GameObject player;

    GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        

        end = GameObject.FindGameObjectWithTag("EnvironmentEndPoint").GetComponent<Transform>();
        target = new Vector3(end.position.x, transform.position.y, 1f);

        speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
    }
    void Update()
    {
        if (gm.IsGameStart())
        {
            if (player.GetComponent<Transform>().position.y < transform.position.y)
            {
                sr.sortingOrder = -1;
            }
            else
            {
                sr.sortingOrder = 5;
            }

            if (transform.position.x <= end.position.x)
            {
                DestroyEnvironment();
            }
        }
        
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
    }

    void DestroyEnvironment()
    {
        Destroy(gameObject);
    }

    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

}
