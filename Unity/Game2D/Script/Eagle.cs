using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eagle : MonoBehaviour
{
    [Header("Reference Component")]
    public Animator animator;
    public Rigidbody2D rigidbody;
    public Collider2D collider;
    public SpriteRenderer sprite_renderer;

    [Header("Movement")]
    public float speed = 5f;

    [Header("Health")]
    public static float max_health = 15f;
    public float min_health;
    private float current_health;
    public HealthBar health_bar;

    [Header("Damage")]
    public float damage = 3f;

    private bool moving_right;

    [Header("GameObject With Array")]
    public ParticleEffect[] effects;
    
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        
        PlayerPrefs.SetFloat("DefaultX", transform.position.x);

        current_health = max_health;

        health_bar.SetMaxHealth(max_health);
        health_bar.SetMinHealth(min_health);
    }

    // Update is called once per frame
    void Update()
    {
        
        // FollowingPlayer
        FollowingPlayer();

        // Set Health
        SetHealth();

        // Giving Damage
        GivingDamage();
            
        // Player's Dead
        Death();

        //Add Score
        if (current_health <= min_health)
        {
            BehindScene.score_count += 1;
        }

    }

    private void FollowingPlayer()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        
        // Reference
        float step = speed * Time.deltaTime;

        // Position
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        
        // Animation
        animator.SetFloat("Speed", speed);

        //Flip
        if (PlayerPrefs.GetFloat("DefaultX") > 0.01f && PlayerPrefs.GetFloat("DefaultX") > transform.position.x)
        {
            sprite_renderer.flipX = false;
        }
        else if (PlayerPrefs.GetFloat("DefaultX") < -0.01f && PlayerPrefs.GetFloat("DefaultX") < transform.position.x)
        {
            sprite_renderer.flipX = true;
        }
        else 
        {
            return;
        }

    }

    private void SetHealth()
    {
        health_bar.SetHealth(current_health);
    }
    
    public void TakeDamage(float damage)
    {
        float real_damage = damage * Time.deltaTime;
        
        current_health -= real_damage;
    }

    public void Death()
    {
        if (current_health <= min_health)
        {
            Destroy(gameObject);
        }
        
    }

    private void GivingDamage()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        
        if (player.position == transform.position)
        {
           player.GetComponent<Player>().TakeDamage(damage);
        }

    }

    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cages")
        {
            speed = 0f;
        }
    }

}
