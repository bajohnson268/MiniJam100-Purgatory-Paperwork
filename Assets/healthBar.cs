using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    GameObject player;
    public Image bar;

    public void Start()
    {

        player = GameObject.Find("player");

        if (player == null) { 
        
            gameObject.SetActive(false);
        
        }

    }

    public void Update() {

        bar.fillAmount = (float)player.GetComponent<player2DTopdown>().health / player.GetComponent<player2DTopdown>().maxHealth;


    }

}
