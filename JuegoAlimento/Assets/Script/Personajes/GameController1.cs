using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    [SerializeField] private TMP_InputField ITNombre;
    [SerializeField] private TMP_InputField ITEdad;
    [SerializeField] private TMP_InputField ITCiudad;
    [SerializeField] private TMP_InputField ITCorreo;

    private string nombre;
    private string edad;
    private string ciudad;
    private string correo;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuardarDatos()
    {
        
            nombre = ITNombre.text.Trim();
            edad = ITEdad.text.Trim();
            ciudad = ITCiudad.text.Trim();
            correo = ITCorreo.text.Trim();

            if(string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(edad) || string.IsNullOrEmpty(ciudad) || string.IsNullOrEmpty(correo))
            {
                Debug.LogWarning("Por favor, complete todos los campos.");
                return;
            }
        
            Debug.Log("Datos guardados:");
            Debug.Log("Nombre: " + nombre);
            Debug.Log("Edad: " + edad);
            Debug.Log("Ciudad: " + ciudad);
            Debug.Log("Correo: " + correo);

            SiguienteEscena();
        
    }

    public void SiguienteEscena()
    {
        SceneManager.LoadScene("Mascota");
    }

}
