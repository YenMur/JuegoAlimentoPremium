using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI ciudad;
    [SerializeField] private TextMeshProUGUI edad;
    [SerializeField] private TextMeshProUGUI score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance != null)
        {
            var datos = GameManager.Instance.datosJugador;

            playerName.text =  datos.nombre;
            ciudad.text =  datos.edad;
            edad.text = datos.ciudad;

            score.text = GameManager.Instance.puntos.ToString("D3");
        }
        else
        {
            Debug.LogWarning("GameManager.Instance es null en la escena Score");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
