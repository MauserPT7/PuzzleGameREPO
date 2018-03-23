using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float moveSpeed = 0.0f;
    public float maxMoveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public float deathDepth;

    [SerializeField]
    private bool grounded;

    [SerializeField]
    private float distance = 0.6f;


    Rigidbody2D myRB2D;

    public GameObject checkpoint1;
    public GameObject checkpoint2;
    public GameObject checkpoint3;
    public GameObject myCurrentCheckpoint;

    public LayerMask groundLayer;

    private SpriteRenderer _myRenderer;

    private Animator _myAnim;
    
    
    // Use this for initialization
    void Awake () 
	{
        myCurrentCheckpoint = checkpoint1;
        myRB2D = gameObject.GetComponent<Rigidbody2D>();
	    _myRenderer = gameObject.GetComponent<SpriteRenderer>();
	    _myAnim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        grounded = IsGrounded();

	   
	    
		if(transform.position.y <= -deathDepth)
        {
            transform.position = myCurrentCheckpoint.transform.position;
        }
	    
	    
	}

    // Use for physics calculations (rigidbodies)
    void FixedUpdate ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        float moveHorizontal = Input.GetAxis("Horizontal");
        
       
        moveSpeed = maxMoveSpeed;

        myRB2D.velocity = new Vector2(moveHorizontal * moveSpeed, myRB2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)
            && IsGrounded())
        {
            myRB2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        
        
        //Nick - Sprite Turning
        bool flipSprite = (_myRenderer.flipX ? (moveHorizontal > 0.01f) : (moveHorizontal < -0.01f));

        if (flipSprite)
        {
            _myRenderer.flipX = !_myRenderer.flipX;
        }
        
        //Nick Anim stuff
        _myAnim.SetBool("Grounded",IsGrounded());
        _myAnim.SetFloat("VelocityX", Mathf.Abs(myRB2D.velocity.x/maxMoveSpeed));
        // Nick - END   
    }

    public bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Spikes")
        {
            transform.position = myCurrentCheckpoint.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.name == "Checkpoint2")
        {
            myCurrentCheckpoint = checkpoint2;
        }

        if (trigger.gameObject.name == "Checkpoint3")
        {
            myCurrentCheckpoint = checkpoint3;
        }
    }
}