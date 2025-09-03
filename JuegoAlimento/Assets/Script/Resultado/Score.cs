using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
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
                TextMeshProUGUI texto = fila.GetComponent<TextMeshProUGUI>();

                texto.text = $"{jugador.nombre}\n {jugador.correo}\n {jugador.ciudad} - {jugador.edad} años \n {jugador.puntuacion:D3} pts - {jugador.fecha}";
            }
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo de ranking.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
