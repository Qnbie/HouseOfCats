using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
        Debug.Log("reset");
    }
}
