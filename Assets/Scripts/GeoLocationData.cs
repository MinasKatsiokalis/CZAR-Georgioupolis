using Mapbox.Utils;

[System.Serializable]
public class GeoLocationData
{
    public string Name;
    public double Latitude;
    public double Longitude;

    public Vector2d GeoLocation()
    {
        var geoLoc = new Vector2d(this.Latitude, this.Longitude);
        return geoLoc;
    }
}

