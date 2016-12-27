 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Controller2D))]
public class Player : MonoBehaviour {

    public float jumpHeight = 4;
    public float timetoJumpApex = 0.4f;

    float acclerationTimeAirborne = 0.2f;
    float acclerationTimeGrounded = 0.1f;

    Controller2D controller;
    float gravity = -20f;
    Vector2 velocity;
    float moveSpeed = 6f;
    float jumpVelocity = 8;

    float velocityXSmooththg;

    // Use this for initialization
    void Start () {
        controller = GetComponent<Controller2D>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timetoJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timetoJumpApex;
	}

    private void Update()
    {
        if(controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }

        float targetVelovity = input.x * moveSpeed;

        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelovity, ref velocityXSmooththg,controller.collisions.below?acclerationTimeGrounded:acclerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
}
