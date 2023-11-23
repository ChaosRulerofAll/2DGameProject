using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : ObjectMovement
{

    [SerializeField] private GameObject platform;

    private Vector2 move;


    // Start is called before the first frame update
    void Start()
    {

        move = new Vector2(GetEndLocation().position.x - GetStartLocation().position.x, GetEndLocation().position.y - GetStartLocation().position.y);

        platform.GetComponent<Transform>().position = GetStartLocation().position;

        moveSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isGoingRight)
        {
            //Debug.Log("isGoingRight");
            platform.transform.Translate(move * moveSpeed * Time.deltaTime);
        }
        else if (!isGoingRight)
        {
            //Debug.Log("isNotGoingRight");
            platform.transform.Translate(-move * moveSpeed * Time.deltaTime);
        }

        if (GetStartLocation().position.y > platform.transform.position.y 
            || platform.transform.position.y > GetEndLocation().position.y)
        {
            isGoingRight = !isGoingRight;
        }

    }
}
