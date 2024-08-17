using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Set variables for player input and speed
    public bool isdead = false;
    public float speed = 1.0f;
    public float horizontalInput;

    public bool faceleft;
    public float size = 1.0f;

    // Set Variables for player jump
    public float jumpForce = 0.25f;
    bool isGrounded;
    private Rigidbody2D rb;

    // Set Boundaries
    public float yBoundary = 15.0f;

    //References
    public UIbehaviour uIbehaviour;

    void Start()
    {
        // Access player's Rigidbody
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        Cursor.visible = false;
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
            Debug.Log("Forced Decrease");
            decreaseSize(1.0f);
        }

        if(Input.GetKeyDown(KeyCode.X)){
            Debug.Log("Forced Increase");
            increaseSize(1.0f);
        }
        
        if(!faceleft){
            transform.localScale = new Vector2(size, size);
        }else{
            transform.localScale = new Vector2(-size, size);
        }
    
        
        // set horizontal input and translate player movement
        horizontalInput = Input.GetAxis("Horizontal");
        //add /size to add a feeling of weight to being bigger
        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speed);

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

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uIbehaviour.Pause();
            Cursor.visible = true;
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
    public void die()
    {
        isdead = true;
    }
}
