using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
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

    private void UpdateCharacter(int opcionSeleccionada)
    {
        Personajes personaje = bdPersonajes.GetPersonaje(opcionSeleccionada);
        personajeSprite.sprite = personaje.personajeSprite;
    }

    private void Load()
    {
        opcionSeleccionada = PlayerPrefs.GetInt("opcionSeleccionada");
    }

}
