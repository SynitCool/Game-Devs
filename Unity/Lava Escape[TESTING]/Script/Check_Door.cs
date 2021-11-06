using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Door : MonoBehaviour
{
    public GameObject button_1;
    public GameObject button_2;
    
    Color new_color;
    Renderer n_renderer;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (button_1.GetComponent<SpriteRenderer>().color == Color.green &&
            button_2.GetComponent<SpriteRenderer>().color == Color.green){
            Destroy(gameObject);
        }
    }
}
