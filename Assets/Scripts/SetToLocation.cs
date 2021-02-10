using Mapbox.Unity.Utilities;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using UnityEngine;

///Set a waypoint to a geo location
public class SetToLocation : MonoBehaviour
{
    [SerializeField]
    AbstractMap _map;

    [SerializeField]
    private TMPro.TMP_Dropdown dd_list;

    public GeoLocationData[] PointsOfIinterest;

    //If new POI set change the direction's waypoint
    void Update()
    {   
        if(GetPOIgeoLocation(dd_list.value) != this.transform.GetGeoPosition(_map.CenterMercator, _map.WorldRelativeScale))
        {
            MoveWaypointToGeoLocation(this.transform);
        }
    }

    //Changing the dropdown option set new Position/Direction
    public void OptionLocation()
    {
        MoveWaypointToGeoLocation(this.transform);
    }

    //The method that sets the waypoint ot the geo location
    private void MoveWaypointToGeoLocation(Transform waypoint)
    {
        waypoint.MoveToGeocoordinate(PointsOfIinterest[dd_list.value].Latitude, PointsOfIinterest[dd_list.value].Longitude, _map.CenterMercator, _map.WorldRelativeScale);
    }

    private Vector2d GetPOIgeoLocation(int option)
    {
        return PointsOfIinterest[option].GeoLocation();
    }
}