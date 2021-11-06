using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Pressed : MonoBehaviour
{
    public GameObject door;
    
    SpriteRenderer renderer;
    Color new_color;

    // Start is called before the first frame update
    void Start()
    { 
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player") 
        || other.gameObject.CompareTag("Box")){
            renderer.color = Color.green;
        }
    }
}
