using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject prefab;
    public int points = 6;
    public float radius = 1.1f;
    public int outpoints = 9;

    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        for(int j = 0; j < outpoints; j++) {
            float theta = (2.0f * Mathf.PI) / (float) points;

            for(int i = 0; i < points; i++) {

                float angle = theta * i;
                x = Mathf.Sin(angle) * radius;
                y = Mathf.Cos(angle) * radius;

                Vector3 targPos = new Vector3(x, y, 0);

                GameObject inst = Instantiate(prefab, targPos, Quaternion.identity);

                inst.transform.parent = transform;
            }

            points += 6;
            radius += 1.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
