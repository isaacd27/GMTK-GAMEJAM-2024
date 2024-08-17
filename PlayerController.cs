using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Set variables for player input and speed
    public bool isdead = false;
    public float speed = 1.0f;
    public float horizontalInput;

    public Slimeball slimeDecay;

    public bool faceleft;
    public float size = 1.0f;

    // Set Variables for player jump and fall
    public float jumpForce = 0.25f;
    bool isGrounded;
    bool isFalling;
    private Rigidbody2D rb;

    // Set Boundaries
    public float yBoundary = 15.0f;

    //References
    public UIbehaviour uIbehaviour;
    public Animator anim;
    private bool isPaused;

    void Start()
    {
        // Access player's Rigidbody
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrounded = true;
        Cursor.visible = false;
        isPaused = !isPaused;
    }

    // Update is called once per frame
    void Update()
    {
        //controls shouldn't work while dead by adding an if(!isdead) surrounding

        if (size == 0.0f)
        {
            size = 0.1f;
            Debug.Log("Invalid size");
        }

        if (Input.GetKeyDown(KeyCode.Z) && size > 1f)
        {
            Debug.Log("Forced Decrease/Discarded slime");
            //instantiate discarded slimeball here
            decreaseSize(1.0f);
            decreaseMass(0.2f);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Forced Increase");
            increaseSize(1.0f);
            increaseMass(0.2f);
        }
        if (!faceleft)
        {
            transform.localScale = new Vector2(size, size);
        }
        else
        {
            transform.localScale = new Vector2(-size, size);
        }


        // set horizontal input and translate player movement
        horizontalInput = Input.GetAxis("Horizontal");
        //add /size to add a feeling of weight to being bigger
        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speed);

        // set SpeedX in animator as absolute value of horizontal input
        anim.SetFloat("SpeedX", Mathf.Abs(horizontalInput));

        // face the player sprite in the correct direction
        if (horizontalInput < 0f)
        {
            transform.localScale = new Vector2(-1 * size, size);
            faceleft = true;
        }

        if (horizontalInput > 0f)
        {
            transform.localScale = new Vector2(1 * size, size);
            faceleft = false;
        }
        // set function for fall out of boundary
        if (transform.position.y < -yBoundary)
        {
            // respawn character at spawn
            transform.position = new Vector2(0, -1.25f);
        }
        // Jump method
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            //May want to have the size/2 or some other way to prevent this from getting outta control.
            rb.AddForce(Vector2.up * jumpForce * 1000 * size, ForceMode2D.Force);
            isGrounded = false;
        }

        // set Jumping bool in animator as opposite of isGrounded bool

        anim.SetBool("Jumping", !isGrounded);

        // Falling method
        if (rb.velocity.y < 0) 
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        // set Falling bool in animator as isFalling bool
        anim.SetBool("Falling", isFalling);

        if ((Input.GetKeyDown(KeyCode.Escape)) && (!isPaused))
        {
            uIbehaviour.Pause();
            Cursor.visible = true;
            isPaused = !isPaused;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape)) && (isPaused))
        {
            uIbehaviour.Resume();
            Cursor.visible = false;
            isPaused = !isPaused;
        }
    }

    // simple ground detection
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            die();
            //Call Respawning function here.
            uIbehaviour.Retry();
        }
    }
    public float getSize()
    {
        return size;
    }

    public void increaseSize(float s)
    {
        size += s;
    }

    public void decreaseSize(float s)
    {
        size -= s;
    }

    public void increaseMass(float mass)
    {
        rb.mass += mass;
    }

    public void decreaseMass(float mass)
    {
        rb.mass -= mass;
    }
    public void die()
    {
        isdead = true;
    }
}
