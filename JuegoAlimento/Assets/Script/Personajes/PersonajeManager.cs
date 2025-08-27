using UnityEngine;
using UnityEngine.UI;

public class PersonajeManager : MonoBehaviour
{
    public BaseDatosPersonajes bdPersonajes;

    public Image personajeImagen;

    private int opcionSeleccionada = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCharacter(opcionSeleccionada);
    }
    
    public void SiguienteOpcion()
    {
        opcionSeleccionada++;

        if (opcionSeleccionada >= bdPersonajes.PersonajesCount)
        {
            opcionSeleccionada = 0;
        }
        UpdateCharacter(opcionSeleccionada);
    }

    public void OpcionAnterior()
    {
        opcionSeleccionada--;
        if (opcionSeleccionada < 0)
        {
            opcionSeleccionada = bdPersonajes.PersonajesCount - 1;
        }
        UpdateCharacter(opcionSeleccionada);
    }

    private void UpdateCharacter(int opcionSeleccionada)
    {
        Personajes personaje = bdPersonajes.GetPersonaje(opcionSeleccionada);
        personajeImagen.sprite = personaje.personajeSprite;
    }
}
