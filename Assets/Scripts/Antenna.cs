using System.Collections;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    [SerializeField]
    private float moveRate = 0.5f;
    [SerializeField]
    private float rotationRate = 0.5f;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private LineRenderer lineRenderer;

    private void Awake()
    {
        transform.parent = null;
    }

    void Update()
    {
        if (target == null) Destroy(gameObject);
        lineRenderer.SetPositions(new Vector3[] { transform.position, target.position });

        var currentRot = transform.rotation.eulerAngles.z;

        transform.SetPositionAndRotation(
            Vector3.Lerp(transform.position, target.position, moveRate * Time.deltaTime),
            Quaternion.Euler(0, 0, Mathf.LerpAngle(currentRot, 0, rotationRate * Time.deltaTime))
            );
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            lineRenderer.SetPositions(new Vector3[] { transform.position, target.position });
        }
    }
}
