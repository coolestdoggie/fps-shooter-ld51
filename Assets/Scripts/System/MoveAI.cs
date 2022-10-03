
using UnityEngine;
using UnityEngine.AI;
public class MoveAI : MonoBehaviour
{
    public float agroDistance = 20f;
    private NavMeshAgent _agent;
    private GameObject _player;
    private bool isFollow = false;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Vector3 playerPos = _player.transform.position;
        Vector3 enemyPos = transform.position;
        if (!GameSystem.Instance.GameRunning)
        {
            return;
        }
        float distance = Vector3.Distance(enemyPos, playerPos);
        RaycastHit raycastHit = new RaycastHit();
        Physics.Linecast(enemyPos, playerPos, out raycastHit);
        if (raycastHit.collider != null && raycastHit.collider.CompareTag("Player"))
        {
            isFollow = true;
        }
        if (distance > agroDistance)
        {
            isFollow = false;
        }
        if (isFollow)
        {
            _agent.destination = playerPos;
        }
    }
}
