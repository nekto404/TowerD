using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Camera camera;
    PlaceController place;
    // Use this for initialization
    void Start() {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        bool isMouseDown = Input.GetMouseButtonDown(0);
        bool isMouseUp = Input.GetMouseButtonUp(0);

        if (isMouseDown || isMouseUp)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag=="TowerPlace")
                {
                    PlaceController tp = hit.collider.gameObject.GetComponent<PlaceController>();
                    if (isMouseDown)
                        tp.MouseDown();
                    else if (isMouseUp)
                    {
                        tp.MouseUp();
                    }
                }
            }
        }
	}
}
