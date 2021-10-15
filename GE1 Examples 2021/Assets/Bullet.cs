using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10;

    void Start () {
        Destroy(this.gameObject, 5);
    }

    void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

}