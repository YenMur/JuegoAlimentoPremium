using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 8f;
    public float limiteIzquierdo = -8f;
    public float limiteDerecho = 8f;

    void Update()
    {
        float dir = Input.GetAxis("Horizontal");

        if (dir != 0)
        {
            Vector3 movimiento = new Vector3(dir * velocidad * Time.deltaTime, 0f, 0f);
            transform.Translate(movimiento);

            Vector3 posicionActual = transform.position;
            posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
            transform.position = posicionActual;
        }
    }
}
