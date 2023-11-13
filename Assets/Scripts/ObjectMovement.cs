using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectMovement : MonoBehaviour
{

    //Where are the objects moving
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;

    //The positions of the stat and end
    protected Transform startLocation;
    protected Transform endLocation;


    private void Start()
    {
        //Inicialize the locations
        GetStartLocation();
        GetEndLocation();
    }

    protected void GetStartLocation()
    {
        //Getting the Start location
        startLocation = startPoint.GetComponent<Transform>();
    }

    protected void GetEndLocation()
    {
        //Getting the End location
        endLocation = endPoint.GetComponent<Transform>();
    }

}
