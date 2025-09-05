using System.Collections;
using TMPro;
using Unity.AppUI.UI;
using UnityEngine;

public class GameController5 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP_Puntos;
    [SerializeField] private TextMeshProUGUI TMP_Tiempo;
    [SerializeField] private GameObject PanelPerdio;
    [SerializeField] private GameObject PanelInicio;

    [Header("Audio")]
    [SerializeField] private AudioSource musicaSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip musicaSad;
    [SerializeField] private AudioClip musicaWin;
    [SerializeField] private AudioClip sfxComidaMala;

    private float cuentaRegresiva = 40f;
    private float currentTime;
    private bool cuentaRegresivaActiva = true;

    void Start()
    {
        currentTime = cuentaRegresiva;
        PanelPerdio.SetActive(false);
        PanelInicio.SetActive(false);

        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.playOnAwake = false;
        }
    }

    void Update()
    {
        if (GameManager.Instance.juegoIniciado && cuentaRegresivaActiva)
        {
            currentTime -= Time.deltaTime;
            if (currentTime > 0)
            {
                UpdateCountdownUI(currentTime);
            }
            else
            {
                cuentaRegresivaActiva = false;
                currentTime = 0;
                UpdateCountdownUI(currentTime);
                Ganar();
            }
        }
        ActualizarPuntos();
    }

    void UpdateCountdownUI(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        TMP_Tiempo.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ActualizarPuntos()
    {
        TMP_Puntos.text = GameManager.Instance.puntos.ToString("D3");
    }

    public void ReproducirSonidoComidaMala()
    {
        if (sfxComidaMala != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(sfxComidaMala);
        }
    }

    public void Perder()
    {
        cuentaRegresivaActiva = false;
        PanelPerdio.SetActive(true);
        GameManager.Instance.juegoTerminado = true;
        GameManager.Instance.partidaGanada = false;
        StartCoroutine(CargarScore());

        if (musicaSource != null && musicaSad != null)
        {
            musicaSource.Stop();
            musicaSource.clip = musicaSad;
            musicaSource.loop = false;
            musicaSource.Play();
        }

        GameManager.Instance.GuardarDatosJugador();
    }

    public void Ganar()
    {
        cuentaRegresivaActiva = false;
        PanelInicio.SetActive(true);
        GameManager.Instance.juegoTerminado = true;
        GameManager.Instance.partidaGanada = true;
        Debug.Log("Voy a Resultado con partidaGanada=" + GameManager.Instance.partidaGanada);
        StartCoroutine(CargarScore());

        if (musicaSource != null && musicaWin != null)
        {
            musicaSource.Stop();
            musicaSource.clip = musicaWin;
            musicaSource.loop = false;
            musicaSource.Play();
        }

        GameManager.Instance.GuardarDatosJugador();
    }

    public void IniciarCuentaRegresiva()
    {
        cuentaRegresivaActiva = true;
    }

    private IEnumerator CargarScore()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Resultado");
    }
}