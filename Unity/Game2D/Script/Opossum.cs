using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    public static float max_health = 25f;
    public float min_health;
    private float current_health;

    public HealthBar health_bar;
    public Collider2D collider;
    public Rigidbody2D rb;

    public float damage = 20f;

    public float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;

        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        health_bar.SetMaxHealth(max_health);
        health_bar.SetMinHealth(min_health);
    }

    // Update is called once per frame
    void Update()
    {
        //Set Health
        SetHealth();

        //Object's Dead
        Death();

        //Object Runs
        RunToEdge();

        //Adjust Score
        if (current_health <= min_health)
        {
            BehindScene.score_count += 10;
        }
    }

    private void SetHealth()
    {
        health_bar.SetHealth(current_health);
    }
    
    private void RunToEdge()
    {
        float step = speed * Time.deltaTime;
        
        rb.velocity = Vector2.left * speed;
    }

    public void TakeDamage(float damage)
    {
        float real_damage = damage * Time.deltaTime;
        
        current_health -= real_damage;
    }

    private void Death()
    {
        if (current_health <= min_health)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collider.isTrigger = false;
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collider.isTrigger = true;
        }
    }

}