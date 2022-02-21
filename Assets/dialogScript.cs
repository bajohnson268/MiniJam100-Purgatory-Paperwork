using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogScript : MonoBehaviour
{
    //List of strings linear until it reaches null
    public List<string> dialogs;

    Text dialog;
    public GameObject textBox;
    Coroutine goingThroughDialog;
    Coroutine typing;

    public int startingIndex = 29;

    private void Start()
    {
        
        dialog = textBox.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger && startingIndex < dialogs.Count) {

            textBox.SetActive(true);
            goingThroughDialog = StartCoroutine(goThroughDialog(dialogs));

        }

    }

    public void OnTriggerExit2D(Collider2D collision )
    {

        if (collision.CompareTag("Player") && !collision.isTrigger)
        {

            textBox.SetActive(false);

            if(goingThroughDialog != null)
                StopCoroutine(goingThroughDialog);

            if(typing != null)
                StopCoroutine(typing);

            dialog.text = null;

        }

    }

    public IEnumerator typeText(string text, Text dialog) {

        for (int i = 0; i < text.Length; i++) { 
        
            dialog.text = dialog.text + text[i];
            yield return new WaitForSeconds(.03f);
        
        }
    
    }

    public IEnumerator goThroughDialog(List<string> dialogs) { 
    
        int i = startingIndex;

        while (i < dialogs.Count && dialogs[i] != "null") {

            typing = StartCoroutine(typeText(dialogs[i], dialog));
            yield return new WaitForSeconds(dialogs[i].Length * .03f + 1.75f);

            if (i == dialogs.Count - 1 || dialogs[i+1] == "null")
            {
                break;
                //

            }

            else {

                dialog.text = null;

            }
            i++; 
        
        }

        if (i+2 < dialogs.Count && dialogs[i + 2] != "null") {

            startingIndex = i + 2;

        }
    
    }

}
