using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public int count;

    System.Collections.IEnumerator Spawn() {
        while(true) {
            if(count < 5) {
                float x = Random.Range(-20, 20);
                float z = Random.Range(-20, 20);
                GameObject enemy = Instantiate(prefab, new Vector3(x, transform.position.y, z), Quaternion.identity);
                count++;
                yield return new WaitForSeconds(1);
            }
            else {
                yield return null;
            }
        }
    }
    public void OnEnable () {
        StartCoroutine(Spawn());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = GameObject.FindGameObjectsWithTag("enemy").Length;
    }
}
