using UnityEngine;
using UnityEngine.SceneManagement;  // To restart the level

public class LaserCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the laser hits Sam or Cat
        if (other.CompareTag("Sam") || other.CompareTag("Cat"))
        {
            Debug.Log("Laser touched by: " + other.name);
            ReloadLevel();  // Restart the level
        }
    }

    void ReloadLevel()
    {
        // Reload the current scene when the laser hits Sam or Cat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

