using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private float vel_x;
    private float vel_y;
    public int max_speed_x;
    public int max_speed_y;
    public bool jump;
    private Rigidbody2D rb;
    private Animator animator;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        vel_x = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump") && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(vel_x, max_speed_y);
            animator.SetTrigger("Jump");
        }
        animator.SetFloat( "Velocity", System.Math.Abs(vel_x));
        rb.velocity = new Vector2(vel_x * max_speed_x, rb.velocity.y);
        
    }
}
