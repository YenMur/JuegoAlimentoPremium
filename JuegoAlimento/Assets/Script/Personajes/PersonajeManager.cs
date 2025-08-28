using UnityEngine;
using UnityEngine.UI;

public class PersonajeManager : MonoBehaviour
{
    public BaseDatosPersonajes bdPersonajes;

    public SpriteRenderer personajeSprite;

    private int opcionSeleccionada = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        Save();
    }

    public void OpcionAnterior()
    {
        opcionSeleccionada--;
        if (opcionSeleccionada < 0)
        {
            opcionSeleccionada = bdPersonajes.PersonajesCount - 1;
        }
        UpdateCharacter(opcionSeleccionada);
        Save();
    }

    private void UpdateCharacter(int opcionSeleccionada)
    {
        Personajes personaje = bdPersonajes.GetPersonaje(opcionSeleccionada);
        personajeSprite.sprite = personaje.personajeSprite;
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
