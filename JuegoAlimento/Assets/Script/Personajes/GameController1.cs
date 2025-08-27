using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    [SerializeField] private TMP_InputField ITNombre;
    [SerializeField] private TMP_InputField ITEdad;
    [SerializeField] private TMP_InputField ITCiudad;
    [SerializeField] private TMP_InputField ITCorreo;

    [SerializeField] private TextMeshProUGUI TMP_Alerta;

    private string nombre=GameManager.Instance.datosJugador.nombre;
    private string edad=GameManager.Instance.datosJugador.edad;
    private string ciudad=GameManager.Instance.datosJugador.ciudad;
    private string correo=GameManager.Instance.datosJugador.correo;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TMP_Alerta.gameObject.SetActive(false);
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
                TMP_Alerta.gameObject.SetActive(true);
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
