using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stefaniController : MonoBehaviour
{


    public bool isGrounded;
    private float speed;
    public float rotSpeed;
    public float jumpHeight;
    int isInjured = 0;
    private float r_speed = 1.5f; // running speed
    private float w_speed = 1.0f; // walking speed
    private float rot_speed = 1.0f; //rotation speed
    public Vector3 position;
    Rigidbody rb;
    Animator anim;
    private int level=0;
    //Text text_score;
    static int score;
    private float gravity = 12;
    private float verticalvelocity;
    public string state;
    private static stefaniController instance;
   // public AudioSource punch;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //text_score = GetComponent<>()
        score = 0;
        isGrounded = true;
      //indicate that we are in the ground

    }




    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            //moving forward and backward
            if (Input.GetKey(KeyCode.W) && isInjured <= 5)
            {
                speed = w_speed;

                movementControl("Walking");
            }
            else if (Input.GetKey(KeyCode.W) && isInjured > 5)
            {
                speed = w_speed;
                movementControl("Injured_w");


            }
           /* else if (Input.GetKey(KeyCode.F))
            {

                movementControl("hit_head");
                isInjured++;


            }*/
            else if (Input.GetKey(KeyCode.G))
            {
                movementControl("Punch");
                //punch.Play();
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(0, jumpHeight * Time.deltaTime, 0);
                movementControl("Jumping");

                isGrounded=false;
            }
            else if (Input.GetKey(KeyCode.Q) && isInjured <= 5)
            {

                //text_score.text="Score : "+text_score;
                speed = r_speed;
                movementControl("Running");

                //isGrounded=false;
            }
            // here injured run
            else if (Input.GetKey(KeyCode.Q) && isInjured > 5)
            {

                speed = r_speed;
                movementControl("Injured_r");

                //isGrounded=false;
            }
            else if (Input.GetKey(KeyCode.A))
            {

                rotSpeed = rot_speed;

            }
            else if (Input.GetKey(KeyCode.D))
            {

                rotSpeed = rot_speed;
            }
            else
            {
                movementControl("Idle");
            }
        }
        var y = Input.GetAxis("Horizontal") * rotSpeed;
        var z = Input.GetAxis("Vertical") * speed;
        transform.Rotate(0, y, 0);
        transform.Translate(0, 0, z);
        // rb.AddForce(0,verticalvelocity,z);
       
    }
    
    public void movementControl(string state)
    {

        switch (state)
        {

            case "Walking":
                state = "walking";
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsHtoH", false);
                anim.SetBool("IsInjuredWalking", false);
                anim.SetBool("IsInjuredRunning", false);
                anim.SetBool("IsPunching", false);
                //anim.SetBool("IsTurnleft", false);
                anim.SetBool("IsIdle", false);
                break;

            case "hit_head":
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsHtoH", true);
                anim.SetBool("IsInjuredWalking", false);
                anim.SetBool("IsInjuredRunning", false);
                anim.SetBool("IsPunching", false);
                isInjured++;
                //anim.SetBool("IsTurnleft", false);

                break;
            case "Punch":
                state = "attacking";
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsHtoH", false);
                anim.SetBool("IsInjuredWalking", false);
                anim.SetBool("IsInjuredRunning", false);
                anim.SetBool("IsPunching", true);
                break;
            case "Injured_w":
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsHtoH", false);
                anim.SetBool("IsInjuredWalking", true);
                anim.SetBool("IsInjuredRunning", false);
                anim.SetBool("IsPunching", false);
                //anim.SetBool("IsTurnleft", false);

                break;


            case "Idle":
                state = "idle";
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsHtoH", false);
                anim.SetBool("IsInjuredWalking", false);
                anim.SetBool("IsInjuredRunning", false);
                //anim.SetBool("IsTurnleft", false);
                anim.SetBool("IsPunching", false);

                break;

            case "Jumping":
                state = "jumping";
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsJumping", true);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsHtoH", false);
                anim.SetBool("IsInjuredWalking", false);
                anim.SetBool("IsInjuredRunning", false);
                //anim.SetBool("IsTurnleft", false);
                anim.SetBool("IsPunching", false);


                break;

            case "Running":
                state="running";
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsHtoH", false);
                anim.SetBool("IsInjuredWalking", false);
                anim.SetBool("IsInjuredRunning", false);
                //anim.SetBool("IsTurnleft", false);
                anim.SetBool("IsPunching", false);
                break;

            case "Injured_r":
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsHtoH", false);
                anim.SetBool("IsInjuredWalking", false);
                anim.SetBool("IsInjuredRunning", true);
                //anim.SetBool("IsTurnleft", false);
                anim.SetBool("IsPunching", false);
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
}


   
