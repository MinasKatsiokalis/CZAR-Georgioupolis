using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMap : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (WelcomeSceneManager.dark_theme)
                SceneManager.LoadScene("Dark Map Scene");
            else
                SceneManager.LoadScene("Map Scene");
        }
    }
}
