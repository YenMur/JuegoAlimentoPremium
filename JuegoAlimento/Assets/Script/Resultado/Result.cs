using System.Linq;
using TMPro;
using UnityEngine;
using System.IO;

public class Result : MonoBehaviour
{

    [SerializeField] private Transform contenedorRanking;
    [SerializeField] private GameObject prefabDatos;

    private string rutaArchivo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rutaArchivo = Application.persistentDataPath + "/datosUsuariosPet.json";

        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            Historial historial = JsonUtility.FromJson<Historial>(json);

            var ranking = historial.partidas.OrderByDescending(p => p.puntuacion).ToList();

            foreach (var jugador in ranking)
            {
                GameObject fila = Instantiate(prefabDatos, contenedorRanking);
                
                ScoreMenu scoreMenu = fila.GetComponent<ScoreMenu>();
                scoreMenu.Datos(jugador);
            }
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo de ranking.");
        }
    }

}
