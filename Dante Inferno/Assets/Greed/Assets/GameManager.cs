using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int coinsCollected = 0;
    public int totalCoins = 6;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    void Awake()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectCoin()
    {
        coinsCollected++;
        UpdateCoinInfo();
        StartCoroutine(hideCoin());
        if (coinsCollected >= totalCoins)
        {
            LoadNextLevel();
        }
    }

    public void UpdateCoinInfo()
    {
        text1.text = "Coins Collected " + coinsCollected;
        text2.text = (totalCoins - coinsCollected) + " Coins Remaining";
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(true);
    }

    private IEnumerator hideCoin()
    {
        yield return new WaitForSeconds(2);
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        
    }
    

    private void LoadNextLevel()
    {
        // Assuming your scenes are in a consecutive order
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}