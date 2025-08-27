using UnityEngine;
using UnityEngine.UI;

public class MascotaManager : MonoBehaviour
{

    public BaseDatosMascotas bdMascotas;
    public Image mascotaImagen;

    private int opcionSeleccionada = 0;

    void Start()
    {
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
    }

    public void OpcionAnterior()
    {
        opcionSeleccionada--;
        if (opcionSeleccionada < 0)
        {
            opcionSeleccionada = bdMascotas.MascotaCount - 1;
        }

        ActualizarMascota(opcionSeleccionada);
    }

    private void ActualizarMascota(int opcionSeleccionada)
    {
        Mascota mascota = bdMascotas.GetMascota(opcionSeleccionada);
        mascotaImagen.sprite = mascota.mascotaSprite;
       
    }
}
