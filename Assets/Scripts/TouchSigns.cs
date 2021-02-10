using UnityEngine;

public class TouchSigns : MonoBehaviour
{
    public GameObject info0;
    public GameObject info1;
    public GameObject info2;

    void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                // Create a particle if hit
                if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.name == "Sign0")
                {
                    info0.SetActive(true);
                }
                else if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.name == "Sign1")
                {
                    info1.SetActive(true);
                }
                else if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.name == "Sign2")
                {
                    info2.SetActive(true);
                }

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.name == "Sign0")
            {
                info0.SetActive(true);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.name == "Sign1")
            {
                info1.SetActive(true);
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform.name == "Sign2")
            {
                info2.SetActive(true);
            }
        }

    }
 
}
