using System.Collections;
using TMPro;
using Unity.AppUI.UI;
using UnityEngine;

public class GameController5 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP_Puntos;

    [SerializeField] private TextMeshProUGUI TMP_Tiempo;

    [SerializeField] private GameObject PanelPerdio;

    [SerializeField] private AudioSource musicaSource;

    [SerializeField] private AudioClip musicaSad;

    private float cuentaRegresiva = 40f; // Tiempo inicial en segundos
    private float currentTime;
    private bool cuentaRegresivaActiva = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime= cuentaRegresiva;
        PanelPerdio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.juegoIniciado&&cuentaRegresivaActiva)
        {
            currentTime -= Time.deltaTime;

            if(currentTime > 0)
            {
                UpdateCountdownUI(currentTime);
            }
            else
            {
                cuentaRegresivaActiva=false;
                currentTime=0;
                UpdateCountdownUI(currentTime);
            }
        }
        ActualizarPuntos();
    }

    void UpdateCountdownUI(float time)
    {
        int minutes=Mathf.FloorToInt(time / 60);
        int seconds=Mathf.FloorToInt(time % 60);
        TMP_Tiempo.text=string.Format("{0:00}:{1:00}", minutes,seconds);
    }

    public void ActualizarPuntos()
    {
        TMP_Puntos.text=GameManager.Instance.puntos.ToString("D3");
    }

    public void Perder()
    {
        cuentaRegresivaActiva=false;
        PanelPerdio.SetActive(true);
        GameManager.Instance.juegoTerminado=true;

        StartCoroutine(CargarScore());

        musicaSource.Stop();

        musicaSource.clip=musicaSad;
        musicaSource.loop=false;
        musicaSource.Play();
    }

    public void IniciarCuentaRegresiva()
    {
        cuentaRegresivaActiva=true;
    }

    private IEnumerator CargarScore()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Resultado");
    }

}
