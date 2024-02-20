using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneOnCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger. Loading next scene...");
            LoadNextScene();
        }
        else
        {
            Debug.Log("Non-player object entered trigger.");
        }
    }

    void LoadNextScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current Scene Index: " + currentSceneIndex);

        // Calculate the index for the next scene
        int nextSceneIndex = currentSceneIndex + 1;
        Debug.Log("Loading Scene Index: " + nextSceneIndex);

        // Load the next scene (make sure to have your scenes added in the build settings)
        SceneManager.LoadScene(nextSceneIndex);
    }
}
