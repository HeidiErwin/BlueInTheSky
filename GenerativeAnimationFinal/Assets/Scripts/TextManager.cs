using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private string[] textOptions;
    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject downArrow;
    private int currentOptionIndex = 0;
    private Text text;
    [SerializeField] private Text responseText;
    [SerializeField] private string[] responseTexts;

    private void Start() {
        text = this.gameObject.GetComponent<Text>();
        text.text = textOptions[0];
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            MoveTextOptionNext();
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            MoveTextOptionPrev();
        }
    }

    // TODO: ENSURE CAN ONLY CHANGE TEXT OPTIONS IF UR CURRENTLY ON THAT PANEL
    private void MoveTextOptionNext() {
        if (currentOptionIndex + 1 < textOptions.Length) {
            currentOptionIndex++;
            text.text = textOptions[currentOptionIndex];
            if (currentOptionIndex >= textOptions.Length - 1) { // if last option rn
                downArrow.SetActive(false);
            }
            if (currentOptionIndex == 1) { // if leaving first option
                upArrow.SetActive(true);
            }
            UpdateResponseText();
        }
    }

    private void MoveTextOptionPrev() {
        if (currentOptionIndex > 0) {
            currentOptionIndex--;
            text.text = textOptions[currentOptionIndex];
            if (currentOptionIndex == 0) { // if first option rn
                upArrow.SetActive(false);
            } 
            if (currentOptionIndex == textOptions.Length - 2) { // if leaving last option
                downArrow.SetActive(true);
            }
            UpdateResponseText();
        }
    }

    private void UpdateResponseText() {
        if (responseText != null) {
            responseText.text = responseTexts[currentOptionIndex];
        }
    }
}
