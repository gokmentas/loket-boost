using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check the tag of the object that the player collided with
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                // If the player collided with the finish line, start the finish sequence
                StartFiinishSequence();
                break;
            default:
                // If the player collided with an object that is not friendly or the finish line, start the crash sequence
                StartCrashSequence();
                break;
        }
    }

    // StartFiinishSequence is a method that starts the finish sequence
    void StartFiinishSequence()
    {
        // todo: Add sfx and particles

        // Disable the player's movement script
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    // StartCrashSequence is a method that starts the crash sequence
    void StartCrashSequence()
    {
        // todo: Add sfx and particles
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    // LoadNextLevel is a method that loads the next scene
    void LoadNextLevel()
    {
        // Get the current scene index
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        // Load the next scene if the current scene is less than 2 because we have 3 scenes
        if (currentScene < SceneManager.sceneCountInBuildSettings - 1)
        {
            // Load the next scene by adding 1 to the current scene index
            SceneManager.LoadScene(currentScene + 1);
        }
        else
        {
            // Load the first scene if the current scene is the last scene
            SceneManager.LoadScene(0);
        }
    }

    // ReloadLevel is a method that reloads the current scene
    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
