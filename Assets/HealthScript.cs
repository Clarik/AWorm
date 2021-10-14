using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private PlayerInfo player;
    public int health;
    public int numOfHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
    }
    void Update()
    {
        health = player.GetHealth();
        for (int i = 0; i < hearts.Length; i++)
        {
            if(health > numOfHealth)
            {
                health = numOfHealth;
            }
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
