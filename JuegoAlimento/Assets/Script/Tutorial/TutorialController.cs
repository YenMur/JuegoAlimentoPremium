using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public BaseDatosTutorial bdTutorial;  
    public SpriteRenderer tutorialSprite;  
    public Button botonAnterior;       
    public Button botonSiguiente;         

    private int pasoActual = 0;

    void Start()
    {

        pasoActual = 0;



        ActualizarPaso(pasoActual);
    }

    public void SiguientePaso()
    {
        if (pasoActual < bdTutorial.PasoCount - 1)
        {
            pasoActual++;
            ActualizarPaso(pasoActual);

        }
    }

    public void PasoAnterior()
    {
        if (pasoActual > 0)
        {
            pasoActual--;
            ActualizarPaso(pasoActual);

        }
    }

    private void ActualizarPaso(int pasoActual)
    {
        TutorialPaso paso = bdTutorial.GetPaso(pasoActual);
        tutorialSprite.sprite = paso.pasoSprite;

        botonAnterior.gameObject.SetActive(pasoActual != 0);
        botonSiguiente.gameObject.SetActive(pasoActual < bdTutorial.PasoCount - 1);
    }


}