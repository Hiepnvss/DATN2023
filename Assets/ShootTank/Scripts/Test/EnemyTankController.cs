using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    private Vector3 lastKnownPlayerPosition;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Nếu xe tăng địch chưa biết vị trí của người chơi
        if (lastKnownPlayerPosition == null)
        {
            // Nếu xe tăng địch nhìn thấy người chơi, lưu lại vị trí của người chơi
            if (CanSeePlayer())
            {
                lastKnownPlayerPosition = player.transform.position;
            }
        }
        // Nếu xe tăng địch đã biết vị trí của người chơi, di chuyển đến vị trí đó
        else
        {
            navMeshAgent.SetDestination(lastKnownPlayerPosition);
            // Nếu xe tăng địch đến được vị trí của người chơi, xoá vị trí của người chơi
            if (Vector3.Distance(transform.position, lastKnownPlayerPosition) < 1f)
            {
                lastKnownPlayerPosition = Vector3.zero;
            }
        }
    }

    // Kiểm tra xem xe tăng địch có nhìn thấy người chơi không
    private bool CanSeePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity);
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        {
            return true;
        }
        return false;
    }
}