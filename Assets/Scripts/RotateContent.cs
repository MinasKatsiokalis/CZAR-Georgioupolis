using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class RotateContent : MonoBehaviour
{   
    private Quaternion rotation;
    private ARSessionOrigin m_ARSessionOrigin;

    [SerializeField]
    [Tooltip("The content for Rotation.")]
    GameObject content;

    void Awake()
    {
        m_ARSessionOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    public void RotateLeft()
    {
        rotation = Quaternion.AngleAxis(rotation.eulerAngles.y + 5.0f,Vector3.up);
        m_ARSessionOrigin.MakeContentAppearAt(content.transform, content.transform.position, rotation);
    }

    public void RotateRight()
    {
        rotation = Quaternion.AngleAxis(rotation.eulerAngles.y - 5.0f, Vector3.up);
        m_ARSessionOrigin.MakeContentAppearAt(content.transform, content.transform.position, rotation);
    }

}
