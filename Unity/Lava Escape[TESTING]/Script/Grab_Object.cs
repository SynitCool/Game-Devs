using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Object : MonoBehaviour
{
    public Transform Grab_Holder;
    public Transform Grab_Detect;
    public float ray_Dist;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D Grab_Check = Physics2D.Raycast(Grab_Detect.position, Vector2.right, ray_Dist);

        if (Grab_Check.collider != null && Grab_Check.collider.tag == "Gun"){
            if (Input.GetKey(KeyCode.E)){
                Grab_Check.collider.gameObject.transform.rotation = Grab_Holder.rotation;
                Grab_Check.collider.gameObject.transform.parent = Grab_Holder;
                Grab_Check.collider.gameObject.transform.position = Grab_Holder.position;
                Grab_Check.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Grab_Check.collider.gameObject.transform.parent = null;
                Grab_Check.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }

        }

        if (Grab_Check.collider != null && Grab_Check.collider.tag == "Box"){
            if (Input.GetKey(KeyCode.E)){
                Grab_Check.collider.gameObject.transform.rotation = Grab_Holder.rotation;
                Grab_Check.collider.gameObject.transform.parent = Grab_Holder;
                Grab_Check.collider.gameObject.transform.position = Grab_Holder.position;
                Grab_Check.collider.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0f);
                Grab_Check.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Grab_Check.collider.gameObject.transform.parent = null;
                Grab_Check.collider.gameObject.transform.localScale = new Vector3(1f, 1f, 0f);
                Grab_Check.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }

        }

    }

}