using UnityEngine;

public static class GeoDistance
{
    /// <summary>
    /// This class is used in order to calculate the distance bettwen two geo locations
    /// </summary>

    public static float PoiLat;
    public static float PoiLon;

    private static float DegToRad(float deg)
    {
        return (deg * Mathf.PI) / 180.0f;
    }

    //This is the function to call to calculate the distance between two points

    public static float Calculate_Distance(float lat1, float lon1, float lat2, float lon2)
    {
        var R = 6371; // Radius of the earth in km
        var dLat = DegToRad(lat2 - lat1);  // deg2rad below
        var dLon = DegToRad(lon2 - lon1);
        var a =
          Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
          Mathf.Cos(DegToRad(lat1)) * Mathf.Cos(DegToRad(lat2)) * Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);

        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        var d = R * c; // Distance in km

        //returns in meters
        return d*1000;
    }

}


