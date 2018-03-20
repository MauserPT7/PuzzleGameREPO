using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float moveSpeed = 0.0f;
    public float maxMoveSpeed = 5.0f;
    public float jumpForce = 10.0f;

    Rigidbody2D myRB2D;

    public GameObject checkpoint1;

    public LayerMask groundLayer;

    // Use this for initialization
    void Start () 
	{
        myRB2D = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.y <= -10)
        {
            transform.position = checkpoint1.transform.position;
        }
	}

    // Use for physics calculations (rigidbodies)
    void FixedUpdate ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        float moveHorizontal = Input.GetAxis("Horizontal");

        moveSpeed = maxMoveSpeed;

        myRB2D.velocity = new Vector2(moveHorizontal * moveSpeed, myRB2D.velocity.y);
        
        if(myRB2D.velocity.x == 0
           && IsGrounded())
        {
            myRB2D.gravityScale = 0;
        } else {
            myRB2D.gravityScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space)
            && IsGrounded())
        {
            myRB2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        float distance = 0.6f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}