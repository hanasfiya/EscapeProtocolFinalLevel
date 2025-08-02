using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sam") && CompareTag("Sam"))
        {
            GameManager.Instance.SetPlayerAtDoor("Sam", true);
        }
        else if (other.CompareTag("Cat") && CompareTag("Cat"))
        {
            GameManager.Instance.SetPlayerAtDoor("Cat", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Sam") && CompareTag("Sam"))
        {
            GameManager.Instance.SetPlayerAtDoor("Sam", false);
        }
        else if (other.CompareTag("Cat") && CompareTag("Cat"))
        {
            GameManager.Instance.SetPlayerAtDoor("Cat", false);
        }
    }
}

