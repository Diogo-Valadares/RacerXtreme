using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCheckpoint : MonoBehaviour
{
    [SerializeField]
    private RaceCounter raceCounter;
    private void OnTriggerEnter2D(Collider2D other)
    {
        raceCounter.hasCheckpointed = true;
    }
}
