using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    public SeatController Seat1;
    public SeatController Seat2;
    public SeatController Seat3;
    public SeatController Seat4;
    public GameObject leader3 = null;
    public GameObject follower1 = null;
    public GameObject follower2 = null;
    public GameObject follower3 = null;
    public GameObject gameManager;
    public bool capsuleDone = false;
    public int emptySeatCount;
    public AudioSource capsuleCompletedSound;
    private bool isCapsuleCompleteSoundPlayed;
    

    void Start()
    {
        capsuleDone = false;
        isCapsuleCompleteSoundPlayed = false;
    }

    private void Update()
    {
        EmptySeat();
        if (Seat4.what_is_above() == Seat3.what_is_above() && Seat3.what_is_above() == Seat2.what_is_above() && Seat2.what_is_above() == Seat1.what_is_above() && Seat4.is_loaded)
        {
            capsuleDone = true;
            foreach (SeatController obj in new SeatController[] { Seat1, Seat2, Seat3, Seat4 })
            {
                obj.GetAboveObject().GetComponentInChildren<Light>().enabled = true;
                if (!isCapsuleCompleteSoundPlayed)
                {
                    capsuleCompletedSound.Play();
                    this.gameObject.GetComponent<CapsuleController>().isCapsuleCompleteSoundPlayed = true;
                }
            }
            leader3 = null; follower3 = null; follower2 = null; follower1 = null;
        }
        
    }

    public void LeadershipStatus() // . . capsule button activates this function.
    {

        if (capsuleDone == false)
        {
            if (Seat4.is_anything_above())
            {
                if (Seat4.is_anything_above())
                {
                    if (Seat4.what_is_above() == Seat3.what_is_above() && Seat3.what_is_above() == Seat2.what_is_above() && Seat2.what_is_above() == Seat1.what_is_above() && Seat4.is_loaded)
                    {
                        // . . assigning leader and followers
                        leader3 = null;
                        follower3 = null;
                        follower2 = null;
                        follower1 = null;
                    }
                    else if (Seat4.what_is_above() == Seat3.what_is_above() && Seat3.what_is_above() == Seat2.what_is_above() && Seat2.what_is_above() != Seat1.what_is_above() && Seat1.is_loaded)
                    {
                        // . . assigning leader and followers
                        leader3 = Seat4.GetAboveObject();
                        follower3 = Seat3.GetAboveObject();
                        follower2 = Seat2.GetAboveObject();
                        follower1 = null;

                        // . . leader can move followers can't
                        leader3.GetComponent<PlayerController>().enabled = true;
                        follower3.GetComponent<PlayerController>().enabled = false;
                        follower2.GetComponent<PlayerController>().enabled = false;

                        // . . scripts adjusted
                        follower3.GetComponent<AgentFollow>().enabled = true;
                        follower2.GetComponent<AgentFollow>().enabled = true;
                        leader3.GetComponent<AgentFollow>().enabled = false;


                    }
                    else if (Seat4.what_is_above() == Seat3.what_is_above() && Seat3.what_is_above() != Seat2.what_is_above() && Seat2.is_loaded && Seat1.is_loaded)
                    {
                        // . . assigning leader and follower
                        leader3 = Seat4.GetAboveObject();
                        follower3 = Seat3.GetAboveObject();
                        follower2 = null;
                        follower1 = null;

                        // . . leader can move, follower can't
                        leader3.GetComponent<PlayerController>().enabled = true;
                        follower3.GetComponent<PlayerController>().enabled = false;

                        // . . scripts adjusted
                        follower3.GetComponent<AgentFollow>().enabled = true;
                        leader3.GetComponent<AgentFollow>().enabled = false;

                    }
                    else if (Seat4.what_is_above() != Seat3.what_is_above() &&  Seat4.is_loaded && Seat3.is_loaded && Seat2.is_loaded && Seat1.is_loaded)
                    {
                        // . . assigning leader
                        leader3 = Seat4.GetAboveObject();
                        follower3 = null;
                        follower2 = null;
                        follower1 = null;

                        // . . leader can move
                        leader3.GetComponent<PlayerController>().enabled = true;

                        // . . scripts adjusted
                        leader3.GetComponent<AgentFollow>().enabled = false;

                    }
                }
            }
            else if (Seat4.is_anything_above() == false && Seat3.is_anything_above() && Seat2.is_anything_above() && Seat1.is_anything_above())
            {
                if (Seat3.what_is_above() == Seat2.what_is_above() && Seat2.what_is_above() == Seat1.what_is_above() && Seat3.is_loaded)
                {
                    // . . assigning leaders and followers
                    leader3 = Seat3.GetAboveObject();
                    follower3 = Seat2.GetAboveObject();
                    follower2 = Seat1.GetAboveObject();
                    follower1 = null;


                    // . . everyone can move
                    leader3.GetComponent<PlayerController>().enabled = true;
                    follower3.GetComponent<PlayerController>().enabled = false;
                    follower2.GetComponent<PlayerController>().enabled = false;

                    // . . scripts adjusted
                    follower3.GetComponent<AgentFollow>().enabled = true;
                    follower2.GetComponent<AgentFollow>().enabled = true;
                    leader3.GetComponent<AgentFollow>().enabled = false;

                }
                else if (Seat3.what_is_above() == Seat2.what_is_above() && Seat2.what_is_above() != Seat1.what_is_above() && Seat1.is_loaded)
                {
                    // . . first 2 tiles has the same color

                    // . . assigning leaders and followers
                    follower1 = null;
                    follower2 = null;
                    follower3 = Seat2.GetAboveObject();
                    leader3 = Seat3.GetAboveObject();

                    // . . leader can move and follower can't.
                    leader3.GetComponent<PlayerController>().enabled = true;
                    follower3.GetComponent<PlayerController>().enabled = false;

                    // . . scripts adjusted
                    follower3.GetComponent<AgentFollow>().enabled = true;
                    leader3.GetComponent<AgentFollow>().enabled = false;


                }
                else if (Seat3.what_is_above() != Seat2.what_is_above() && Seat2.is_loaded == true)
                {
                    // . . no common color in characters at outer tiles
                    // . . only leader3 should move

                    // . . assigning leader
                    leader3 = Seat3.GetAboveObject();
                    follower1 = null;
                    follower2 = null;
                    follower3 = null;

                    // . . leader can move.
                    leader3.GetComponent<PlayerController>().enabled = true;

                    // . . scripts adjusted
                    leader3.GetComponent<AgentFollow>().enabled = false;

                }
            }
            else if (Seat4.is_anything_above() == false && Seat3.is_anything_above() == false && Seat2.is_anything_above() && Seat1.is_anything_above())
            {
                if (Seat2.what_is_above() == Seat1.what_is_above())
                {
                    // outer seat is empty and seat1 and seat2 has the same colors
                    // . . assigning leader and follower
                    follower1 = null;
                    follower2 = null;
                    follower3 = Seat1.GetAboveObject();
                    leader3 = Seat2.GetAboveObject();

                    // . . leader can move and follower can't
                    leader3.GetComponent<PlayerController>().enabled = true;
                    follower3.GetComponent<PlayerController>().enabled = false;

                    // . . scripts adjusted
                    follower3.GetComponent<AgentFollow>().enabled = true;
                    leader3.GetComponent<AgentFollow>().enabled = false;

                }
                else if (Seat2.what_is_above() != Seat1.what_is_above())
                {
                    // ouuter seat is empty and seat1 and seat2 has different colors
                    // . . assigning leader
                    follower1 = null;
                    follower2 = null;
                    follower3 = null;
                    leader3 = Seat2.GetAboveObject();

                    // . . leader can move
                    leader3.GetComponent<PlayerController>().enabled = true;

                    // . . scripts adjusted
                    leader3.GetComponent<AgentFollow>().enabled = false;

                }
            }
            else if (Seat4.is_anything_above() == false && Seat3.is_anything_above() == false && Seat2.is_anything_above() == false & Seat1.is_anything_above())
            {
                // . . first two seats are empty. only the last one has an object above it.
                // . . assigning leader
                follower1 = null;
                follower2 = null;
                follower3 = null;
                leader3 = Seat1.GetAboveObject();

                // . . leader can move
                leader3.GetComponent<PlayerController>().enabled = true;

                // . . scripts adjusted
                leader3.GetComponent<AgentFollow>().enabled = false;
            }
        }
    }

    public int EmptySeat()
    {
        if (Seat1.is_loaded && Seat2.is_loaded && Seat3.is_loaded && Seat4.is_loaded)
        {
            emptySeatCount = 0;
            return emptySeatCount;
        } else if (Seat1.is_loaded && Seat2.is_loaded && Seat3.is_loaded && Seat4.is_loaded == false)
        {
            emptySeatCount = 1;
            return emptySeatCount;
        } else if (Seat1.is_loaded && Seat2.is_loaded && Seat3.is_loaded == false && Seat4.is_loaded == false)
        {
            emptySeatCount = 2;
            return emptySeatCount;
        } else if (Seat1.is_loaded && Seat2.is_loaded == false && Seat3.is_loaded == false && Seat4.is_loaded == false)
        {
            emptySeatCount = 3;
            return emptySeatCount;
        } else if (Seat1.is_loaded == false && Seat2.is_loaded == false && Seat3.is_loaded == false && Seat4.is_loaded == false)
        {
            emptySeatCount = 4;
            return emptySeatCount;
        } return -1;
    }

    public GameObject DetermineLeaderTargetSeat()
    {
        leader3 = gameManager.gameObject.GetComponent<GameManagerScript>().Get_Leader();
        if (Seat4.is_loaded == false && Seat3.is_loaded == false && Seat2.is_loaded && Seat1.is_loaded)
        {
            if (leader3.gameObject.tag == Seat2.what_is_above())
            {
                gameManager.GetComponent<GameManagerScript>().Set_Target(Seat3.gameObject);
                return Seat3.gameObject;
            }
            return leader3.GetComponent<CharacterTargetData>().currentSeat;
        } else if (Seat4.is_loaded == false && Seat3.is_loaded == false && Seat2.is_loaded == false && Seat1.is_loaded)
        {
            if (leader3.gameObject.tag == Seat1.what_is_above())
            {
                gameManager.GetComponent<GameManagerScript>().Set_Target(Seat2.gameObject);
                return Seat2.gameObject;
            }
            return leader3.GetComponent<CharacterTargetData>().currentSeat;
        }
        else if (Seat4.is_loaded == false && Seat3.is_loaded == false && Seat2.is_loaded == false && Seat1.is_loaded == false)
        {
            gameManager.GetComponent<GameManagerScript>().Set_Target(Seat1.gameObject);
            return Seat1.gameObject;

        }else if (Seat4.is_loaded == false && Seat3.is_loaded && Seat2.is_loaded && Seat1.is_loaded)
        {
            if (leader3.gameObject.tag == Seat3.what_is_above())
            {
                gameManager.GetComponent<GameManagerScript>().Set_Target(Seat4.gameObject);
                return Seat4.gameObject;
            }
        }
        return leader3.GetComponent<CharacterTargetData>().currentSeat;
    }


    public GameObject findLeader() // . . capsule button activates this function.
    {
        if (capsuleDone == false)
        {
            if (Seat4.is_anything_above())
            {
                if (Seat4.is_anything_above())
                {
                    if (Seat4.what_is_above() == Seat3.what_is_above() && Seat3.what_is_above() == Seat2.what_is_above() && Seat2.what_is_above() == Seat1.what_is_above() && Seat4.is_loaded)
                    {
                        leader3 = null;
                    } else
                    {
                        leader3 = Seat4.GetAboveObject();
                        return leader3;
                    }
                    return leader3;
                }
            }
            else if (Seat4.is_anything_above() == false && Seat3.is_anything_above() && Seat2.is_anything_above() && Seat1.is_anything_above())
            {
                leader3 = Seat3.GetAboveObject();
                return leader3;
            }
            else if (Seat4.is_anything_above() == false && Seat3.is_anything_above() == false && Seat2.is_anything_above() && Seat1.is_anything_above())
            {
                leader3 = Seat2.GetAboveObject();
                return leader3;
            }
            else if (Seat4.is_anything_above() == false && Seat3.is_anything_above() == false && Seat2.is_anything_above() == false & Seat1.is_anything_above())
            {
                leader3 = Seat1.GetAboveObject();
                return leader3;
            }
        } return null;
    }

    public void followerTargetObjectSetter(GameObject leaderCharacter)
    {
        if (follower3 != null && leaderCharacter.GetComponent<CharacterTargetData>().targetSeat.transform.parent.GetComponent<CapsuleController>().emptySeatCount > 1)
        {
            follower3.GetComponent<AgentFollow>().SetTarget(leaderCharacter);
        }
        if (follower2 != null && leaderCharacter.GetComponent<CharacterTargetData>().targetSeat.transform.parent.GetComponent<CapsuleController>().emptySeatCount > 2)
        {
            follower2.GetComponent<AgentFollow>().SetTarget(follower3);
        }
        if (follower1 != null && leaderCharacter.GetComponent<CharacterTargetData>().targetSeat.transform.parent.GetComponent<CapsuleController>().emptySeatCount > 3)
        {
            follower1.GetComponent<AgentFollow>().SetTarget(follower1);
        }
    }
}
