using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public const int Maxhealth = 100;
    public int currenthealth = Maxhealth;
    public RectTransform healthbar;
    private int livecount=0;
    stefaniController stef;
    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        if (currenthealth <= 0)
        {
               livecount++;
               
            if (gameObject.name!="stefani")
            {
                Destroy(gameObject); 
            }
            if (livecount == 3)
            {

                Debug.Log("Dead");
                currenthealth = 0;
            }
            else currenthealth = 100;
         }
        
        healthbar.sizeDelta = new Vector2(currenthealth * 2, healthbar.sizeDelta.y);
        Debug.Log(healthbar.sizeDelta);
    }
}
