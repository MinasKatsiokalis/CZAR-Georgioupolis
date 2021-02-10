using UnityEngine;

public class IndicatorSelector : MonoBehaviour
{
    public GameObject humanoid;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        if(WelcomeSceneManager.indicator_option == 1){
            arrow.SetActive(false);
        }
        else
        {
            humanoid.SetActive(false);
        }
    }

}
