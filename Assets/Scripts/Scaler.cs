using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public Transform scaler;
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = scaler.rotation;
        this.transform.position = scaler.position;
        this.transform.localScale = scaler.localScale;
    }
}
