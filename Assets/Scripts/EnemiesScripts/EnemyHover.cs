using UnityEngine;

public class EnemyHover : MonoBehaviour
{
    public float hoverHeight = 10f;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, hoverHeight * 2))
        {
            transform.position = hit.point + Vector3.up * hoverHeight;
        }
    }
}