using TMPro;
using UnityEngine;

public class ScoreMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nombreText;
    [SerializeField] private TextMeshProUGUI puntajeText;
    [SerializeField] private TextMeshProUGUI datosText;
    [SerializeField] private TextMeshProUGUI correoText;


    public void Datos(DatosJugador jugador)
    {
        nombreText.text = jugador.nombre;
        puntajeText.text = $"{jugador.puntuacion:D3} pts";
        datosText.text=$"{jugador.ciudad} - {jugador.edad} años";
        correoText.text = jugador.correo;

    }
}
