using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int points = 1;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Collider2D collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.current.AddPoints(points);
        collider.enabled = false;
        sprite.enabled = false;
        audioSource.Play();
        Destroy(gameObject, audioSource.clip.length);
    }
}
