using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class stefHealth : MonoBehaviour {
    public const int Maxhealth = 100;
    public int currenthealth = Maxhealth;
    public GameObject gameover;
    public RectTransform healthbar;
    public Image[] lives;
    private int livecount = 0;

    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        if (currenthealth <= 0)
        {
            Destroy(lives[livecount]);
            livecount++;
            currenthealth = 100;
            if (livecount == 3)
            {
                //gameover.SetActive(true);
               gameover = Instantiate(gameover);
               new WaitForSeconds(10);
               SceneManager.LoadScene("Menus");

                
            }
        }
        healthbar.sizeDelta = new Vector2(currenthealth * 2, healthbar.sizeDelta.y);
    }
}
