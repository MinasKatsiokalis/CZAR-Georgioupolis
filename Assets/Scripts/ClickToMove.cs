using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class ClickToMove : MonoBehaviour
{
    public GameObject placedPrefab;
    public GameObject placementIndicator;
    public ARSessionOrigin arSessionOrigin;
    public GameObject button;

    public void SpawnScene()
    {
        Destroy(placementIndicator);
        arSessionOrigin.MakeContentAppearAt(placedPrefab.transform, placementIndicator.transform.position, placementIndicator.transform.rotation);
        button.SetActive(false);
    }
}
