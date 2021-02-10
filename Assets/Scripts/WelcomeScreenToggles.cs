using UnityEngine;
using UnityEngine.UI;

public class WelcomeScreenToggles : MonoBehaviour
{
    public GameObject humanoid_toggle;
    public GameObject arrow_toggle;
    public bool humanoid_checked;
    public bool arrow_checked;
    public bool dark_theme_checked;

    void Start()
    {
        humanoid_toggle.GetComponent<Toggle>().isOn = true;
        arrow_toggle.GetComponent<Toggle>().isOn = false;
        humanoid_checked = true;
        arrow_checked = false;
        WelcomeSceneManager.indicator_option = 1;

        dark_theme_checked = false;
    }

    void Update()
    {
        if (!humanoid_checked && !arrow_checked)
        {
            humanoid_toggle.GetComponent<Toggle>().isOn = true;
            arrow_toggle.GetComponent<Toggle>().isOn = false;
            humanoid_checked = true;
            arrow_checked = false;
            WelcomeSceneManager.indicator_option = 1;
        }        
    }

    public void HumanoidToggleChange()
    {
        humanoid_checked = !humanoid_checked;
        if (humanoid_checked)
        {
            humanoid_toggle.GetComponent<Toggle>().isOn = true;
            arrow_toggle.GetComponent<Toggle>().isOn = false;
            WelcomeSceneManager.indicator_option = 1;
        }
    }

    public void ArrowToggleChange()
    {
        arrow_checked = !arrow_checked;
        if (arrow_checked)
        {
            humanoid_toggle.GetComponent<Toggle>().isOn = false;
            arrow_toggle.GetComponent<Toggle>().isOn = true;
            WelcomeSceneManager.indicator_option = 2;
        }      
    }

    public void DarkThemeToggle()
    {
        dark_theme_checked = !dark_theme_checked;
        WelcomeSceneManager.dark_theme = dark_theme_checked;
    }
}
