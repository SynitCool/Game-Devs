using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public Animator animator;
    public Transform player_detection_left;
    public Transform player_detection_right;
    public SpriteRenderer sprite_renderer;

    public static float max_health = 20f;
    public float min_health;
    private float current_health;

    public HealthBar health_bar;

    public float damage = 2f;
    public float poison_damage = 2f;
    
    public float speed = 5f;

    
    // Start is called before the first frame update
    void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();

        current_health = max_health;

        health_bar.SetMaxHealth(max_health);
        health_bar.SetMinHealth(min_health);
    }

    // Update is called once per frame
    void Update()
    {
        // Following Player
        FollowingPlayer();

        // Frog's Dead
        Death();

        // Set Health
        SetHealth();

        if (current_health <= min_health)
        {
            BehindScene.score_count += 5;
        }
    }

    private void FollowingPlayer()
    {
        float step = speed * Time.deltaTime;
        Transform player = GameObject.FindWithTag("Player").transform;
        
        if (Vector2.Distance(player.position, transform.position) <= 5f)
        {
            animator.SetBool("IsRun", true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        }
        else
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsRun", false);
        }

        //Rotate
        
        // x = false == left
        // x = true == right
        
        RaycastHit2D player_info_left = Physics2D.Raycast(player_detection_left.position, Vector2.right, 10f);
        RaycastHit2D player_info_right = Physics2D.Raycast(player_detection_right.position, Vector2.left, 10f);
        
        if (player_info_left.collider.tag == "Player")
        {
            sprite_renderer.flipX = false;
        }
        
        if (player_info_right.collider.tag == "Player")
        {
            sprite_renderer.flipX = true;
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

    private void Death()
    {
        if (current_health <= min_health)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage * poison_damage);
        }
    }

}
