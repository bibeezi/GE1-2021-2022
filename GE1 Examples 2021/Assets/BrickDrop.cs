using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDrop : MonoBehaviour {

    System.Collections.IEnumerator Drop () {
        while(true) {
            GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            block.transform.position = new Vector3(0, 20, 0);
            block.AddComponent<Rigidbody>();

            yield return new WaitForSeconds(1);
        }
    }

    public void OnEnable() {
        StartCoroutine(Drop());
    }

    void Start () {

    }

    void Update () {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");
        Debug.Log(bricks.length);
    }

}