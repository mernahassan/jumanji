using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMen : MonoBehaviour {

    public GameObject player;
    static Animator anim;
    public bool isGrounded;
    public string state ;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 direction = player.transform.position - this.transform.position;
        /*float angel = Vector3.Angle(direction, this.transform.forward);*/
        if (Vector3.Distance(player.transform.position, this.transform.position) < 30)
        {
           
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
           
            anim.SetBool("IsIdle", false);
            if (direction.magnitude > 10)
            {
                state = "walking";
                this.transform.Translate(0, 0, 0.2f);
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsReactLeft", false);
                anim.SetBool("IsReactRight", false);
                anim.SetBool("IsHandAttack", false);
                anim.SetBool("IsDying", false);

            }
            else
            {
                state = "attacking";
                anim.SetBool("IsAttacking", true);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsReactLeft", false);
                anim.SetBool("IsReactRight", false);
                anim.SetBool("IsHandAttack", false);
                anim.SetBool("IsDying", false);

            }

        }
        else
        {
            state = "idle";
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsReactLeft", false);
            anim.SetBool("IsReactRight", false);
            anim.SetBool("IsHandAttack", false);
            anim.SetBool("IsDying", false);

        }
        /*  else 
          {
              anim.SetBool("IsJumping", true);
              anim.SetBool("IsIdle", false);
              anim.SetBool("IsWalking", false);
              anim.SetBool("IsAttacking", false);
              anim.SetBool("IsRunning", false);
              anim.SetBool("IsReactLeft", false);
              anim.SetBool("IsReactRight", false);
              anim.SetBool("IsHandAttack", false);
              anim.SetBool("IsDying", false);
          }
          else{
              anim.SetBool("IsRunning", true);
              anim.SetBool("IsJumping", false);
              anim.SetBool("IsIdle", false);
              anim.SetBool("IsWalking", false);
              anim.SetBool("IsAttacking", false);
              anim.SetBool("IsReactLeft", false);
              anim.SetBool("IsReactRight", false);
              anim.SetBool("IsHandAttack", false);
              anim.SetBool("IsDying", false);

          }
          else{
              anim.SetBool("IsReactLeft", true);
              anim.SetBool("IsRunning", false);
              anim.SetBool("IsJumping", false);
              anim.SetBool("IsIdle", false);
              anim.SetBool("IsWalking", false);
              anim.SetBool("IsAttacking", false);
              anim.SetBool("IsReactRight", false);
              anim.SetBool("IsHandAttack", false);
              anim.SetBool("IsDying", false);


          }
          else
               {
              anim.SetBool("IsReactRight", true);
              anim.SetBool("IsJumping", false);
              anim.SetBool("IsIdle", false);
              anim.SetBool("IsWalking", false);
              anim.SetBool("IsAttacking", false);
              anim.SetBool("IsReactLeft", false);
              anim.SetBool("IsHandAttack", false);
              anim.SetBool("IsDying", false);

          }
          else{
              anim.SetBool("IsHandAttack", true);
              anim.SetBool("IsJumping", false);
              anim.SetBool("IsIdle", false);
              anim.SetBool("IsWalking", false);
              anim.SetBool("IsAttacking", false);
              anim.SetBool("IsReactLeft", false);
              anim.SetBool("IsHandAttack", false);
              anim.SetBool("IsDying", false);

          }
          else{

              anim.SetBool("IsDying", true);
              anim.SetBool("IsHandAttack", false);
              anim.SetBool("IsJumping", false);
              anim.SetBool("IsIdle", false);
              anim.SetBool("IsWalking", false);
              anim.SetBool("IsAttacking", false);
              anim.SetBool("IsReactLeft", false);
              anim.SetBool("IsHandAttack", false);

          }*/





    }
}
