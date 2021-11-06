using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public float move_speed;
    public float jump_force;
    
    public Transform ground_check;
    public Transform wall_check;
    
    private bool facing_right;
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){

        if (Input.GetKey(KeyCode.Space)){
            Jump();
        }
        
        Movement();
        WalkingOnTheWall();
    }

    private void Movement(){
        float inputx;
        
        inputx = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(inputx * move_speed, rb.velocity.y);
        if (inputx > 0 && facing_right){
            Flip();
        }
        else if (inputx < 0 && !facing_right){
            Flip();
        }
    
    }

    private void Jump(){
        RaycastHit2D Ground_Check = Physics2D.Raycast(ground_check.position, Vector2.down, 0f);
            
        if (Ground_Check.collider != null && (Ground_Check.collider.tag == "Ground" || 
            Ground_Check.collider.tag == "Enemy" || 
            Ground_Check.collider.tag == "Gun" ||
            Ground_Check.collider.tag == "Box"||
            Ground_Check.collider.tag == "Wall" ||
            Ground_Check.collider.tag == "Rocket")){
            rb.velocity = Vector2.up * jump_force;
        }  
    }

    private void Flip(){
        facing_right = !facing_right;
        
        transform.Rotate(0f, 180f, 0f);
    }

    private void WalkingOnTheWall(){
        float inputx;
        float inputy;
        
        inputx = Input.GetAxis("Horizontal");
        inputy = Input.GetAxis("Vertical");
        
        RaycastHit2D Wall_Check = Physics2D.Raycast(wall_check.position, Vector2.up, 0f);
    
        if (Wall_Check.collider != null && Wall_Check.collider.tag == "Wall"){
            rb.velocity = new Vector2(inputx * (move_speed * 2), inputy * (move_speed * 2));
        }
    }

}