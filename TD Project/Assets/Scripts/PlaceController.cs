using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceController : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MouseDown()
    {
        GetComponent<Renderer>().material.color = new Color(1,0,0);
        Debug.Log("Down");
    }

    public void MouseUp()
    {
        GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        Debug.Log("Up");
    }
}
