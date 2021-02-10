using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class TransferToMap : MonoBehaviour
{
    [SerializeField]
    private Text locText;

    [SerializeField]
    private Text disText;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        //First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        yield break;

        //Start service before querying location
        Input.location.Start(0.5f, 0.1f);

        
        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Access granted!");
        }
    }

    // Update is called once per frame
    void Update()
    {   
        //Get Location info
        if(Input.location.status == LocationServiceStatus.Running)
        {
            locText.text = (Input.location.lastData.latitude + " , " + Input.location.lastData.longitude);
            disText.text = string.Format("{0:0.00}", DistanceAwayFromPOI());

           /* if (DistanceAwayFromPOI() > 15)
            {
                SceneManager.LoadScene("AstronautGame");
            }*/
        }
        else
        {
            locText.text = "No Provider";
            disText.text = "";
        }
    }

    //Calculate the walked distance
    private float DistanceAwayFromPOI()
    {   
        return GeoDistance.Calculate_Distance(Input.location.lastData.latitude, Input.location.lastData.longitude, GeoDistance.PoiLat, GeoDistance.PoiLon);
    }
}
