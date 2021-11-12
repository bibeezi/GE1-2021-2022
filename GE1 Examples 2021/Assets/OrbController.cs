using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    public GameObject AITank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "MainCamera")
        {
            col.GetComponent<FPSController>().enabled = false;
            AITank.GetComponent<TankController>().enabled = true;
            AITank.GetComponent<AITank>().enabled = false;
            GetComponent<RotateMe>().enabled = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        col.transform.position = Vector3.Lerp(col.transform.position, transform.position, Time.deltaTime);
        col.transform.rotation = Quaternion.Slerp(col.transform.rotation, AITank.transform.rotation, Time.deltaTime);
    }
}
