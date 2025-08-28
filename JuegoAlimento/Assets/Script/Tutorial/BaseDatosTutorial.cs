using UnityEngine;

[CreateAssetMenu]
public class BaseDatosTutorial : ScriptableObject
{
    public TutorialPaso[] pasos;

    public int PasoCount
    {
        get { return pasos.Length; }
    }

    public TutorialPaso GetPaso(int index)
    {
        return pasos[index];
    }
}
