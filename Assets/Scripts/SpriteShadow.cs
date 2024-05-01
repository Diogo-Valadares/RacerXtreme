using UnityEngine;

public class SpriteShadow : MonoBehaviour
{
    public SpriteRenderer targetSprite;
    public SpriteRenderer shadowSprite;
    public Vector2 offset = new(0.1f, -0.1f);
    [ExecuteAlways]
    void Update()
    {
        shadowSprite.sortingOrder = targetSprite.sortingOrder - 1;
        shadowSprite.transform.position = (Vector2)targetSprite.transform.position + offset;
    }
}
