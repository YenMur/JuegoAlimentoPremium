using UnityEngine;

public class Pet : MonoBehaviour
{

    public BaseDatosMascotas bdMascotas;

    public SpriteRenderer mascotaSprite;

    private int opcionSeleccionada = 0;
    private Mascotas mascotaActual;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!PlayerPrefs.HasKey("opcionSeleccionada"))
        {
            opcionSeleccionada = 0;
        }
        else
        {
            opcionSeleccionada = PlayerPrefs.GetInt("opcionSeleccionada");
        }

        mascotaActual=bdMascotas.GetMascota(opcionSeleccionada);

        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name=="Resultado")
        {
            if (GameManager.Instance.partidaGanada)
            {
                mascotaSprite.sprite = mascotaActual.mascotaFeliz;
            }
            else
            {
                mascotaSprite.sprite = mascotaActual.mascotaTriste;
            }
        }
        else
        {
            mascotaSprite.sprite = mascotaActual.mascotaSprite;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActualizarMascota(int opcionSeleccionada)
    {
        Mascotas mascota = bdMascotas.GetMascota(opcionSeleccionada);
        mascotaSprite.sprite = mascota.mascotaSprite;

    }

    private void Load()
    {
        opcionSeleccionada = PlayerPrefs.GetInt("opcionSeleccionada");
    }

}
