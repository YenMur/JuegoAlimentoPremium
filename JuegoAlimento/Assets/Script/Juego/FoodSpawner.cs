using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour
{
    public BaseDatosComidas baseDatosComidas;
    public GameObject foodPrefab;

    public float tiempoEntreSpawn = 1.5f;
    public float minVelocidadCaida = 2f;
    public float maxVelocidadCaida = 5f;
    public float probabilidadComidaBuena = 70f;

    public float minX = -8f;
    public float maxX = 8f;
    public float alturaSpawn = 8f;

    void Start()
    {
        Debug.Log("FoodSpawner iniciado");
        StartCoroutine(SpawnFoodCoroutine());
    }

    IEnumerator SpawnFoodCoroutine()
    {
        while (true)
        {
            if(!GameManager.Instance.juegoTerminado)
            {
                SpawnFood();
            }
            yield return new WaitForSeconds(tiempoEntreSpawn);
        }
    }

    void SpawnFood()
    {
        if (baseDatosComidas == null || foodPrefab == null)
        {
            Debug.LogError("Referencias no asignadas en el inspector!");
            return;
        }

        Sprite spriteComida;
        bool esBuena;

        if (Random.Range(0f, 100f) <= probabilidadComidaBuena)
        {
            if (baseDatosComidas.ComidasBuenasCount == 0) return;
            spriteComida = baseDatosComidas.GetComidaBuena(Random.Range(0, baseDatosComidas.ComidasBuenasCount));
            esBuena = true;
        }
        else
        {
            if (baseDatosComidas.ComidasMalasCount == 0) return;
            spriteComida = baseDatosComidas.GetComidaMala(Random.Range(0, baseDatosComidas.ComidasMalasCount));
            esBuena = false;
        }

        Vector3 spawnPosition = new Vector3(
            Random.Range(minX, maxX),
            alturaSpawn,
            0f
        );

        GameObject nuevaComida = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        ConfigurarComida(nuevaComida, spriteComida, esBuena);
    }

    void ConfigurarComida(GameObject comidaObj, Sprite sprite, bool esBuena)
    {
        comidaObj.transform.localScale = new Vector3(0.15f, 0.15f, 1f);

        SpriteRenderer spriteRenderer = comidaObj.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = 1; 
        }

        FoodItem foodScript = comidaObj.GetComponent<FoodItem>();
        if (foodScript != null)
        {
            foodScript.velocidadCaida = Random.Range(minVelocidadCaida, maxVelocidadCaida);
            foodScript.esBuena = esBuena;
        }

        ConfigurarCollider(comidaObj, sprite);
    }

    void ConfigurarCollider(GameObject comidaObj, Sprite sprite)
    {
        Collider2D[] collidersExistentes = comidaObj.GetComponents<Collider2D>();
        foreach (Collider2D colliderExistente in collidersExistentes)
        {
            DestroyImmediate(colliderExistente);
        }

        CircleCollider2D nuevoCollider = comidaObj.AddComponent<CircleCollider2D>();
        nuevoCollider.isTrigger = true;

        if (sprite != null)
        {
            nuevoCollider.radius = 0.5f;
        }
        else
        {
            nuevoCollider.radius = 0.4f;
        }

        if (comidaObj.GetComponent<Rigidbody2D>() == null)
        {
            Rigidbody2D rb = comidaObj.AddComponent<Rigidbody2D>();
            rb.bodyType= RigidbodyType2D.Dynamic;
            rb.gravityScale = 0f;   
            rb.freezeRotation = true; 
        }
    }
}