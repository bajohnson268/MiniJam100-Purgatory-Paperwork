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
    Coroutine skip;
    Coroutine skipThroughDialog;

    bool skipping = false;

    public int startingIndex = 0;

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

    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !collision.isTrigger && textBox.activeSelf)
        {

            textBox.SetActive(false);
            StopAllCoroutines();
            dialog.text = null;
            //skipping = true;

        }

    }

    public IEnumerator typeText(string text, Text dialog) {

        skip = StartCoroutine(skipText(text));

        for (int i = 0; i <= text.Length; i++) { 
        
            dialog.text = text.Substring(0,i);
            yield return new WaitForSeconds(.05f);
            if (skipping) {

                break;
            
            }
        
        }

        skipping = false;
        StopCoroutine(skip);
    
    }

    public IEnumerator skipText(string text) {

        while (true) {

            if (Input.GetKeyDown("e")) {

                skipping = true;
                dialog.text = text;

            }

            yield return new WaitForSeconds(.001f);
        
        }
    
    } 

    public IEnumerator goThroughDialog(List<string> dialogs) {

        //skipThroughDialog = StartCoroutine(skipDialog());

        while (startingIndex < dialogs.Count && dialogs[startingIndex] != "null") {

            //typing = StartCoroutine(typeText(dialogs[startingIndex], dialog));

            yield return typing = StartCoroutine(typeText(dialogs[startingIndex], dialog));

            yield return new WaitForSeconds(.05f);

            yield return skipThroughDialog = StartCoroutine(skipDialog());

            yield return new WaitForSeconds(.05f);

            //yield return new WaitForSeconds(dialogs[startingIndex].Length * .05f + 1.75f);

            if (startingIndex == dialogs.Count - 1 || dialogs[startingIndex + 1] == "null")
            {
                break;
                //

            }

            else {

                dialog.text = null;

            }
            startingIndex++; 
        
        }

        if (startingIndex + 2 < dialogs.Count && dialogs[startingIndex + 2] != "null") {

            startingIndex = startingIndex + 2;

        }

        StopCoroutine(skipThroughDialog);
    
    }

    public IEnumerator skipDialog() {

        int x = 0;

        while (x < 1500) {

            if (Input.GetKeyDown("e"))
            {

                break;

            }

            yield return new WaitForSeconds(.001f);
            x++;
        
        }
    
    }

}
