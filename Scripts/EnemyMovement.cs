using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Global Variables
    [SerializeField] GameObject[] point;
    int Index = 0;
    [SerializeField] float s = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, point[Index].transform.position) < .1f)
        {
            Index++;
            if (Index >= point.Length)
            {
                Index = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, point[Index].transform.position, s * Time.deltaTime);
    }
}
