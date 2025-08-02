using UnityEngine;

public class DoctorMovement1 : MonoBehaviour
{
    public float moveSpeed = 2f;        // Speed at which the doctor moves
    public float moveDistance = 2f;     // How far the doctor moves to the left and right
    private Vector3 startingPosition;   // Starting position of the doctor

    void Start()
    {
        // Store the initial position of the doctor
        startingPosition = transform.position;
    }

    void Update()
    {
        // Oscillate the doctor left and right
        float newX = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(startingPosition.x + newX, transform.position.y, transform.position.z);
    }
}
