using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour {

    public GameObject rightHand;
    private int layerMask;
    public GameObject selectionPointer;

	// Use this for initialization
	void Start () {
        layerMask = LayerMask.GetMask("UI");
	}
	
	// Update is called once per frame
	void Update () {
        selectionPointer.SetActive(false);
        Ray ray = new Ray(rightHand.transform.position, rightHand.transform.forward);
        RaycastHit hit;
        if ( Physics.Raycast(ray, out hit, 11f, layerMask))
        {
            selectionPointer.SetActive(true);
            selectionPointer.transform.position = hit.point;
            if(OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0)
            {
                if(hit.collider.tag == "BPM") hit.collider.gameObject.GetComponent<ChangeSpeed>().AssignSpeed();
                if(hit.collider.tag == "Beat") hit.collider.gameObject.GetComponent<NotationLoad>().ChangeBeat();
            }
        }

	}


}
