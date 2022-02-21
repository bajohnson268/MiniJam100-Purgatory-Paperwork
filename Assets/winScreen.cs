using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winScreen : MonoBehaviour
{

    public Text text;

    public void Start()
    {

        text.text = "Ending: " + playerStats.winCase;

    }

}
