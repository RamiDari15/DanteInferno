using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        
        // Get the current scene index
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);

    }
}