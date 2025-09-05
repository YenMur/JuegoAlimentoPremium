using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private SpriteRenderer comida;

    private void OnEnable()
    {
        comida.enabled=GameManager.Instance.partidaGanada;
    }

}
