using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private SpriteRenderer comida;

    private void Start()
    {
        if (GameManager.Instance.partidaGanada == true)
        {
            comida.enabled = true;
        }
        else
        {
            comida.enabled = false;
        }
    }

}
