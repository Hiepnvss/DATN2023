using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavMesh : MonoBehaviour
{
    public float distance = 1;
    public LayerMask layerRaycast;

    public Vector2 dic;

    void Update()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, box.size, 0, dic, distance, layerRaycast);
            if (hit.collider != null)
                Debug.Log(hit.collider.name);
    }
}
