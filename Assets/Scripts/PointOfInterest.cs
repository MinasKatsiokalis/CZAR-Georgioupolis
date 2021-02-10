using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{   
    //the prefab that will be used in the POI location
    public GameObject prefab;
    private GameObject poi_prefab;
    private bool isMoved;

    // Start is called before the first frame update
    void Start()
    {
        isMoved = false;
        if (prefab != null)
        {
            poi_prefab = Instantiate(prefab);
            poi_prefab.SetActive(false);
            poi_prefab.transform.parent = this.gameObject.transform;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoved)
        {
            poi_prefab.transform.position = this.gameObject.transform.position;
            poi_prefab.SetActive(true);
            isMoved = true;
        }
    }
}
