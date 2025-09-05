using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public BaseDatosPersonajes bdPersonajes;

    public SpriteRenderer personajeSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int opcionSeleccionada = GameManager.Instance.personajeSeleccionado;

        UpdateCharacter(opcionSeleccionada);
    }

    private void UpdateCharacter(int opcionSeleccionada)
    {
        Personajes personaje = bdPersonajes.GetPersonaje(opcionSeleccionada);
        personajeSprite.sprite = personaje.personajeSprite;
    }


}
