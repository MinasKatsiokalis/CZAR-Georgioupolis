using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCanvas : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    public GameObject rotation_ui;
    public GameObject movement_ui;

    public void Done()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void SettingsOn()
    {
        if(rotation_ui.activeSelf && movement_ui.activeSelf)
        {
            rotation_ui.SetActive(false);
            movement_ui.SetActive(false);
        }
        else
        {
            rotation_ui.SetActive(true);
            movement_ui.SetActive(true);
        }
    }
}
