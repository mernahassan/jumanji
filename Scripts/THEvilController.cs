using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THEvilController : MonoBehaviour {
	public GameObject player;
	static Animator anim;
    public string state;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = player.transform.position - this.transform.position;
		//float angle = Vector3.Angle(direction,this.transform.forward);
		if(Vector3.Distance(player.transform.position, this.transform.position) < 100  )
		{
			
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction), 0.1f);

			anim.SetBool("isIdle",false);
			if(direction.magnitude > 40)
			{
				this.transform.Translate(0,0,0.05f);
                state = "walk";
				anim.SetBool("isWalking",true);
				anim.SetBool("isAttacking",false);
				anim.SetBool("isClimbing",false);
				anim.SetBool("isRunning",false);
				

		
			}
			 else 
			{
                state = "attacking";
				anim.SetBool("isAttacking",true);
				anim.SetBool("isWalking",false);
				anim.SetBool("isClimbing",false);
				anim.SetBool("isRunning",false);
				
				

			}
			

		}
		else 
		{
			anim.SetBool("isIdle", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
			anim.SetBool("isClimbing",false);
			anim.SetBool("isRunning",false);
	
		}

		/*else 
		{
			anim.SetBool("isClimbing", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
			anim.SetBool("isRunning",false);
	
		}

		else
		{
			anim.SetBool("isRunning",true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);
			anim.SetBool("isClimbing",false);
			
			
		}*/

	}
}
