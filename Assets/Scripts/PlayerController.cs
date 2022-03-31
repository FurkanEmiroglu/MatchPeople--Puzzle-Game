using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public Camera Cam;
    public NavMeshAgent Agent;
    public ThirdPersonCharacter Character;
    private Transform trans;
    public bool isLeaderMoving;
    [SerializeField]
    Rigidbody rb;

    private void Start()
    {
        // . . disabling rotation because Character will handle the rotation
        Agent.updateRotation = false;
        isLeaderMoving = false;
    }

    private void Update()
    {
        if (trans != null)
        {
            Agent.SetDestination(trans.position);
            if (Agent.remainingDistance > Agent.stoppingDistance)
            {
                Character.Move(Agent.desiredVelocity, false, false);
            }
            else
            {
                StopMoving();
            }
        }
    }

    public void MoveToTarget(Transform transform)
    {
        trans = transform;
    }

    public void StopMoving()
    {
        Character.Move(Vector3.zero, false, false);
    }
}
