using UnityEngine;

public class MoveContent : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The content to move.")]
    GameObject content;

    public void MoveUp()
    {
        content.transform.position = new Vector3(content.transform.position.x, content.transform.position.y + 0.1f, content.transform.position.z); 
    }

    public void MoveDown()
    {
        content.transform.position = new Vector3(content.transform.position.x, content.transform.position.y - 0.1f, content.transform.position.z);
    }

    public void MoveLeft()
    {
        content.transform.position = new Vector3(content.transform.position.x - 0.3f, content.transform.position.y , content.transform.position.z);
    }

    public void MoveRight()
    {
        content.transform.position = new Vector3(content.transform.position.x + 0.3f, content.transform.position.y, content.transform.position.z);
    }
}
