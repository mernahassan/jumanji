using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maxthehelper : MonoBehaviour {

    public GameObject player;
    static Animator anim;

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
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.transform.position, this.transform.position) < 10 && angle < 30)
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.5f);
                anim.SetBool("isWalking", true);
                anim.SetBool("ispunching", false);
                anim.SetBool("isholdingdown", false);
            }
            else
            {
                anim.SetBool("ispunching", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isholdingdown", false);
            }
        }

        /*else 
        {
            anim.SetBool ("ispunching", true);
            anim.SetBool ("isWalking", false);
            anim.SetBool ("isholdingdown", true);
        }
    */
        else
        {
            anim.SetBool("isholdingdown", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("ispunching", false);
           
         }

    }
}
