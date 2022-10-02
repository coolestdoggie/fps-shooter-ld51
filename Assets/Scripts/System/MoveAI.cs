
using UnityEngine;
using UnityEngine.AI;
public class MoveAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _player;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update(){
        _agent.destination = _player.transform.position;
    }
}
