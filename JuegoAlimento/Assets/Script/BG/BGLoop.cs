using UnityEngine;
using UnityEngine.UI;

public class BGLoop : MonoBehaviour
{
    public float speed;

    [SerializeField] private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
