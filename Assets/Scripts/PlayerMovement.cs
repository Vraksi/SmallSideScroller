using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Running")]
    [SerializeField] float runSpeed = 5f;

    [Header("Jumping")]
    [SerializeField] float jumpVelocity = 15f;
    [SerializeField] [Range(0f, 1f)] float floatingFactor = 1f; 

    private Rigidbody2D rb2d;
    private float xScale;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        xScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        Jump();
    }

    private void Run()
    {
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, rb2d.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpVelocity);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if(rb2d.velocity.y > 0)
            rb2d.velocity += new Vector2(rb2d.velocity.x, -rb2d.velocity.y * floatingFactor);
        }
    }

    private void FlipSprite()
    {

        // TODO SKAL GØRES MERE DYNAMISK 
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -xScale;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = xScale;
        }
        transform.localScale = characterScale;

        //if (Mathf.Sign(rb2d.velocity.x) > 0)
        //{
        //    facingRight = true;
        //}

        //if (Mathf.Sign(rb2d.velocity.x) > 0 && facingRight)
        //{
        //    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //    facingRight = false;
        //}
        //if(Mathf.Sign(rb2d.velocity.x) < 0 && facingRight)
        //{
        //    transform.localScale = new Vector3(-0.06669401f, transform.localScale.y, transform.localScale.z);
        //    facingRight = true;
        //}
    }
}
