using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    public void setOnClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void setOnClicked1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void setOnClicked2()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void setOnClicked3()
    {
        SceneManager.LoadScene("Main");
    }
}
