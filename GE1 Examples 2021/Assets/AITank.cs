using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour {

    public float radius = 10;
    public int numWaypoints = 6;
    public int current = 0;
    List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;
    public float rotSpeed = 180f;

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            // Task 1
            // Put code here to draw the gizmos
            // Use sin and cos to calculate the positions of the waypoints 
            // You can draw gizmos using
            // Gizmos.color = Color.green;
            // Gizmos.DrawWireSphere(pos, 1);
            float theta = (2.0f * Mathf.PI) / (float) numWaypoints;

            for(int i = 0; i < numWaypoints; i++) {

                float angle = theta * i;
                float x = Mathf.Sin(angle) * radius;
                float z = Mathf.Cos(angle) * radius;

                Vector3 pos = new Vector3(x, 0.5f, z);

                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(pos, 1);
            }
        }
    }

    // Use this for initialization
    void Awake () {
        // Task 2
        // Put code here to calculate the waypoints in a loop and 
        // Add them to the waypoints List
        float theta = (2.0f * Mathf.PI) / (float) numWaypoints;

        for(int i = 0; i < numWaypoints; i++) {

            float angle = theta * i;
            float x = Mathf.Sin(angle) * radius;
            float z = Mathf.Cos(angle) * radius;

            Vector3 pos = new Vector3(x, 0.5f, z);

            waypoints.Add(pos);

            // Debug.Log(waypoints[i]);
        }
    }

    // Update is called once per frame
    void Update () {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one
        Quaternion rotTarget = Quaternion.LookRotation(waypoints[current] - transform.position);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, rotSpeed * Time.deltaTime);

        if(transform.rotation == rotTarget) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(Vector3.Distance(waypoints[current], transform.position) < 1f) {
            current++;
        }

        if(current == waypoints.Count) {
            current = 0;
        }

        // Task 4
        // Put code here to check if the player is in front of or behind the tank
        Vector3 distance = player.position - transform.position;
        float dot = Vector3.Dot(transform.forward, distance);
        
        if(dot > 0) {
            GameManager.Log("The player is in front");
        }
        else if(dot < 0) {
            GameManager.Log("The player is behind!");
        }

        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        // You can print stuff to the screen using:
        // GameManager.Log("Hello from the AI tank");
        float distanceFloat = Vector3.Distance(player.position, transform.position);
        float angle = Mathf.Acos(dot / distanceFloat) * Mathf.Rad2Deg;

        if(angle < 45 && distanceFloat < 10f){
            GameManager.Log("Enemy spotted!");
        }
        else {
            GameManager.Log("The enemy is hidden!");
        }
        
    }
}

