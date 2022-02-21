using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{

    [SerializeField] string sceneName = "ERROR";

    bool playerIn = false;
    GameObject player;

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerIn) {

            playerStats.health = player.GetComponent<character>().health;
            SceneManager.LoadScene(sceneName);
        
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) { 
        
            playerIn = true;
            player = collision.gameObject;
        
        }

    }

    public void OnTriggerExit2D(Collider2D collision) {

        if (collision.CompareTag("Player"))
        {

            playerIn = false;
            player = null;

        }

    }

}
