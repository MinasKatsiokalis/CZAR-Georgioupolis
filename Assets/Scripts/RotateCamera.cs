using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //The rotation factor of the Camera
    [SerializeField]
    private float rotationSpeed;

    private bool drag;
    private Vector3 start_position, end_position;

    // Start is called before the first frame update
    void Start()
    {
        drag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 0 for left and 1 for right click
        if (Input.GetMouseButton(0) && !drag)
        {   
            //Draging started, get the mouse/touch position
            drag = true;
            start_position = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0) && drag)
        {
            //Get the next position, calculate distance of draging
            end_position = Input.mousePosition;
            var curPosition = end_position.x - start_position.x;
            //Rotate camera based on draging
            var rotX = curPosition * rotationSpeed * Mathf.Deg2Rad *Time.deltaTime;
            transform.Rotate(Vector3.up, -rotX);
        }
        else
        {
            //End of draging
            drag = false;
        }
        
    }
}
