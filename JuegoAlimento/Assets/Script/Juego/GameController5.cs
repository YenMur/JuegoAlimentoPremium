using TMPro;
using UnityEngine;

public class GameController5 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP_Puntos;

    [SerializeField] private TextMeshProUGUI TMP_Tiempo;

    private float cuentaRegresiva = 40f; // Tiempo inicial en segundos
    private float currentTime;
    private bool cuentaRegresivaActiva = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime= cuentaRegresiva;

    }

    // Update is called once per frame
    void Update()
    {

        if (cuentaRegresivaActiva)
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
        int seconds=Mathf.FloorToInt(time % 60);
        TMP_Tiempo.text=string.Format("{00:00}", seconds);
    }

    public void ActualizarPuntos()
    {
        TMP_Puntos.text=GameManager.Instance.puntos.ToString();
    }

}
