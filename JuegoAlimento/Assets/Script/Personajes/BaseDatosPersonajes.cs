using UnityEngine;

[CreateAssetMenu]
public class BaseDatosPersonajes : ScriptableObject
{
   public Personajes[] personajes;

    public int PersonajesCount
    {
        get { return personajes.Length; }
    }

    public Personajes GetPersonaje(int index)
    {
        return personajes[index];
    }
}
