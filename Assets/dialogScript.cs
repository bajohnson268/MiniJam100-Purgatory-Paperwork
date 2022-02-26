using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogScript : MonoBehaviour
{
    //List of strings linear until it reaches null
    public List<string> dialogs;

    public GameObject textBox;
    dialogBox DB;

    public int startingIndex = 0;

    private void Start()
    {
        
        DB = textBox.GetComponent<dialogBox>();

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger && startingIndex < dialogs.Count) {

            textBox.SetActive(true);
            DB.playerEnter(dialogs, startingIndex);

        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger)
        {

            textBox.SetActive(false);
            startingIndex = DB.playerExit();

        }

    }


}
