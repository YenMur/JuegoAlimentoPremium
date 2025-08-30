using UnityEngine;
using System.Collections;

public class FoodItem : MonoBehaviour
{
    public float velocidadCaida;
    public bool esBuena = true;
    private Rigidbody2D rb;

    private int comidaBuena = 10;
    private int comidaMala = -5;

    private GameController5 gameController;

    void Start()
    {
        gameController=FindFirstObjectByType<GameController5>();

        velocidadCaida = 3f;
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.bodyType= RigidbodyType2D.Dynamic;
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        ConfigurarCollider();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && sr.sortingOrder >= 2)
        {
            sr.sortingOrder = 1; 
        }
    }

    void ConfigurarCollider()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<CircleCollider2D>();
        }

        collider.isTrigger = true;
        collider.radius = 0.4f;
    }

    void Update()
    {
        transform.Translate(Vector3.down * velocidadCaida * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " + other.gameObject.name + " - Tag: " + other.tag);

        if (other.CompareTag("Player"))
        {
            if(esBuena)
            {
                // Aquí puedes agregar lógica para cuando se recoge comida buena
                GameManager.Instance.sumPuntos(comidaBuena);
            }
            else
            {
                // Aquí puedes agregar lógica para cuando se recoge comida mala
                GameManager.Instance.sumPuntos(comidaMala);
                HealthManager.health--;

                if(HealthManager.health <= 0)
                {
                   // GameManager.Instance.GameOver();
                   Debug.Log("Game Over!");
                    gameController.Perder();
                }
            }

            Debug.Log(esBuena ? "¡Comida buena recogida!" : "¡Comida mala recogida!");
            Destroy(gameObject);
        }
    }


    void OnDrawGizmosSelected()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        if (collider != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, collider.radius);
        }
    }


}