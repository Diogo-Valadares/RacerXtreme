using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public static TargetSpawner current;

    [SerializeField]
    private GameObject badTarget;
    [SerializeField]
    private GameObject goodTarget;
    [SerializeField]
    private GameObject excelentTarget;
    [SerializeField]
    private List<SpawnPoint> spawnPoints;

    [System.Serializable]
    private class SpawnPoint
    {
        public Transform leftSpawn;
        [HideInInspector]
        public GameObject leftTarget;
        public Transform rightSpawn;
        [HideInInspector]
        public GameObject rightTarget;
    }

    private void Awake()
    {
        current = this;
    }

    public void RespawnTargets()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            if (spawnPoint.leftTarget != null) Destroy(spawnPoint.leftTarget);
            if (spawnPoint.rightTarget != null) Destroy(spawnPoint.rightTarget);
            switch(Random.Range(0, 4))
            {
                case 0:
                    spawnPoint.leftTarget = Instantiate(goodTarget, spawnPoint.leftSpawn);
                    spawnPoint.rightTarget = Instantiate(goodTarget, spawnPoint.rightSpawn);
                    break;
                case 1:
                    spawnPoint.leftTarget = Instantiate(badTarget, spawnPoint.leftSpawn);
                    spawnPoint.rightTarget = Instantiate(excelentTarget, spawnPoint.rightSpawn);
                    break;
                case 2:
                    spawnPoint.leftTarget = Instantiate(goodTarget, spawnPoint.leftSpawn);
                    spawnPoint.rightTarget = Instantiate(goodTarget, spawnPoint.rightSpawn);
                    break;
                case 3:
                    spawnPoint.leftTarget = Instantiate(excelentTarget, spawnPoint.leftSpawn);
                    spawnPoint.rightTarget = Instantiate(badTarget, spawnPoint.rightSpawn);
                    break;
            }
            spawnPoint.leftTarget.transform.localPosition = Vector2.zero;
            spawnPoint.rightTarget.transform.localPosition = Vector2.zero;
        }
    }
}
