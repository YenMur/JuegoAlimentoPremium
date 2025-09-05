using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nombreText;
    [SerializeField] private TextMeshProUGUI puntajeText;
    [SerializeField] private TextMeshProUGUI datosText;
    [SerializeField] private TextMeshProUGUI correoText;

    [SerializeField] private TextMeshProUGUI ganador;

    [SerializeField] private Image iconoPosicion;
    public void Datos(DatosJugador jugador, int posicion, Sprite oro, Sprite plata, Sprite bronce)
    {
        nombreText.text = jugador.nombre;
        puntajeText.text = $"{jugador.puntuacion:D3} pts";
        datosText.text=$"{jugador.ciudad} - {jugador.edad} años";
        correoText.text = jugador.correo;

        if(posicion == 1)
        {
            iconoPosicion.enabled = true;
            Debug.Log("Asignando icono de oro");
            iconoPosicion.sprite = oro;
            ganador.enabled = true;
        }
        else if(posicion == 2)
        {
            iconoPosicion.enabled = true;
            Debug.Log("Asignando icono de plata");
            iconoPosicion.sprite = plata;
            ganador.enabled = false;
        }
        else if(posicion == 3)
        {
            iconoPosicion.enabled = true;
            Debug.Log("Asignando icono de bronce");
            iconoPosicion.sprite = bronce;
            ganador.enabled = false;
        }
        else
        {
            iconoPosicion.enabled = false;
            Debug.Log("No hay icono para esta posicion");
            ganador.enabled = false;
        }

    }
}
