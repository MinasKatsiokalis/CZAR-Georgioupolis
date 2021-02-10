using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    //Transform that is followed by Camera
    [SerializeField]
    private Transform player;            

    // Use this for initialization
    void Start()
    {
        transform.position = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }

}
