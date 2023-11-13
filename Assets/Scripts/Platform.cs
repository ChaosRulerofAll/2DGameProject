using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : ObjectMovement
{

    [SerializeField] private GameObject platform;

    private bool isGoingRight = true;


    // Start is called before the first frame update
    void Start()
    {

        platform.GetComponent<Transform>().position = startLocation.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
