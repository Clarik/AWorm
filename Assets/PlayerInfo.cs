using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Image red;
    Collider2D coll;
    Rigidbody2D rb;
    SpriteRenderer[] sr;

    public GameObject damageEffect;
    public GameObject healthGainEffect;
    GameObject effect;
    GameObject healthGain;

    GameObject DeathBody;
    public GameObject deathSprite;
    bool alive;

    GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        alive = true;
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentsInChildren<SpriteRenderer>();
        red.enabled = false;
    }

    void Update()
    {

        if(health <= 0 && alive)
        {
            death();
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gotDamage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike") || collision.CompareTag("Worm"))
        {
            gotDamage();
        }
        if (collision.CompareTag("Heart"))
        {
            addHealth(1, collision);
        }
    }

    void gotDamage()
    {
        TakeDamage(1);
        
        StartCoroutine(redDisable());
        if(health > 0)
        {
            effect = Instantiate(damageEffect, transform.position, Quaternion.identity);
            StartCoroutine(invisible());
        }
    }

    IEnumerator redDisable()
    {
        red.enabled = true;
        yield return new WaitForSeconds(0.2f);
        red.enabled = false;
    }

    IEnumerator invisible()
    {
        coll.enabled = false;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            foreach (var s in sr)
                s.enabled = false;
            yield return new WaitForSeconds(0.2f);
            foreach (var s in sr)
                s.enabled = true;
        }
        coll.enabled = true;
        Destroy(effect);
    }

    public void TakeDamage(int min)
    {
        health -= min;
    }

    public void addHealth(int add, Collider2D coll)
    {
        health += add;
        healthGain = Instantiate(healthGainEffect, coll.transform.position, Quaternion.identity);
        StartCoroutine(healthBonus());
    }

    IEnumerator healthBonus()
    {
        yield return new WaitForSeconds(3f);
        Destroy(healthGain);
    }

    public void death()
    {
        foreach (var s in sr)
            s.enabled = false;
        coll.enabled = false;
        DeathBody = Instantiate(deathSprite, transform.position, Quaternion.identity);
        gm.isDead(true);
        alive = false;
    }

}
