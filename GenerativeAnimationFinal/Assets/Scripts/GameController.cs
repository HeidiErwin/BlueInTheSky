using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int currentPanelIndex = 0;
    [SerializeField] private CameraMovement cam;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Animator[] panelAnimations;

    private void Start() {
        for(int i = 1; i < panelAnimations.Length; i++) {
            if (panelAnimations[i] != null) {
                panelAnimations[i].enabled = false;
            }
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !cam.IsMoving() && (currentPanelIndex < panels.Length - 1)) {
            PausePanelAnimations(currentPanelIndex);
            currentPanelIndex++;
            cam.MoveToPanel(panels[currentPanelIndex - 1], panels[currentPanelIndex]);
            StartPanelAnimations(currentPanelIndex);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow) && !cam.IsMoving() && (currentPanelIndex >= 1)) {
            PausePanelAnimations(currentPanelIndex);
            currentPanelIndex--;
            cam.MoveToPanel(panels[currentPanelIndex + 1], panels[currentPanelIndex]);
            StartPanelAnimations(currentPanelIndex);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    private void PausePanelAnimations(int index) {
        if (panelAnimations[index])
            panelAnimations[index].enabled = false;
    }

    private void StartPanelAnimations(int index) {
        if (panelAnimations[index])
            panelAnimations[index].enabled = true;
    }
}
