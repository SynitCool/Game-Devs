using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float increase_lava;

    public GameObject destroy_effect;
    
    public GameObject lose_menu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0f, increase_lava * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            Instantiate(destroy_effect, other.gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().DecreaseVolume("Theme", 0.2f);
            FindObjectOfType<AudioManager>().PlayAudio("PlayerDeath");
            lose_menu.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Box")){
            Destroy(other.gameObject);
            Instantiate(destroy_effect, other.gameObject.transform.position, Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("Enemy")){
            Destroy(other.gameObject);
            Instantiate(destroy_effect, other.gameObject.transform.position, Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("Wall")){
            Destroy(other.gameObject);
            Instantiate(destroy_effect, other.gameObject.transform.position, Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("Door")){
            Destroy(other.gameObject);
            Instantiate(destroy_effect, other.gameObject.transform.position, Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("Ground")){
            Destroy(other.gameObject);
            Instantiate(destroy_effect, other.gameObject.transform.position, Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("Side")){
            Destroy(other.gameObject);
            Instantiate(destroy_effect, other.gameObject.transform.position, Quaternion.identity);
        }
    }

}
