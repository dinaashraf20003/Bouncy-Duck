using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    //Global Variables
    [SerializeField] GameObject[] points;
    int currentpointIndex = 0;
    [SerializeField] float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, points[currentpointIndex].transform.position) < .1f)
        {
            currentpointIndex++;
            if (currentpointIndex >= points.Length)
            {
                currentpointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[currentpointIndex].transform.position, speed * Time.deltaTime);
    }
}
