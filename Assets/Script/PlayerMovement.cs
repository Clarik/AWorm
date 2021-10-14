using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Transform[] location;

    int locPosition = 1;
    float verti;
    Vector3 nextPos;

    GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        nextPos = transform.position;
    }

    void Update()
    {
        if (gm.IsGameStart())
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                verti = -1f;
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                verti = 1f;
        }
    }

    private void FixedUpdate()
    {
        if(verti < -0.5f && locPosition > 0)
        {
            locPosition--;
            nextPos = new Vector3(location[locPosition].position.x, location[locPosition].position.y, 1f);
            verti = 0f;
        }
        if (verti > 0.5f && locPosition < location.Length-1)
        {
            locPosition++;
            nextPos = new Vector3(location[locPosition].position.x, location[locPosition].position.y, 1f);
            verti = 0f;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed);
    }

    public void upArrow()
    {
        verti = -1f;
    }

    public void downArrow()
    {
        verti = 1f;
    }
}
