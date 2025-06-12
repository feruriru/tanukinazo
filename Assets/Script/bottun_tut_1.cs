using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button_tut_1 : MonoBehaviour
{
    public void ClickStartButton()
    {
        SceneManager.LoadScene("Tutorial-1.1");
    }
}
