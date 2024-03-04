using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 100f;
    private float currentTime;
    public TextMeshProUGUI countdownText;

    private void Start()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (countdownText != null)
        {
            countdownText.text = currentTime.ToString("F2");
        }

        if (currentTime <= 0f)
        {
            SceneManager.LoadScene("Suc");
        }
    }
}