using UnityEngine;

public class RaceCounter : MonoBehaviour
{
    public bool hasCheckpointed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasCheckpointed)
        {
            GameManager.current.AddLap();
            hasCheckpointed=false;
        }
    }
}
