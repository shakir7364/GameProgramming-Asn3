using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private LayerMask whatIsGround; //List of layers that will determine what is a ground

    [SerializeField]
    private Transform groundLocation;

    [SerializeField]
    Text scoreText;

    private Rigidbody2D myRigidBody;

    private float speed; //Speed of player
    private float horizontalInput;
    private float groundRadius;
    private float jumpForce;
    private bool isPlayerTouchingGround;
    int score;

    // Use this for initialization
    void Start()
    {
        speed = 30f;
        groundRadius = 1f;
        jumpForce = 600f;
        score = 0;

        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerTouchingGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.AddForce(new Vector2(0, jumpForce));
        }
    }

    void FixedUpdate()
    {
        isPlayerTouchingGround = Physics2D.OverlapCircle(groundLocation.position, groundRadius, whatIsGround);
        horizontalInput = Input.GetAxis("Horizontal");
        myRigidBody.velocity = new Vector2(horizontalInput * speed, myRigidBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score += 1;
            scoreText.text = score.ToString();
        }
    }
}
