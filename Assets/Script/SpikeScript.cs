using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    Transform end;
    public float minSpeed;
    public float maxSpeed;
    
    float speed;

    public float secondsToMaxDifficulty;

    Vector2 target;

    void Start()
    {
        end = GameObject.FindGameObjectWithTag("EnvironmentEndPoint").GetComponent<Transform>();
        target = new Vector3(end.position.x, transform.position.y, 1f);
        speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
    }
        
    private void FixedUpdate()
    {
        if (transform.position.x <= end.position.x)
        {
            DestroySpike();
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
    }

    void DestroySpike()
    {
        Destroy(gameObject);
    }

    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

}
