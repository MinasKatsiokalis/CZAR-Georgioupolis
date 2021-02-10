using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject objectToPlace;
    public TMP_Text messageText;

    private ARSessionOrigin arOrigin;
    private ARRaycastManager arRayManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    private bool objectPlaced;


    // Start is called before the first frame update
    void Start()
    {
        objectPlaced = false;
    }

    void Awake()
    {
        arRayManager = GetComponent<ARRaycastManager>();
        arOrigin = GetComponent<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementIndicator();
        UpdatePlacementPose();

        if(placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !objectPlaced)
        {
            PlaceObject();
        }
    }

    //Place object in real world
    private void PlaceObject()
    {
        objectToPlace.transform.position = placementPose.position;
        arOrigin.MakeContentAppearAt(objectToPlace.transform, placementPose.position, placementPose.rotation);
        objectPlaced = true;
    }

    // Set visible the indicator when a plane is tracked
    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid && !objectPlaced)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position,placementPose.rotation);
            messageText.enabled = false;
        }
        else
        {
            placementIndicator.SetActive(false);
            messageText.enabled = true;
        }

    }

    // Raycast to tracked planes, and update the indicator position and rotation according to camera
    private void UpdatePlacementPose()
    {   
        // Raycast from the center of the screen to detect planes
        var screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        var hits = new List<ARRaycastHit>();
        arRayManager.Raycast(screenCenter, hits, TrackableType.Planes);

        // True if we tracked 1 or more planes
        placementPoseIsValid = (hits.Count > 0);

        // Get position and direction
        if (placementPoseIsValid)
        {
            var cameraForward = Camera.main.transform.forward;
            Vector3 cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose = hits[0].pose;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
        else
        {
            messageText.text = "No Planar Faces Detected...";
        }
    }

}
