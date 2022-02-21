using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public void PlayButton() {

        SceneManager.LoadScene("Office");
    
    }

    public void QuitButton() {

        Application.Quit();   
    }

}
