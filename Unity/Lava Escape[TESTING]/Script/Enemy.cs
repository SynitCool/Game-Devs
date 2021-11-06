using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    
    private Transform other;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer(){  
        other = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        transform.position = Vector2.MoveTowards(transform.position, other.position, speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
        }
    }
}