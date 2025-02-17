// Purpose: To move the player object in the up direction and rotate it to the left or right using the thrust and rotation actions.
// Usage: Attach this script to the player object and assign the thrust and rotation bindings in the inspector.
// To use the thrust action, press the assigned key. To use the rotation action, press the assigned keys to rotate the player object to the left or right.
// The player object will move in the up direction and rotate to the left or right based on the input provided by the thrust and rotation actions.
// The strength of the thrust and rotation can be adjusted in the inspector.

// Import the necessary namespaces
using UnityEngine;
using UnityEngine.InputSystem;

// Create a Movement class
public class Movement : MonoBehaviour
{
    // Store the thrust and rotation actions
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;

    // The strength of the thrust and rotation
    [SerializeField] float thrustStrength = 1000f;
    [SerializeField] float rotationStrength = 100f;

    // Store the Rigidbody and Audio Source components of the player object
    Rigidbody rb;
    AudioSource audioSource;

    // Doing this on start because we need to get the Rigidbody component
    private void Start()
    {
        // Get the Rigidbody and Audio Source components of the player object
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Doing this on enable imstead of start because we need to enable the actions
    private void OnEnable()
    {
        // Enable the thrust and rotation actions
        thrust.Enable();
        rotation.Enable();
    }

    // Calling movement methods in FixedUpdate instead of Update because we are using physics
    private void FixedUpdate()
    {
        // Calling the movement methods
        ProcessThrust();
        ProcessRotation();
    }

    // ProcessThrust is a method that applies a force to the player object in the up direction
    private void ProcessThrust()
    {
        // Check if the thrust action is pressed
        if (thrust.IsPressed())
        {
            // Apply a force to the player object in the up direction
            rb.AddRelativeForce(thrustStrength * Time.fixedDeltaTime * Vector3.up);
            // play the audio if it is not playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        // If the thrust action is not pressed, stop the audio
        else
        {
            audioSource.Stop();
        }
    }

    // ProcessRotation is a method that rotates the player object
    private void ProcessRotation()
    {
        // Get the value of the rotation action
        float rotationValue = rotation.ReadValue<float>();

        // Check if the rotation value is less than 0 or greater than 0 and apply rotation accordingly
        if (rotationValue < 0)
        {
            // Rotate the player object to the left
            ApplyRotation(rotationStrength);
        }
        else if (rotationValue > 0)
        {
            // Rotate the player object to the right
            ApplyRotation(-rotationStrength);
        }
    }

    // ApplyRotation is a method that rotates the player object
    private void ApplyRotation(float rotationThisFrame)
    {
        // Freeze the rotation of the player object because we are manually rotating it
        rb.freezeRotation = true;
        // Rotate the player object
        transform.Rotate(rotationThisFrame * Time.fixedDeltaTime * Vector3.forward);
        // Unfreeze the rotation of the player object because we are done rotating it
        rb.freezeRotation = false;
    }
}
