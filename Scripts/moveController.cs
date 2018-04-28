using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveController : MonoBehaviour {


	public bool isGrounded;
    private float speed;
    public float rotSpeed;
    public float jumpHeight;
	int isInjured=0;
    //walk speed
	private float r_speed = 12.00f;
    private float w_speed = 9.00f; //rotation speed
    private float rot_speed = 3.00f; 
	int p=0;
	Rigidbody rb;
    Animator anim;
	static float original_x ;
	static float original_y ;
	static float original_z ;
	//Text text_score;
	static int score;
	float velo;

	private Vector3 startPoint = Vector3.zero;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
		//text_score = GetComponent<text_score>()
		//score=0;
        isGrounded = true;
		velo=rb.velocity.y;
		startPoint= transform.position;//indicate that we are in the ground
        //original_x=transform.position.x;
		//original_y=transform.position.y;
		//original_z=transform.position.z;
	}
	

	void movementControl(string state) {
		
        switch (state)
        {

		case "Walking":
		 anim.SetBool("IsWalking", true); 
		 anim.SetBool("IsIdle", false);
		 anim.SetBool("IsJumping", false);
		 anim.SetBool("IsRunning", false);
		 anim.SetBool("IsHtoH", false);
		 anim.SetBool("IsInjuredWalking", false);
		 anim.SetBool("IsInjuredRunning", false);
		 anim.SetBool("IsPunish", false);
		 

		 //anim.SetBool("IsTurnleft", false);
		 
        break;

		case "hit_head":
		 anim.SetBool("IsWalking", false); 
		 anim.SetBool("IsIdle", false);
		 anim.SetBool("IsJumping", false);
		 anim.SetBool("IsRunning", false);
		 anim.SetBool("IsHtoH", true);
		 anim.SetBool("IsInjuredWalking", false);
		 anim.SetBool("IsInjuredRunning", false);
		 anim.SetBool("IsPunish", false);

		 //anim.SetBool("IsTurnleft", false);
		 
        break;

		case "Injured_w":
		 anim.SetBool("IsWalking", false); 
		 anim.SetBool("IsIdle", false);
		 anim.SetBool("IsJumping", false);
		 anim.SetBool("IsRunning", false);
		 anim.SetBool("IsHtoH", false);
		 anim.SetBool("IsInjuredWalking", true);
		 anim.SetBool("IsInjuredRunning", false);
		 anim.SetBool("IsPunish", false);

		 //anim.SetBool("IsTurnleft", false);
		 
        break;
		

        case "Idle":
		 anim.SetBool("IsIdle", true);
	     anim.SetBool("IsWalking", false);
		 anim.SetBool("IsJumping", false);
	  	 anim.SetBool("IsRunning", false);
		 anim.SetBool("IsHtoH", false);
		 anim.SetBool("IsInjuredWalking", false);
		 anim.SetBool("IsInjuredRunning", false);
		 anim.SetBool("IsPunish", false);
		 //anim.SetBool("IsTurnleft", false);


        break;

		case "Jumping":
		 anim.SetBool("IsIdle", false);
	     anim.SetBool("IsWalking", false);
		 anim.SetBool("IsJumping", true);
		 anim.SetBool("IsRunning", false);
		 anim.SetBool("IsHtoH", false);
		 anim.SetBool("IsInjuredWalking", false);
		 anim.SetBool("IsInjuredRunning", false);
		 anim.SetBool("IsPunish", false);
		 //anim.SetBool("IsTurnleft", false);

 

        break;

		case "Running":
		anim.SetBool("IsIdle", false);
	    anim.SetBool("IsWalking", false);
		anim.SetBool("IsJumping", false);
		anim.SetBool("IsRunning", true);
		anim.SetBool("IsHtoH", false);
		anim.SetBool("IsInjuredWalking", false);
		anim.SetBool("IsInjuredRunning", false);
		anim.SetBool("IsPunish", false);
		//anim.SetBool("IsTurnleft", false);

		break;

		case "Injured_r":
		anim.SetBool("IsIdle", false);
	    anim.SetBool("IsWalking", false);
		anim.SetBool("IsJumping", false);
		anim.SetBool("IsRunning", false);
		anim.SetBool("IsHtoH", false);
		anim.SetBool("IsInjuredWalking", false);
		anim.SetBool("IsInjuredRunning", true);
		anim.SetBool("IsPunish", false);
		//anim.SetBool("IsTurnleft", false);

		break;

		case "punish":
		anim.SetBool("IsIdle", false);
	    anim.SetBool("IsWalking", false);
		anim.SetBool("IsJumping", false);
		anim.SetBool("IsRunning", false);
		anim.SetBool("IsHtoH", false);
		anim.SetBool("IsInjuredWalking", false);
		anim.SetBool("IsInjuredRunning", false);
		anim.SetBool("IsPunish", true);
		//anim.SetBool("IsTurnleft", false);

		break;

		/*case "Turn_left":
		anim.SetBool("IsIdle", false);
	    anim.SetBool("IsWalking", false);
		anim.SetBool("IsJumping", false);
		anim.SetBool("IsRunning", false);
		anim.SetBool("IsTurnleft", true);

		break;*/

		}

	}



	// Update is called once per frame
	void Update () {
		
    if (rb.velocity.y>=velo)
   {
		//moving forward and backward
		if (Input.GetKey(KeyCode.W)&&isInjured<=5) 
		{
			speed = w_speed;
			movementControl("Walking");
			//transform.Rotate(0, -60, 0);
			rb.AddForce(Vector3.forward*speed);
			
	    }


		else if (Input.GetKey(KeyCode.W)&&isInjured>5) 
		{
			speed = w_speed;
			movementControl("Injured_w");
			rb.AddForce(Vector3.forward*speed);

		}

		else if (Input.GetKey(KeyCode.F)) 
		{
			
			movementControl("hit_head");
			isInjured++;

		}
		else if (Input.GetKey(KeyCode.X)) 
		{
			
			movementControl("punish");
			//isInjured++;

		}
		else if (Input.GetKey(KeyCode.G)) 
		{
			
			transform.position=startPoint;
			//isInjured++;

		}



		else if(Input.GetKey(KeyCode.Space))
		{
			movementControl("Jumping");
			rb.AddForce(0,jumpHeight*Time.deltaTime,0);
			
			//anim.SetBool("IsWalking", false);
			//anim.SetBool("IsIdle", false);
			

			//isGrounded=false;
		}
		else if(Input.GetKey(KeyCode.Q)&&isInjured<=5)
		{
			
			speed = r_speed;
			//var z = Input.GetAxis("Vertical");
			//transform.Translate(0, 0, z);
			movementControl("Running");
			rb.AddForce(Vector3.forward*speed);
			//var y = Input.GetAxis("Horizontal") * rotSpeed; 
	        //transform.Rotate(0, y, 0);
			

			//isGrounded=false;
		}else if(Input.GetKey(KeyCode.S))
		{
			
			speed = r_speed;
			//var z = Input.GetAxis("Vertical");
			//transform.Translate(0, 0, z);
			movementControl("Running");
			rb.AddForce(Vector3.back*speed);
			//var y = Input.GetAxis("Horizontal") * rotSpeed; 
	        //transform.Rotate(0, y, 0);
			

			//isGrounded=false;
		}
		// here injured run
		else if(Input.GetKey(KeyCode.Q)&&isInjured>5)
		{
			
			speed = r_speed;
			movementControl("Injured_r");
			rb.AddForce(Vector3.forward*speed);
			//anim.SetBool("IsWalking", false);
			//anim.SetBool("IsIdle", false);
			//movementControl("Injured_r");

			//isGrounded=false;
		}
		
		else if(Input.GetKey(KeyCode.A))
		{
			
			//rotSpeed = rot_speed;
			speed = r_speed;
			//movementControl("Turnleft");
			//var m = Input.GetAxis("Horizontal");
			//transform.Rotate(0, m+m, 0);
			//p=p+1;
			//if(p>0)
			//{
				movementControl("Running");
			    rb.AddForce(Vector3.left*speed);
			//}
			
			//movementControl("Running");
			//rb.AddForce(Vector3.left*speed);
			//movementControl("Turn_left");
			
		}
		else if(Input.GetKey(KeyCode.D))
		{
			
			//rotSpeed = rot_speed;
			speed = r_speed;
			movementControl("Running");
			
			rb.AddForce(Vector3.right*speed);
		}
		else{
			movementControl("Idle");
		}

	}else{
		transform.position=startPoint;
		//transform.Translate(original_x,original_y , original_z);
		}
		
		
	
	//var z = Input.GetAxis("Vertical") * speed;
    //var y = Input.GetAxis("Horizontal") * rotSpeed; 
	//var yy = Input.GetAxis("Horizontal") * rotSpeed;
	//transform.Rotate(0, yy, 0);
	//transform.Translate(0, 0, z);



	}
}
