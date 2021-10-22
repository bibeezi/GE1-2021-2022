using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float JumpSpeed = 10.0f;
    public bool disappear = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    System.Collections.IEnumerator Disappear() {
        while(true) {
            if(disappear == true) {
                yield return new WaitForSeconds(4);

                transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().drag = 1;

                Destroy(this.gameObject, 3);
            }
            else {
                yield return null;
            }
        }
    }

    public void OnEnable() {
        StartCoroutine(Disappear());
    }

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "bullet") {
            transform.GetChild(0).gameObject.GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().velocity = transform.up * JumpSpeed;

            disappear = true;
        }
    }
}
