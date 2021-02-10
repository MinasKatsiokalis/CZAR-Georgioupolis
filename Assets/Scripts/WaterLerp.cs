using UnityEngine;

public class WaterLerp : MonoBehaviour
{   ///This script is used for the Water elevation
    ///In order to represent it in more delecant way, Lerp is used

    //The position where we want the water to move
    public Transform midPos, endPos;
    //The speed of the movement
    public float speed;
    //Signs for info
    public GameObject sign_warning, sign_danger;

    //Parameters for Lerp 
    private float startTime, midDistance, totalDistance;
    private Vector3 startPos;
    private bool firstElevation = false;
    private bool secondElevation = false;

    // Update is called once per frame
    void Update()
    {   
        //The fisrt Lerp
        if (firstElevation == true)
        {
            float currentDuration = (Time.time - startTime) * speed;
            float journeyFraction = currentDuration / midDistance;
            this.transform.position = Vector3.Lerp(startPos, midPos.position, journeyFraction);
        }
        //The second Lerp
        else if (secondElevation == true)
        {
            float currentDuration = (Time.time - startTime) * speed;
            float journeyFraction = currentDuration / totalDistance;
            this.transform.position = Vector3.Lerp(midPos.position, endPos.position, journeyFraction);
        }
    }

    //Get the position, time and distance for the first Water Lerp
    public void FirstElevation()
    {
        startPos = this.transform.position;
        startTime = Time.time;
        midDistance = Vector3.Distance(startPos, midPos.position);       
        firstElevation = true;
        sign_warning.SetActive(true);
    }

    //Get the position, time and distance for the second Water Lerp
    public void SecondElevation()
    {
        startPos = this.transform.position;
        startTime = Time.time;
        totalDistance = Vector3.Distance(midPos.position, endPos.position);
        firstElevation = false;
        secondElevation = true;
        sign_danger.SetActive(true);
    }
}
