using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mapbox.Unity.Utilities;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using System.Collections;


public class CheckLocation : MonoBehaviour
{
    [SerializeField]
    AbstractMap _map;

    [SerializeField]
    private GameObject point;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Text distanceText;

    [SerializeField]
    private TMPro.TMP_Dropdown dd_list;

    [SerializeField]
    private GameObject AR_Button;

    [SerializeField]
    private GameObject info_canvas;

    [SerializeField]
    private GameObject alert_canvas;



    private Vector2d playerPosition;
    private Vector2d pointPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GetPlayerGeoPosition();
        pointPosition = GetPointGeoPosition();

        StartCoroutine(ExecuteAfterTime(5));

    }

    private IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        //Away from location, pop alert else info
        if (GetDistance() > 2000 && GetDistance() != 0)
        {
            alert_canvas.SetActive(true);
        }
        else
        {
            info_canvas.SetActive(true);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Get player's and point's position every frame
        playerPosition = GetPlayerGeoPosition();
        pointPosition = GetPointGeoPosition();

        //Show the player's distance from POI location
        UpdateDistanceText();

        //Enable AR button when player reaches 10 meters 
        //close to POI location based on the selection of user
        if (GetDistance() <= 10 && GetDistance() != 0)
        {
            AR_Button.gameObject.SetActive(true);
        }
        else
        {
            AR_Button.gameObject.SetActive(false);
        }

    }

    //Get PLayer's Geo Position
    private Vector2d GetPlayerGeoPosition()
    {
        return player.transform.GetGeoPosition(_map.CenterMercator, _map.WorldRelativeScale);
    }

    //Get POI's Geo Position
    private Vector2d GetPointGeoPosition()
    {
        return point.transform.GetGeoPosition(_map.CenterMercator, _map.WorldRelativeScale);
    }

    //Calculate distance between Player and POI position
    private float GetDistance()
    {
        //position[0] => Latitude 
        //position[1] => Longitude
        float distance = GeoDistance.Calculate_Distance((float)playerPosition[0], (float)playerPosition[1], (float)pointPosition[0], (float)pointPosition[1]);
        return distance;     
    }

    //Update the player's distance from POI location
    private void UpdateDistanceText()
    {  
        var dist = string.Format("<color=white> {0:0.00} </color>", GetDistance());
        distanceText.text = "You are " + dist + " meters away from Location: " + (dd_list.value + 1);
    }

    //Load the Scene the User has selected
    public void LoadARScene()
    {
        SceneManager.LoadScene(dd_list.value + 1);
    }
}
