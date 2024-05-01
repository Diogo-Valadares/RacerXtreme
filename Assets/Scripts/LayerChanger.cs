using System.Collections.Generic;
using UnityEngine;

public class LayerChanger : MonoBehaviour
{
    [SerializeField]
    private bool triggerOnEnter = true;
    [SerializeField]
    private int targetLayerOnEnter = 5;
    [SerializeField]
    private bool triggerOnExit = false;
    [SerializeField]
    private int targetLayerOnExit = 5;
    [SerializeField]
    private List<Collider2D> bridgeCollider;
    [SerializeField]
    private LayerChangerBlocker LayerChangerBlocker;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerOnEnter && !LayerChangerBlocker.isBlocking)
        {
            foreach(var renderer in other.GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.sortingOrder = targetLayerOnEnter;
            }
            foreach(var collider in bridgeCollider)
            {
                collider.enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (triggerOnExit)
        {
            foreach (var renderer in other.GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.sortingOrder = targetLayerOnExit;
            }
            foreach (var collider in bridgeCollider)
            {
                collider.enabled = true;
            }
        }
    }
}
