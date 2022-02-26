using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogBox : MonoBehaviour
{
    public List<string> dialogs;

    public Text dialog;
    Coroutine goingThroughDialog;
    Coroutine typing;
    Coroutine skip;
    Coroutine skipThroughDialog;
    bool skipping = false;

    public int startingIndex = 0;

    private void Start()
    {

        //dialog = transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>();

    }

    public void playerEnter(List<string> dialogs, int startingIndex) { 
    
        this.dialogs = dialogs;
        this.startingIndex = startingIndex;
        StopAllCoroutines();

        //textBox.SetActive(true);
        goingThroughDialog = StartCoroutine(goThroughDialog(dialogs));

    }

    public int playerExit() {

        dialogs = null;
        dialog.text = null;
        StopAllCoroutines();

        return startingIndex;
    
    }

    public IEnumerator typeText(string text, Text dialog)
    {

        skip = StartCoroutine(skipText(text));

        for (int i = 0; i <= text.Length; i++)
        {

            dialog.text = text.Substring(0, i);
            yield return new WaitForSeconds(.05f);
            if (skipping)
            {

                break;

            }

        }

        skipping = false;
        StopCoroutine(skip);

    }

    public IEnumerator skipText(string text)
    {

        while (true)
        {

            if (Input.GetKeyDown("e"))
            {

                skipping = true;
                dialog.text = text;

            }

            yield return new WaitForSeconds(.001f);

        }

    }

    public IEnumerator goThroughDialog(List<string> dialogs)
    {

        //skipThroughDialog = StartCoroutine(skipDialog());

        while (startingIndex < dialogs.Count && dialogs[startingIndex] != "null")
        {

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

            else
            {

                dialog.text = null;

            }
            startingIndex++;

        }

        if (startingIndex + 2 < dialogs.Count && dialogs[startingIndex + 2] != "null")
        {

            startingIndex = startingIndex + 2;

        }

        StopCoroutine(skipThroughDialog);

    }

    public IEnumerator skipDialog()
    {

        int x = 0;

        while (x < 1500)
        {

            if (Input.GetKeyDown("e"))
            {

                break;

            }

            yield return new WaitForSeconds(.001f);
            x++;

        }

    }
}
