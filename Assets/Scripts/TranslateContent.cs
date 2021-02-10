using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class TranslateContent : MonoBehaviour
{
    private Vector3 position;
    private ARSessionOrigin m_ARSessionOrigin;

    [SerializeField]
    [Tooltip("The content to translate.")]
    GameObject content;

    [SerializeField]
    [Tooltip("The slider used to control translation.")]
    Slider m_Slider;

    /// <summary>
    /// The slider used to control scale.
    /// </summary>
    public Slider slider
    {
        get { return m_Slider; }
        set { m_Slider = value; }
    }

    [SerializeField]
    [Tooltip("The text used to display the current translation on the screen.")]
    Text m_Text;

    /// <summary>
    /// The text used to display the current rotation on the screen.
    /// </summary>
    public Text text
    {
        get { return m_Text; }
        set { m_Text = value; }
    }


    /// <summary>
    /// Invoked when the slider's value changes
    /// </summary>
    public void OnSliderValueChanged()
    {
        if (slider != null)
        {
            if (slider.value >= 0)
            {
                content.transform.position = new Vector3(content.transform.position.x + Mathf.Abs(slider.value), content.transform.position.y, content.transform.position.z);
            }

            else
            {
                content.transform.position = new Vector3(content.transform.position.x - Mathf.Abs(slider.value), content.transform.position.y, content.transform.position.z);
            }
            UpdateText();
        }
    }

    void Awake()
    {
        m_ARSessionOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    void OnEnable()
    {
        UpdateText();
    }

    void UpdateText()
    {
        if (m_Text != null)
            m_Text.text = "Translation: " + slider.value + " meters";
    }

}
