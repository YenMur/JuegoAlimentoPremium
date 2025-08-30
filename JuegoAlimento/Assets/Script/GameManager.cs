using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public DatosJugador datosJugador=new DatosJugador();

    public int puntos = 0;

    public bool juegoTerminado = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void sumPuntos(int value)
    {
        puntos += value;
    }

    public int Puntos { get => puntos; set => puntos = value; }
}
