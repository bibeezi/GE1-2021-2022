using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int fireRate = 5;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // bool shooting = false;
    
    System.Collections.IEnumerator Shoot() {
        while(true) {
            if(Input.GetAxis("Fire1") > 0) {
                GameObject b = GameObject.Instantiate<GameObject>(bulletPrefab);
                b.transform.position = bulletSpawn.transform.position;
                b.transform.rotation = bulletSpawn.rotation;

                yield return new WaitForSeconds(1 / (float) fireRate);
            }
            else {
                yield return null;
            }
        }
    }

    public void OnEnable() {
        StartCoroutine(Shoot());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetAxis("Fire1") > 0) {
        //     // GameObject b = GameObject.Instantiate<GameObject>(bulletPrefab);
        //     // b.transform.position = bulletSpawn.transform.position;
        //     // b.transform.rotation = bulletSpawn.rotation;
            
        //     shooting = true;
        // }
        // else {
        //     shooting = false;
        // }
    }
}
