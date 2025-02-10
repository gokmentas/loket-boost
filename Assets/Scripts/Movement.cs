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

    // onenable is called when the script is enabled
    private void OnEnable()
    {
        // Enable the thrust action
        thrust.Enable();
    }

    // update is called once per frame
    private void Update()
    {
        // Check if the thrust action is pressed
        if (thrust.IsPressed())
        {
            // Log a message to the console
            Debug.Log("Thrusting");
        }
    }
}
