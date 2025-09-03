using System.Collections;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private GameObject panel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        panel.SetActive(false);

        GameManager.Instance.juegoIniciado = true;
        FindFirstObjectByType<GameController5>().IniciarCuentaRegresiva();
    }
}
