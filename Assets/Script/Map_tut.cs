using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map_tut : MonoBehaviour
{
    public void ClickStartButton()
    {
        SceneManager.LoadScene("Tutorial-1");
    }
}
