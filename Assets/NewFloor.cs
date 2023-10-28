using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewFloor : MonoBehaviour
{
    GameObject firstFloor;
    GameObject secondFloor;

    [Header("Fade Effect")]
    public Image fadeOverlay;
    public float timeToFade = 1.00f;
    public Color transparent;
    public Color black;

    private void Awake()
    {
        firstFloor = transform.GetChild(0).gameObject;
        secondFloor = transform.GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(nameof(FadeImage));
    }

    private IEnumerator FadeImage()
    {
        float elapsedTime = 0f;

        while (elapsedTime < timeToFade)
        {
            float t = elapsedTime / timeToFade;
            fadeOverlay.color = Color.Lerp(transparent, black, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color is exactly the endColor
        fadeOverlay.color = Color.black;

        firstFloor.SetActive(false);
        secondFloor.SetActive(true);

        transform.GetComponent<Collider>().enabled = false;

        // Wait for a moment (e.g., 1 second) before fading back
        yield return new WaitForSeconds(1f);

        // Reset the timer
        elapsedTime = 0f;

        while (elapsedTime < timeToFade)
        {
            float t = elapsedTime / timeToFade;
            fadeOverlay.color = Color.Lerp(black, transparent, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final color is exactly the startColor
        fadeOverlay.color = transparent;
    }
}
