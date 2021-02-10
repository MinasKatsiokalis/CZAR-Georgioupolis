using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{   
    public GameObject signs;

    public void ShowInfoSigns()
    {
        signs.SetActive(!signs.activeSelf);
    }
}
