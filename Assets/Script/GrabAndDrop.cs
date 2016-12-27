using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDrop : MonoBehaviour {

    GameObject grabbedObject;
    float grabbedobjectSize;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(GetMouseHoverObject(5));
        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null)
                TryGrabObject(GetMouseHoverObject(5));
            else
                Drop();
        }

        if(grabbedObject != null)
        {
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedobjectSize;
            grabbedObject.transform.position = newPosition;
        }
	}

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = transform.position;
        RaycastHit rayCastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if(Physics.Linecast(position, target, out rayCastHit))
        {
            return rayCastHit.collider.gameObject;
        }
        return null;
    }

    void TryGrabObject(GameObject grabObject)
    {
        if (grabObject == null || !CanGrab(grabObject)) return;
        grabbedObject = grabObject;
       grabbedobjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
    }

    void Drop()
    {
        if (grabbedObject == null) return;

        if(grabbedObject.GetComponent<Rigidbody>() != null)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        grabbedObject = null;
    }

    bool CanGrab(GameObject candidate)
    {
        return candidate.GetComponent<Rigidbody>() != null;
    }
}
