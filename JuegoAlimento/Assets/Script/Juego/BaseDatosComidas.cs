using UnityEngine;

[CreateAssetMenu]
public class BaseDatosComidas : ScriptableObject
{
    public Sprite[] spritesComidasBuenas; // Solo sprites de comidas buenas
    public Sprite[] spritesComidasMalas;  // Solo sprites de comidas malas

    public int ComidasBuenasCount
    {
        get { return spritesComidasBuenas.Length; }
    }

    public int ComidasMalasCount
    {
        get { return spritesComidasMalas.Length; }
    }

    public Sprite GetComidaBuena(int index)
    {
        return spritesComidasBuenas[index];
    }

    public Sprite GetComidaMala(int index)
    {
        return spritesComidasMalas[index];
    }
}