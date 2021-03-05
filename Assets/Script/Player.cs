using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform boundary;
    private Text score;
    public int jumps;
    public int totalJumps = 3;
    public float jumpForce;
    public float jumpTime;
    public float jumpTimeCounter;
    public int points;
    public bool isGrounded;
    public bool isJumping;
    private Color colorT;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boundary = GameObject.Find("Boundary").GetComponent<Transform>();
        score = GameObject.Find("Text").GetComponent<Text>();
        colorT.a = 255;
        jumps = totalJumps;
    }

    private void Update()
    {
        Jump();
        LoseCondition();
        Points();
    }

    /// <summary>
    /// This is the lose condition, manages the end text score by applying color to the trasparent text..
    /// </summary>
    void LoseCondition()
    {
        if(transform.position.y <= boundary.transform.position.y)
        {
            score.color = colorT;
            score.text = "Points = " + points;
            Destroy(gameObject, 0.1f);
        }
    }

    /// <summary>
    /// This is how the score is determined and when the player will have the 4th jump.
    /// </summary>
    void Points()
    {
        points = Mathf.FloorToInt(transform.position.y);
        if (points >= 50)
            totalJumps = 4;
    }

    /// <summary>
    /// This is used to make a higher jump depending on how mutch the key has been held down & removes jumps if done in mid air.
    /// </summary>
    void Jump()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space) || jumps >= 1 && Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == false)
                jumps--;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector3.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector3.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    /// <summary>
    /// This checks if the player is on the platform.
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8 && isGrounded == false)
        {
            isGrounded = true;
            jumps = totalJumps;
            Destroy(col.gameObject, 0.2f);
        }

    }

    /// <summary>
    /// This check if the player has left the platform.
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == 8 && isGrounded == true)
        {
            isGrounded = false;
        }

    }
}
