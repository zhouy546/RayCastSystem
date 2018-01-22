using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {
    public delegate void  Onclick();
    public static event Onclick OnClickEvent;
    public Transform RayCastHolder;
	// Use this for initialization
	void Start () {
		
	}
    // Update is called once per frame
    void Update () {
        OnClick();
    }

    void OnClick() {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "InteractiveObj")
                    {
                        if (RayCastHolder == null)
                        {
                            RayCastHolder = hit.collider.transform;
                            SubScribeAndDeSub(true);
                            Debug.Log("Hit different object, from null to object");
                        }
                        else {
                            if (RayCastHolder != hit.collider.transform)
                            {
                                Debug.Log("Hit different object, unsubscribe the perivous one");
                                SubScribeAndDeSub(false);

                                RayCastHolder = hit.collider.transform;

                                SubScribeAndDeSub(true);
                                Debug.Log("Hit different object, subscribe the current one");
                            }
                            else
                            {
                                RayCastHolder = hit.collider.transform;
                                Debug.Log("Hit same object");
                            }
                        }
                    }
                }

            }
            else
            {
                UnSlect();
            }
            if (OnClickEvent!=null)
            OnClickEvent();
        }
    }

    void SubScribeAndDeSub( bool i) {
        if (RayCastHolder != null) {
            if (RayCastHolder.GetComponent<ClientScript>() != null)
            {
                ClientScript client = RayCastHolder.GetComponent<ClientScript>();
                if (!i)
                {
                    client.UnSubscribe();
                }
                else
                {
                    client.SubScribe();
                }
            }
        }
    }


    public void UnSlect() {
        Debug.Log("HIT NOTHING Current client DeSubscribe !");
        SubScribeAndDeSub(false);
        RayCastHolder = null;
    }
}

