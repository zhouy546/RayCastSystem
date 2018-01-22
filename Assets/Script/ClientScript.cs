using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientScript : MonoBehaviour {

    // Use this for initialization
    public void SubScribe()
    {
        RayCast.OnClickEvent += this.OnClick;
    }

    public void UnSubscribe()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
        RayCast.OnClickEvent -= this.OnClick;
    }
    // Update is called once per frame
    void Update () {
		
	}

    public void OnClick() {
        this.GetComponent<Renderer>().material.color = Color.red;
        Debug.Log(this.name+" " + "is triggered");
    }
}
