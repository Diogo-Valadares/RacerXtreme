using UnityEngine;

public class LayerChangerBlocker : MonoBehaviour
{
    public bool isBlocking { get; private set; } = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        isBlocking = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isBlocking = false;
    }
}
