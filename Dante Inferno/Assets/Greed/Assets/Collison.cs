using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Collison : MonoBehaviour
{
    public Image redScreenOverlay;
    private int collisionCount = 0;
    private int collisionsNeeded = 2;

    void Start()
    {
        // Ensure the red screen overlay is transparent at the start
        redScreenOverlay.color = new Color(redScreenOverlay.color.r, redScreenOverlay.color.g, redScreenOverlay.color.b, 0f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionCount++;
            StartCoroutine(BlinkScreen());

            if (collisionCount >= collisionsNeeded)
            {
                // Reset the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private IEnumerator BlinkScreen()
    {
        redScreenOverlay.color = new Color(redScreenOverlay.color.r, redScreenOverlay.color.g, redScreenOverlay.color.b, 1f);
        yield return new WaitForSeconds(0.5f);
        redScreenOverlay.color = new Color(redScreenOverlay.color.r, redScreenOverlay.color.g, redScreenOverlay.color.b, 0f);
    }
}