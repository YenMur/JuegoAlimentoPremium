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
    [SerializeField] private TextMeshProUGUI TMP_CorreoExiste;

    private string nombre;
    private string edad;
    private string ciudad;
    private string correo;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TMP_Alerta.gameObject.SetActive(false);
        TMP_CorreoExiste.gameObject.SetActive(false);


    }



    public void GuardarDatos()
    {
        
            nombre = ITNombre.text.Trim();
            edad = ITEdad.text.Trim();
            ciudad = ITCiudad.text.Trim();
            correo = ITCorreo.text.Trim();

            if(string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(edad) || 
               string.IsNullOrEmpty(ciudad) || string.IsNullOrEmpty(correo))
            {
                
                Debug.LogWarning("Por favor, complete todos los campos.");
                TMP_Alerta.gameObject.SetActive(true);
                TMP_Alerta.text = "Oh oh! Completa todos los campos.";
            return;
            }if(!correo.Contains("@") || !correo.Contains("."))
            {
                Debug.LogWarning("Por favor, ingrese un correo válido.");
                TMP_Alerta.gameObject.SetActive(true);
                TMP_Alerta.text = "Por favor, ingresa un correo válido.";
            return;
            }if(GameManager.Instance.historialPartidas.partidas.Exists(p=>p.correo==correo))
            {
                Debug.LogWarning("El correo ya está registrado.");
                TMP_CorreoExiste.gameObject.SetActive(true);
                return;
            }

        GameManager.Instance.nombreJugador = nombre;
            GameManager.Instance.edadJugador = edad;
            GameManager.Instance.ciudadJugador = ciudad;
            GameManager.Instance.correoJugador = correo;

        SceneManager.LoadScene("Mascota");

    }


}
