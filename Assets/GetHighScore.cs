using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{
    Text highScoreText;
    int highScore;

    void Start()
    {
        highScoreText = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "High Score : " + highScore;
    }
}
