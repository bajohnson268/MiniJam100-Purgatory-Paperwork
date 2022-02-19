using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogScript : MonoBehaviour
{

    public string text = "testing";

    public List<string> dialogs;

    public string[] dialogs1;

    Text dialog;
    public GameObject textBox;

    Coroutine typingDialog;

    private void Start()
    {
        
        dialog = textBox.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        textBox.SetActive(true);
        typingDialog = StartCoroutine(typeText(text, dialog));

    }

    public void OnTriggerExit2D(Collider2D collision)
    {

        textBox.SetActive(false);
        StopCoroutine(typingDialog);
        dialog.text = null;

    }

    public IEnumerator typeText(string text, Text dialog) {

        for (int i = 0; i < text.Length; i++) { 
        
            dialog.text = dialog.text + text[i];

            yield return new WaitForSeconds(.05f);
        
        }
    
    }

}
