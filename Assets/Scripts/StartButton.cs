using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{   
    public void LoadMap()
    {   
        if(WelcomeSceneManager.dark_theme)
            SceneManager.LoadScene("Dark Map Scene");
        else
            SceneManager.LoadScene("Map Scene");
    }  
}
