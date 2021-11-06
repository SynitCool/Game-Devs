using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class Player : MonoBehaviour
{   
    [Header("Movement")]
    public float move_speed = 5f;
    public float jump_force = 5f;

    [Header("Health")]
    public float max_health;
    public float min_health;
    private float current_health;
    public HealthBar healthbar;

    [Header("Damage")]
    public float damage = 5f;

    private bool facing_right;
    private int jump_count;
    private bool IsCrouching;
    private bool IsDead;
    private bool JumpAfterDead;

    [Header("Reference Component")]
    public Animator animator;
    public SpriteRenderer sprite_renderer;

    private float inputx;
    private bool is_moving;

    [Header("Reference GameObject With List")]
    public Items[] items;
    public ParticleEffect[] effects;

    Rigidbody2D rb;
    Collider2D collider;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();

        PlayerPrefs.SetFloat("DefaultSpeed", move_speed);

        IsDead = false;
        JumpAfterDead = true;
        IsCrouching = false;

        current_health = max_health;

        healthbar.SetMaxHealth(max_health);
        healthbar.SetMinHealth(min_health);
    }

    // Update is called once per frame
    void Update()
    {  
        // Player Moves
        Movement();

        // Player Jumps
        Jump();

        // Player's Dead
        Death();

        // Set Health
        SetHealth();

        // Giving Damage
        GivingDamage();

        Debug.Log(FindObjectOfType<AudioManager>().CheckIsPlaying("Run"));
    }
    
    // Movement
    private void Movement()
    {
        if (IsDead == false)
        {
            inputx = Input.GetAxis("Horizontal");
            
            move_speed = PlayerPrefs.GetFloat("DefaultSpeed");
        
            animator.SetFloat("Speed", Mathf.Abs(inputx));
            animator.SetBool("IsCrouch", false);

            IsCrouching = false;

            if (Input.GetKey(KeyCode.C))
            {
                Crouch();
            }
        
            rb.velocity = new Vector2(inputx * move_speed, rb.velocity.y);
            
            if (rb.velocity.x != 0f)
            {
                is_moving = true;
            }
            else
            {
                is_moving = false;
            }
            
            // Flip Player
            if (inputx > 0)
            {
                ParticleEffect pe = Array.Find(effects, effect => effect.name == "Dust_Effect");
                sprite_renderer.flipX = false;
                CreateDustEffect();
                pe.particle_effect_position.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (inputx < 0)
            {
                ParticleEffect pe = Array.Find(effects, effect => effect.name == "Dust_Effect");
                sprite_renderer.flipX = true;
                CreateDustEffect();
                pe.particle_effect_position.rotation = Quaternion.Euler(0f, 18f, 0f);
            }

            if (is_moving && !FindObjectOfType<AudioManager>().CheckIsPlaying("Run"))
            {
                FindObjectOfType<AudioManager>().PlayPlayer("Run");
            }
            else
            {
                FindObjectOfType<AudioManager>().StopPlayer("Run");
            }
            
        }
        else
        {
            is_moving = false;
            //audio_source_run.Stop();
        }
        
    }

    // Jump
    private void Jump()
    {
        if (IsDead == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jump_count == 0)
            {
                animator.SetBool("IsJump", true);
                jump_count += 1;
                rb.velocity = Vector2.up * jump_force;
                FindObjectOfType<AudioManager>().PlayPlayer("Jump");
            }

            if (jump_count == 0)
            {
                CreateDustEffect();
            }
        }
        else
        {
            animator.SetBool("IsJump", false);
        }
    }

    // Crouch
    private void Crouch()
    {
        animator.SetBool("IsCrouch", true);
        move_speed = 0;
        IsCrouching = true;
    }

    // TakeDamage
    public void TakeDamage(float damage)
    {
        float real_damage = damage * Time.deltaTime;

        current_health -= real_damage;
        
    }

    // GivingDamage
    private void GivingDamage()
    {
        Transform eagle = GameObject.FindWithTag("Eagle").transform;
        
        if (eagle.position == transform.position && IsCrouching)
        {
            eagle.GetComponent<Eagle>().TakeDamage(damage);
        }
    }

    // PlayerDeath
    private void Death()
    {
        // Check If Death
        if (current_health <= min_health)
        {
            move_speed = 0f;
            jump_force = 0f;
            IsDead = true;
            collider.isTrigger = true;

            animator.SetBool("IsCrouch", false);
            animator.SetBool("IsDead", IsDead);

            CreateDeathEffect();

            if (JumpAfterDead == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, 5f);
                JumpAfterDead = false;
            }
        }
    }

    // SetHealth
    private void SetHealth()
    {
        healthbar.SetHealth(current_health);
    }

    // Dust Effect
    private void CreateDustEffect()
    {
        ParticleEffect pe = Array.Find(effects, effect => effect.name == "Dust_Effect");

        pe.particle_effect.Play();
    }

    // Death Effect
    private void CreateDeathEffect()
    {
        ParticleEffect pe = Array.Find(effects, effect => effect.name == "Death_Effect");

        pe.particle_effect.Play();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Jump Check
        if (other.gameObject.tag != "Player")
        {
            animator.SetBool("IsJump", false);
            jump_count *= 0;
        }

        Items gem_it = Array.Find(items, item => item.name == "Gem");
        if (other.gameObject.tag == "Items" && other.gameObject.name == "Gem(Clone)")
        {
            damage += 1;
            Eagle.max_health += 1;
            Frog.max_health += 1;
            Opossum.max_health += 1;
        }

        Items cherry_it = Array.Find(items, item => item.name == "Cherry");
        if (other.gameObject.tag == "Items" && other.gameObject.name == "Cherry(Clone)")
        {
            current_health += 10;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "Frog(Clone)" && IsCrouching == true)
        {
            other.gameObject.GetComponent<Frog>().TakeDamage(damage);
    
        }
        else if (other.gameObject.name == "Opossum(Clone)" && IsCrouching == true)
        {
            other.gameObject.GetComponent<Opossum>().TakeDamage(damage);
            
        }

        
    }

}