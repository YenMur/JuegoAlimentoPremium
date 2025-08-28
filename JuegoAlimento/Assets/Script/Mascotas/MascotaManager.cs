using UnityEngine;
using UnityEngine.UI;

public class MascotaManager : MonoBehaviour
{

    public BaseDatosMascotas bdMascotas;

    public SpriteRenderer mascotaSprite;

    private int opcionSeleccionada = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("opcionSeleccionada"))
        {
            opcionSeleccionada = 0;
        }
        else
        {
            Load();
        }

        ActualizarMascota(opcionSeleccionada);
    } 

    public void SiguienteOpcion()
    {

        opcionSeleccionada++;
        if (opcionSeleccionada >= bdMascotas.MascotaCount)
        {
            opcionSeleccionada = 0;
        }

        ActualizarMascota(opcionSeleccionada);
        Save();
    }

    public void OpcionAnterior()
    {
        opcionSeleccionada--;
        if (opcionSeleccionada < 0)
        {
            opcionSeleccionada = bdMascotas.MascotaCount - 1;
        }

        ActualizarMascota(opcionSeleccionada);
        Save();
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

    private void Save()
    {
        PlayerPrefs.SetInt("opcionSeleccionada", opcionSeleccionada);
    }

}
