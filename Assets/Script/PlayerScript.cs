using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Controller2D))]
public class PlayerScript : MonoBehaviour
{
    Controller2D controller;
    Vector3 velocity;
    float gravity;
    float jumpVelocity;

    [SerializeField] float jumpHeight = 4f;
    [SerializeField] float timeToJumpApex = 0.4f;
    [SerializeField] float moveSpeed = 5f;

    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Controller2D>();
        //calculating gravity depending on jumpheight and timetojumpApex same with jumpvelocity
        gravity = (2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }
        velocity.x = input.x * moveSpeed;
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
