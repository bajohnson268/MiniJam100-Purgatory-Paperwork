using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reaperDialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (playerStats.killedCats && playerStats.killedMonsters)
        {

            gameObject.GetComponent<dialogScript>().startingIndex = 58;


        }
        
        else if (playerStats.killedCats || playerStats.killedMonsters && !(playerStats.killedCats && playerStats.killedMonsters)) {

            gameObject.GetComponent<dialogScript>().startingIndex = 55;

        }

        else if (playerStats.catsPeace)
        {

            gameObject.GetComponent<dialogScript>().startingIndex = 36;

        }

    }

    private void Update()
    {

        if (GetComponent<dialogScript>().startingIndex == 52) {

            playerStats.winCase = "peacekeeper";
            SceneManager.LoadScene("win");
        
        }

        if (GetComponent<dialogScript>().startingIndex == 60)
        {

            playerStats.winCase = "Agent of Choas";
            SceneManager.LoadScene("win");

        }

    }


}
