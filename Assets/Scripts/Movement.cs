// Purpose: Detect when the player is thrusting using the new Input System.
// Usage: Attach this script to the player object and assign the thrust action in the inspector.
// To test this script, create a new Input Action in the Input Actions asset and assign the "Thrust" binding to a key on the keyboard.
// Press the assigned key to see the "Thrusting" message in the console.

// Import the UnityEngine namespace
using UnityEngine;
// Import the InputSystem namespace
using UnityEngine.InputSystem;

// Create a Movement class
public class Movement : MonoBehaviour
{
    // The InputAction object that will be used to detect thrusting
    [SerializeField] InputAction thrust;
    // The strength of the thrust
    [SerializeField] float thrustStrength = 1000f;
    // Store the Rigidbody component of the player object
    Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the Rigidbody component of the player object
        rb = GetComponent<Rigidbody>();
    }

    // onenable is called when the script is enabled
    private void OnEnable()
    {
        // Enable the thrust action
        thrust.Enable();
    }

    // fixedupdate is different from update as it is called at a fixed interval
    private void FixedUpdate()
    {
        // Check if the thrust action is pressed
        if (thrust.IsPressed())
        {
            // Apply a force to the player object in the up direction
            rb.AddRelativeForce(thrustStrength * Time.fixedDeltaTime * Vector3.up);
        }
    }
}
