using UnityEngine;

public class WaterElevation : MonoBehaviour
{
    public Transform water;

    public void IncreaseWaterHeight()
    {
        water.Translate(new Vector3(0, +0.005f, 0), Space.Self);
    }

    public void DecreaseWaterHeight()
    {
        water.Translate(new Vector3(0, -0.005f, 0), Space.Self);
    }
}
