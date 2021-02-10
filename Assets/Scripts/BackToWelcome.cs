using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToWelcome : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Welcome Scene");
        }       
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
