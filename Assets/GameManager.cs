using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    int score;
    private int highScore;

    public bool GameStart;
    bool death;

    MenuManager mm;

    public GameObject deathScene;

    void Start()
    {
        deathScene.SetActive(false);

        death = false;
        mm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MenuManager>();
        highScore = PlayerPrefs.GetInt("HighScore");
        score = 0;
        GameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (death)
        {
            deathScene.SetActive(true);
            GameStart = false;
            Time.timeScale = 0;
        }
        else
        {
            if (mm.IsPause())
            {
                GameStart = false;
                Time.timeScale = 0;
            }
            else
            {
                GameStart = true;
                Time.timeScale = 1;
            }
        }

        score = (int)Time.timeSinceLevelLoad;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", score);
        }

        scoreText.text = score + "";
    }
    
    public void isDead(bool con)
    {
        death = con;
    }

    public bool IsGameStart()
    {
        return GameStart;
    }
}
