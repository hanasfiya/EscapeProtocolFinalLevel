using UnityEngine;
using UnityEngine.SceneManagement;  // To restart the level

public class PlayerHealth : MonoBehaviour
{
    private bool isDead = false;

    // Method to be called when the player dies
    public void Die()
    {
        if (isDead)
            return;  // Prevent multiple calls

        isDead = true;

        // Stop all movement by disabling the movement scripts
        if (CompareTag("Sam"))
        {
            GetComponent<SamMovement>().enabled = false;  // Disable Sam's movement
        }
        else if (CompareTag("Cat"))
        {
            GetComponent<CatMovement>().enabled = false;  // Disable Cat's movement
        }

        // Restart the level immediately
        RestartLevel();
    }

    // Restart the current level
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }
}