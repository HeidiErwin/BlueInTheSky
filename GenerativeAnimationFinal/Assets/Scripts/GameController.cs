using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int currentPanelIndex = 0;
    [SerializeField] private CameraMovement cam;
    [SerializeField] private GameObject[] panels;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !cam.IsMoving() && (currentPanelIndex < panels.Length - 1)) {
            currentPanelIndex++;
            cam.MoveToPanel(panels[currentPanelIndex - 1], panels[currentPanelIndex]);
        } 
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !cam.IsMoving() && (currentPanelIndex >= 1)) {
            currentPanelIndex--;
            cam.MoveToPanel(panels[currentPanelIndex + 1], panels[currentPanelIndex]);

        }
    }
}
