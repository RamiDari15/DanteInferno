using UnityEngine;
using UnityEngine.UI; // If using standard UI Text
using TMPro; // If using TextMeshPro
using System.Collections;

public class ObjectiveDisplay : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;

    void Start()
    {
        objectiveText.alpha = 0;

        StartCoroutine(ShowObjectiveRoutine());
    }

    private IEnumerator ShowObjectiveRoutine()
    {
        while (objectiveText.alpha < 1)
        {
            objectiveText.alpha += Time.deltaTime / 2; 
            yield return null;
        }

        yield return new WaitForSeconds(2);

        // Fade out the objective text
        while (objectiveText.alpha > 0)
        {
            objectiveText.alpha -= Time.deltaTime / 2; 
            yield return null;
        }
    }
}