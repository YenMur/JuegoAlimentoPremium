using UnityEngine;

[CreateAssetMenu]
public class BaseDatosMascotas : ScriptableObject
{
    public Mascota[] mascotas;

    public int MascotaCount
    {
        get { return mascotas.Length; }
    }

    public Mascota GetMascota(int index)
    {
        return mascotas[index];
    }
}
