using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    
    public Camera cam;

    public void ZoomIn()
    {   
        if(cam.fieldOfView > 3.5f)
        {
            cam.fieldOfView -= 0.1f;
        }
    }

    public void ZoomOut()
    {
        if (cam.fieldOfView < 6)
        {
            cam.fieldOfView += 0.1f;
        }
    }

    public void Hide()
    {
        if(!gameObject.active)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
       

    }
}
