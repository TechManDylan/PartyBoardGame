using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    
    [SerializeField] private Waypoints1 wPoints1;
    [SerializeField] private Waypoints2 wPoints2;
    [SerializeField] private Waypoints3 wPoints3;
    [SerializeField] private Waypoints4 wPoints4;

    [SerializeField] private GameObject wPoints1Obj;
    [SerializeField] private GameObject wPoints2Obj;
    [SerializeField] private GameObject wPoints3Obj;
    [SerializeField] private GameObject wPoints4Obj;

    private int waypointIndex;


    private void Start()
    {
        wPoints1 = wPoints1.GetComponent<Waypoints1>();
        wPoints2 = wPoints1.GetComponent<Waypoints2>();
        wPoints3 = wPoints1.GetComponent<Waypoints3>();
        wPoints4 = wPoints1.GetComponent<Waypoints4>();
    }

    private void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, wPoints1.waypoints[waypointIndex].position, playerSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, wPoints1.waypoints[waypointIndex].position) < 0.01f)
        {
            waypointIndex++;
        }
    }



    void ChoosePath()
    {
        Debug.Log("Choose a path: Left arrow key for path 0, Right arrow key for path 1");

        // Wait for player input
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                break;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                break;
            }
        }
    }


}
