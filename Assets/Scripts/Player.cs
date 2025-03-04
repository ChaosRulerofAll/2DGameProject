using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
    //Creats a rigid body object
    Rigidbody2D body;

    //Creates serialized fields for adjustable numbers
    [SerializeField] private float accelerationPower;
    [SerializeField] private float jumpPower;
    [SerializeField] private float springPower;
    //Creates seriaized feilds that will help with detectinf if the player is on the ground
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask fallableLayer;
    [SerializeField] private LayerMask springLayer;

    [SerializeField] private Vector2 SpawnPoint;

    [SerializeField] private GameObject player;

    //A boolean to check facing direction of player. Will be used for sprite
    private bool isFacingRight;

    //Variables for keeping track of melons
    public int melonCount;
    int maxMelons;

    [SerializeField] private Text UI;

    public GameObject Watermelon;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        melonCount = 0;
        maxMelons = 1;
        transform.position = SpawnPoint;
        //Instantiate(Watermelon, new Vector2(3.5f,0.5f), Quaternion.identity);
    }

    // Update is called at a fixed rate
    void FixedUpdate()
    {
        //Move left
        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            body.AddForce(accelerationPower * -transform.right, ForceMode2D.Force);
        }
        //Move Right
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            body.AddForce(accelerationPower * transform.right, ForceMode2D.Force);
        }

        //Debugging Code
        UI.text = "Melons: " + melonCount.ToString() + "/" + maxMelons.ToString();
    }

    private void Update()
    {
        //Writen by Ilya
        //For going through the platforms
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("s is down!!!");
            //Physics.IgnoreLayerCollision(0, 9, true);
            //player.GetComponent<Collider2D>().excludeLayers = 9;
            Physics2D.IgnoreLayerCollision(0, 9, true);
        }
        if (Input.GetKeyUp("s") || Input.GetKeyUp(KeyCode.DownArrow))
        {
            //Debug.Log("s is up!!!");
            Physics2D.IgnoreLayerCollision(0, 9, false);
        }

        //Jump
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded())
        {
            body.AddForce(jumpPower * transform.up, ForceMode2D.Force);
            Physics2D.IgnoreLayerCollision(0, 9, true);
        }
        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space)))
        {
            Physics2D.IgnoreLayerCollision(0, 9, false);
        }

    }


    //Function that chacks if the player is grounded
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer)
            || Physics2D.OverlapCircle(groundCheck.position, 0.2f, fallableLayer);
    }
    //Function for when player dies
    private void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Gain a melon for grabbing a melon
        if (collision.gameObject.tag == "Melon")
        {
            melonCount++;
            Debug.Log("Current melons " + melonCount);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Spring Collision Code
        if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, springLayer))
        {
            body.AddForce(springPower * transform.up, ForceMode2D.Force);
        }
        if (collision.gameObject.tag == "Spikes")
        {
            die();
        }
    }
}
