using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;


    public Historial historialPartidas=new Historial();

    public int puntos = 0;

    public bool juegoTerminado = false;

    public bool juegoIniciado = false;

    public bool partidaGanada= false;

    public GameController1 gc1;

    #region Jugador
    public string nombreJugador;
    public string edadJugador;
    public string ciudadJugador;
    public string correoJugador;
    #endregion

    private string rutaArchivo;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            rutaArchivo=Application.persistentDataPath + "/datosUsuariosPet.json";

            if(File.Exists(rutaArchivo))
            {
                string datosJson = File.ReadAllText(rutaArchivo);
                historialPartidas = JsonUtility.FromJson<Historial>(datosJson);

                if (historialPartidas == null)
                    historialPartidas = new Historial();
            }
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.Log("GameManager vivo en escena: " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }

    public void sumPuntos(int value)
    {
        puntos += value;
    }

    public int Puntos { get => puntos; set => puntos = value; }

    public void GuardarDatosJugador()
    {
        if (historialPartidas.partidas.Exists(p => p.correo == correoJugador))
        {
            Debug.LogWarning("El correo ya esta registrado en historial");
            return;
        }
        DatosJugador datosJugador = new DatosJugador();

        Debug.Log("Guardando datos del jugador...");

        datosJugador.nombre = nombreJugador;
        datosJugador.edad = edadJugador;
        datosJugador.ciudad = ciudadJugador;
        datosJugador.correo = correoJugador;
        datosJugador.puntuacion = puntos;
        datosJugador.fecha = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        historialPartidas.partidas.Add(datosJugador);

        string datosJson = JsonUtility.ToJson(historialPartidas, true);
        File.WriteAllText(rutaArchivo, datosJson);
        Debug.Log("Datos guardados: " + datosJson);
    }
}
