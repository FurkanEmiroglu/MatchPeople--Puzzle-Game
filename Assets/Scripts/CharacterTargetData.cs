using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTargetData : MonoBehaviour
{
    public GameObject targetSeat;
    public GameObject currentSeat;


    private void Update()
    {
        if (targetSeat == currentSeat)
        {
            targetSeat = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Seats")
        {
            currentSeat = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Seats")
        {
            currentSeat = null;
        }
    }


    public void setTargetSeat(GameObject obj)
    {
        targetSeat = obj.gameObject;
    }

    public GameObject getTargetSeat()
    {
        return targetSeat;
    }

    public void resetTargetSeat()
    {
        targetSeat = null;
    }
}
