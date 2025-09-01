using System.IO;
using TMPro;
using UnityEngine;

public class GuardarDatosJugador : MonoBehaviour
{

    string rutaArchivo;

    [SerializeField] private GameObject panelCargarDatos;
    [SerializeField] private Transform contenidoTexto;
    [SerializeField] private TextMeshProUGUI textoContenido;

    Historial historialPartidas=new Historial();

    private void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/datosUsuariosPet.json";

        if(File.Exists(rutaArchivo))
        {
            string datosJson = File.ReadAllText(rutaArchivo);
            historialPartidas = JsonUtility.FromJson<Historial>(datosJson);
        }
        
    }
    
    public void GuardarDatos()
    {
        DatosJugador datos=new DatosJugador();
        Debug.Log("Guardando datos del jugador...");

        datos.nombre=GameManager.Instance.nombreJugador;
        datos.edad=GameManager.Instance.edadJugador;
        datos.ciudad=GameManager.Instance.ciudadJugador;
        datos.correo=GameManager.Instance.correoJugador;
        datos.puntuacion=GameManager.Instance.puntos;

        datos.fecha=System.DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        historialPartidas.partidas.Add(datos);
        string datosJson = JsonUtility.ToJson(historialPartidas, true);
        File.WriteAllText(rutaArchivo, datosJson);

        Debug.Log("Datos del jugador guardados en: " + rutaArchivo);
    }

    public void CargarDatos()
    {
       
    }
}
