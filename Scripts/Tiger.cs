using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : MonoBehaviour {

	// Use this for initialization
    public GameObject player;
    static Animator anim;
    public bool isGrounded;
    public string state;
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = player.transform.position - this.transform.position;


        if (Vector3.Distance(player.transform.position, this.transform.position) < 60)
        {

            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("IsIdle", false);
            if (direction.magnitude > 20)
            {
                state = "walk";
                this.transform.Translate(0, 0, 0.2f);
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsHitting", true);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsSound", false);

            }
            else if (direction.magnitude < 20)
            {
                 state = "hit";
                anim.SetBool("IsHitting", true);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsSound", false);

            }
            else
            {
                state = "run";
                anim.SetBool("IsHitting", false);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsSound", false);


            }

        }
        else
        {
            state = "idle";
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsHitting", false);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsSound", false);


        }
	}
}
