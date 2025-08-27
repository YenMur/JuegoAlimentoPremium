using UnityEngine;

[CreateAssetMenu]
public class BaseDatosMascotas : ScriptableObject
{
    public Mascotas[] mascotas;

    public int MascotaCount
    {
        get { return mascotas.Length; }
    }

    public Mascotas GetMascota(int index)
    {
        return mascotas[index];
    }
}
