using System.Collections;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject activator1;
    public GameObject activator2;
    public GameObject activator3;
    public GameObject activator4;
    public GameObject activator5;
    public GameObject activator6;
    public GameObject activator7;
    public GameObject activator8;
    public GameObject Settler1;
    public GameObject Settler2;
    public GameObject Settler3;
    public GameObject Settler4;
    public GameObject Settler5;
    public GameObject Settler6;
    public GameObject Settler7;
    public GameObject Settler8;
    private GameObject[] activatorArray;
    private GameObject[] settlerArray;
    public GameObject leaderCharacter;
    public GameObject gameManager;
    private GameObject targetSeat;
    [SerializeField]
    private GameObject activatedCapsule;
    private int emptySeatNumber;
    public AudioSource deniedSound; public AudioSource activatorClickSound; public AudioSource settlerClickSound;


    // Start is called before the first frame update
    void Start()
    {
        activatorArray = new GameObject[] { activator1, activator2, activator3, activator4, activator5, activator6, activator7, activator8 };
        settlerArray = new GameObject[] { Settler1, Settler2, Settler3, Settler4, Settler5, Settler6, Settler7, Settler8 };

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 150f))
            {
                if (hit.transform.gameObject.layer == 6)
                {
                    // . . when an activator is clicked
                    // . . disable activators and enable settlers
                    disableObjects(activatorArray);
                    enableObjects(settlerArray);

                    activatorClickSound.Play();

                    // . . storing activated capsule
                    gameManager.GetComponent<GameManagerScript>().Set_ActivatedCapsule(hit.transform.gameObject.GetComponentInParent<Transform>().gameObject);

                    // . . enabling activated capsule light
                    ActivatedColor(hit.transform.gameObject.GetComponentInParent<Transform>().GetComponentInChildren<CapsuleController>().findLeader(), hit.transform.gameObject);

                }

                // 7 is settler object and second condition is for not clicking the same capsule
                else if (hit.transform.gameObject.layer == 7 && hit.transform.parent.name != gameManager.GetComponent<GameManagerScript>().Get_ActivatedCapsule().name)
                {
                    // . . when a settler is clicked

                    // . . enabling settlers
                    disableObjects(settlerArray);
                    enableObjects(activatorArray);

                    settlerClickSound.Play();

                    // . . assigning activated capsule
                    activatedCapsule = gameManager.GetComponent<GameManagerScript>().Get_ActivatedCapsule();

                    // . . disable activator lights
                    activatedCapsule.GetComponentInChildren<Light>().enabled = false;

                    // . . checking LeadershipStatus in ActivatedCapsule
                    activatedCapsule.GetComponentInChildren<CapsuleController>().LeadershipStatus();

                    // . . telling gameManager ActiveLeader
                    gameManager.GetComponent<GameManagerScript>().Set_Leader(activatedCapsule.GetComponentInChildren<CapsuleController>().leader3);

                    // . . getting the active leaderCharacter from the gameManager
                    leaderCharacter = gameManager.GetComponent<GameManagerScript>().Get_Leader();

                    // . . determine targetSeat for leader
                    targetSeat = hit.transform.gameObject.GetComponentInParent<Transform>().GetComponentInChildren<CapsuleController>().DetermineLeaderTargetSeat();

                    // . . updating setting targetSeat for Leader
                    leaderCharacter.GetComponent<CharacterTargetData>().setTargetSeat(targetSeat);

                    // . . updating targetSeat status
                    leaderCharacter.GetComponent<CharacterTargetData>().getTargetSeat().GetComponent<SeatController>().SetLoaded();

                    // . . moving leader
                    leaderCharacter.GetComponent<PlayerController>().MoveToTarget(leaderCharacter.GetComponent<CharacterTargetData>().getTargetSeat().transform);

                    // . . setting follower targetSeats
                    if (leaderCharacter.GetComponent<CharacterTargetData>().targetSeat != leaderCharacter.GetComponent<CharacterTargetData>().currentSeat)
                    {
                        activatedCapsule.GetComponentInChildren<CapsuleController>().followerTargetObjectSetter(leaderCharacter);
                    }
                    
                    
                    // . . resetting values at the gameManager
                    leaderCharacter.GetComponent<CharacterTargetData>().resetTargetSeat();
                    gameManager.GetComponent<GameManagerScript>().Reset_ActivatedCapsule();
                    gameManager.GetComponent<GameManagerScript>().Reset_Leader();
                    gameManager.GetComponent<GameManagerScript>().Reset_Target();

                }
            }
        }

        void disableObjects(GameObject[] objectArray)
        {
            foreach (GameObject obj in objectArray)
            {
                obj.SetActive(false);
                foreach (Behaviour childComponents in obj.GetComponentsInChildren<Behaviour>())
                {
                    childComponents.enabled = false;
                }
                obj.GetComponent<BoxCollider>().enabled = false;
            }
        }

        void enableObjects(GameObject[] objectArray)
        {
            foreach (GameObject obj in objectArray)
            {
                obj.SetActive(true);
                foreach (Behaviour childComponents in obj.GetComponentsInChildren<Behaviour>())
                {
                    childComponents.enabled = true;
                }
                obj.GetComponent<BoxCollider>().enabled = true;
            }
        }
        void ActivatedColor(GameObject leader, GameObject hit)
        {
            if (leader.gameObject.tag == "BlueGuys")
            {
                hit.transform.gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInChildren<Light>().color = new Color32(0, 121, 255, 0);
            }
            else if (leader.gameObject.tag == "OrangeGuys")
            {
                hit.transform.gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInChildren<Light>().color = new Color32(255, 102, 0, 0);
            }
            else if (leader.gameObject.tag == "GreenGuys")
            {
                hit.transform.gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInChildren<Light>().color = new Color32(36, 255, 0, 228);
            } 
            else if (leader.gameObject.tag == "RedGuys")
            {
                hit.transform.gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInChildren<Light>().color = new Color32(255, 35, 0, 150);
            }
            
            else if (leader.gameObject.tag == "PurpleGuys")
            {
                hit.transform.gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInChildren<Light>().color = new Color32(93, 0, 130, 150);
            }
            else if (leader.gameObject.tag == "PinkGuys")
            {
                hit.transform.gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInChildren<Light>().color = new Color32(255, 0, 234, 0);
            }
            hit.transform.gameObject.GetComponentInParent<Transform>().gameObject.GetComponentInChildren<Light>().enabled = true;
        }
    }
}
