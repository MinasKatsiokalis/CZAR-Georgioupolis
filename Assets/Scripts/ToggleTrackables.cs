using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ToggleTrackables : MonoBehaviour
{
    ARPlaneManager m_ARPlaneManager;
    ARPointCloudManager m_ARPointCloudManager;

    private bool show; 
    // Start is called before the first frame update
    void Awake()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
        m_ARPointCloudManager = GetComponent<ARPointCloudManager>();
        show = true;
    }
    public void HideTrackables()
    {
        show = !show;

        foreach (ARPlane plane in m_ARPlaneManager.trackables)
        {
            plane.gameObject.SetActive(show);
        }

        foreach (ARPointCloud pointCloud in m_ARPointCloudManager.trackables)
        {
            pointCloud.gameObject.SetActive(show);
        }
    }
}
