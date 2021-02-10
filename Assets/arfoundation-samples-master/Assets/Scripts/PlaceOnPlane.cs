using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARSessionOrigin))]
[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARReferencePointManager))]

public class PlaceOnPlane : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the indicator's location.")]
    private GameObject placedPrefab;
    [SerializeField]
    private GameObject placementIndicator;
    [SerializeField]
    private GameObject spawn_button;
    [SerializeField]
    private GameObject done_button;
    [SerializeField]
    private GameObject settings_button;
    [SerializeField]
    private GameObject scan_txt;

    ARRaycastManager m_RaycastManager;
    ARSessionOrigin m_ARSessionOrigin;
    ARReferencePointManager m_ARReferencePointManager;

    private ARReferencePoint referencePoint;
    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        m_ARSessionOrigin = GetComponent<ARSessionOrigin>();
        m_ARReferencePointManager = GetComponent<ARReferencePointManager>();
        referencePoint = null;
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            touchPosition = new Vector2(mousePosition.x, mousePosition.y);
            return true;
        }
#else
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
#endif

        touchPosition = default;
        return false;
    }

    Pose hitPose;
    void Update()
    {
        if (placedPrefab == null)
            return;

        if (m_RaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), s_Hits, TrackableType.Planes))
        {   
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            hitPose = s_Hits[0].pose;

            if (placementIndicator != null)
            {
                placementIndicator.SetActive(true);
                placementIndicator.transform.position = hitPose.position;
                placementIndicator.transform.rotation = hitPose.rotation;
                spawn_button.SetActive(true);
            }
                
            if(scan_txt != null)
                scan_txt.SetActive(false);
        }
        else
        {
            if (placementIndicator != null)
            {
                placementIndicator.SetActive(false);
                spawn_button.SetActive(false);
            }
                
            if (scan_txt != null)
                scan_txt.SetActive(true);
        }
    }

    //This is called by a button
    public void SpawnScene()
    {
        //Add a reference point where user hits spawn 
        //position and rotation according to pose of the phone
        referencePoint = m_ARReferencePointManager.AddReferencePoint(hitPose);
        s_ReferencePoints.Add(referencePoint);

        //Destroy indicator, scan text, button
        Destroy(placementIndicator);
        Destroy(scan_txt);
        Destroy(spawn_button);

        //Instantiate object based on the position and rotation of the point we created before
        m_ARSessionOrigin.MakeContentAppearAt(placedPrefab.transform, referencePoint.transform.position, referencePoint.transform.rotation);

        //Activate the buttons
        done_button.SetActive(true);
        settings_button.SetActive(true);
        
    }
    
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    static List<ARReferencePoint> s_ReferencePoints = new List<ARReferencePoint>();

}
