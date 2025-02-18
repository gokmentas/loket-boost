using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
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
                Debug.Log("You finished the level");
                LoadNextLevel();
                break;
            default:
                Debug.Log("You hit something");
                ReloadLevel();
                break;
        }
    }

    // LoadNextLevel is a method that loads the next scene
    private static void LoadNextLevel()
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
    private static void ReloadLevel()
    {
        // Get the current scene index
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        // Reload the current scene
        SceneManager.LoadScene(currentScene);
    }
}
