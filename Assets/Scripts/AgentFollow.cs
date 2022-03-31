using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AgentFollow : MonoBehaviour
{
    public NavMeshAgent followerAgent;
    public ThirdPersonCharacter Character;
    public GameObject followerTargetSeat;
    public Rigidbody rb;

    [SerializeField]
    Transform target;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        followerAgent.updateRotation = false;
    }


    private void Update()
    {
        if (followerTargetSeat != null)
        {
            followerAgent.SetDestination(followerTargetSeat.transform.position);
            if (followerAgent.remainingDistance > followerAgent.stoppingDistance)
            {
                Character.Move(followerAgent.desiredVelocity, false, false);
            }
            else
            {
                Character.Move(Vector3.zero, false, false);
            }
        }
    }


    public Transform SetTarget(GameObject targetObject) // follower needs targetObject to have a targetSeat to calculate its own targetSeat
    {
        Debug.Log(targetObject.GetComponent<CharacterTargetData>().targetSeat.transform.GetSiblingIndex());
        Debug.Log(targetObject.GetComponent<CharacterTargetData>().targetSeat.transform.parent.GetChild(targetObject.GetComponent<CharacterTargetData>().targetSeat.transform.GetSiblingIndex() + 1));
        followerTargetSeat = targetObject.GetComponent<CharacterTargetData>().targetSeat.transform.parent.GetChild(targetObject.GetComponent<CharacterTargetData>().targetSeat.transform.GetSiblingIndex() + 1).gameObject;
        this.gameObject.GetComponent<CharacterTargetData>().setTargetSeat(followerTargetSeat);
        return followerTargetSeat.transform;
    }
}
