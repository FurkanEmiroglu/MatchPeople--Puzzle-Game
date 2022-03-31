using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class SeatController : MonoBehaviour
{
    // a boolean for checking if the seat is loaded or not (something is above maybe)
    public bool is_loaded = false;
    public string Collider_Tag;
    public GameObject Above_Object;

    /*private string OnTriggerEnter(Collider other)
    {
        is_loaded = true;
        Collider_Tag = other.gameObject.tag;
        Above_Object = other.gameObject;
        return Collider_Tag;
    }*/

    void OnTriggerStay(Collider other)
    {
        is_loaded = true;
        Collider_Tag = other.gameObject.tag;
        Above_Object = other.gameObject;
    }

    private string OnTriggerExit(Collider other)
    {
        Collider_Tag = null;
        is_loaded = false;
        Above_Object = null;
        return null;
    }

    public bool is_anything_above()
    {
        return is_loaded;
    }

    public string what_is_above()
    {
        // . . if anything is above the tile, this function will return it's tag.
        if (is_loaded == true)
        {
            return Collider_Tag;
        } else
        {
            return null;
        }
    }

    public void SetAbove(GameObject obj)
    {
        is_loaded = true;
        Collider_Tag = obj.transform.tag;
        Above_Object = obj;
    }

    public void ResetAbove()
    {
        is_loaded = false;
        Collider_Tag = null;
    }


    public GameObject GetAboveObject()
    {
        return Above_Object;
    }


    public void adjustStopDistance(GameObject meshObject, float distance)
    {
        meshObject.GetComponent<NavMeshAgent>().stoppingDistance = distance;

    }

    public void SetLoaded()
    {
        is_loaded = true;
    }
    public void SetUnLoaded()
    {
        is_loaded = false;
    }
}
