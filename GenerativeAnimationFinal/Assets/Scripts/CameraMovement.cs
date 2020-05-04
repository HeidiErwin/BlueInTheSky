using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool moving = false; // is the camera currently moving??
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;
    private Vector3 startingPos;
    private Vector3 endingPos;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private float t = 0.0f;
    private float speed = 1.0f;
   

    public void MoveToPanel(GameObject startPanel, GameObject endPanel) {
        this.startPanel = startPanel;
        this.endPanel = endPanel;
        startingPos = new Vector3(startPanel.transform.position.x, startPanel.transform.position.y, this.transform.position.z);
        endingPos = new Vector3(endPanel.transform.position.x, endPanel.transform.position.y, this.transform.position.z);
        moving = true;

    }


    // Update is called once per frame
    void FixedUpdate() {
        if (moving) {
            t += Time.fixedDeltaTime;
            this.transform.position = Vector3.Lerp(startingPos, endingPos, t / speed);
            if (Vector3.Distance(transform.position, endingPos) < .001f) { // if essentially have arrived
                moving = false;
                t = 0.0f;
            }
        }
    }


    //    public void FixedUpdate() {
    //    if (moving == true) {
    //        float speed = 1.0f;
    //        float step = speed * Time.fixedDeltaTime;
    //        transform.position = Vector3.Lerp(this.transform.position, endingPos, step);
    //        if (Vector3.Distance(transform.position, endingPos) < .001f) { // if essentially have arrived
    //            moving = false;
    //        }
    //    }

    //}

    // returns whether camera is currently moving
    public bool IsMoving() {
        return moving;
    }
}
