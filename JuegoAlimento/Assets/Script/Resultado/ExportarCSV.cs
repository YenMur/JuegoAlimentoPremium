using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using TMPro;

public class ExportarCSV : MonoBehaviour
{

    private string rutaArchivoCSV;
    private string rutaArchivoJSON;
    [SerializeField] private TextMeshProUGUI descargaExitosa;
    void Start()
    {
        rutaArchivoCSV = Application.persistentDataPath + "/datosUsuariosPet.csv";
        rutaArchivoJSON = Application.persistentDataPath + "/datosUsuariosPet.json";
        descargaExitosa.enabled = false;
    }

    public void Exportar()
    {
        if(!File.Exists(rutaArchivoJSON))
        {
            Debug.LogWarning("No se encontró el archivo JSON para exportar.");
            return;
        }

        string json = File.ReadAllText(rutaArchivoJSON);
        Historial historial = JsonUtility.FromJson<Historial>(json);

        if(historial==null||historial.partidas.Count==0)
        {
            Debug.LogWarning("No hay datos para exportar.");
            return;
        }

        var ranking=historial.partidas.OrderByDescending(p => p.puntuacion).ToList();

        List<string>lineas=new List<string>();

        lineas.Add("Nombre;Edad;Ciudad;Correo;Puntuacion;Fecha");

        foreach(var jugador in ranking)
        {
            lineas.Add(
                jugador.nombre + ";" +
                jugador.edad + ";" +
                jugador.ciudad + ";" +
                jugador.correo + ";" +
                jugador.puntuacion + ";" +
                jugador.fecha);
        }

        File.WriteAllLines(rutaArchivoCSV,lineas,Encoding.UTF8);
        Debug.Log("Datos exportados a CSV en: " + rutaArchivoCSV);
        StartCoroutine(MostrarMensajeDescarga());

    }

    private IEnumerator MostrarMensajeDescarga()
    {
        descargaExitosa.enabled = true;
        yield return new WaitForSeconds(1.5f);
        descargaExitosa.enabled = false;
    }

}
