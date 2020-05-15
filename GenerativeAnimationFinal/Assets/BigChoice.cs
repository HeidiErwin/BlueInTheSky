using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigChoice : MonoBehaviour
{
    private TextManager txtMan;
    [SerializeField] GameObject heidi2040;
    [SerializeField] GameObject heidi2060;
    [SerializeField] GameObject heidi2060_2;
    [SerializeField] GameObject heidi2060_3;
    [SerializeField] GameObject heidi2060_4;
    [SerializeField] GameObject heidi2060_5;

    [SerializeField] GameObject heidiBlueMouthOpen2;
    [SerializeField] GameObject heidiBlueMouthClosed3;
    [SerializeField] GameObject heidiBlueMouthClosed4;


    //no sacrifice sprites
    [SerializeField] Sprite heidi2040Sprite;
    [SerializeField] Sprite heidi2060Sprite; // 1 - 5 all old heidi
    [SerializeField] Sprite heidi2060Sprite2;
    [SerializeField] Sprite heidi2060Sprite3;
    [SerializeField] Sprite heidi2060Sprite4;
    [SerializeField] Sprite heidi2060Sprite5;

    //sacrifice sprites
    [SerializeField] Sprite emptyPng; // empty
    // empty
    [SerializeField] Sprite youngHeidiBlue; //youngHeidiBlue
    [SerializeField] Sprite noHeidi2060Sprite3; //youngHeidiBlue
    [SerializeField] Sprite noHeidi2060Sprite4; //youngHeidiBlue
     // empty


    void Start()
    {
        txtMan = this.gameObject.GetComponent<TextManager>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.DownArrow) && txtMan.ctrl.currentPanelIndex == txtMan.myPanelIndex) {
            SacrificeSelf();
            //option 2
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && txtMan.ctrl.currentPanelIndex == txtMan.myPanelIndex) {
            //option 1
            UnsacrificeSelf();
        }
    }

    //default
    private void UnsacrificeSelf() {
        Debug.Log("back to alive");
        heidi2040.GetComponent<SpriteRenderer>().sprite = heidi2040Sprite;
        heidi2060.GetComponent<SpriteRenderer>().sprite = heidi2060Sprite;
        heidi2060_2.GetComponent<SpriteRenderer>().sprite = heidi2060Sprite2;

        heidiBlueMouthClosed3.SetActive(false);
        heidi2060_3.SetActive(true);

        //moment of silence
        heidiBlueMouthClosed4.SetActive(false);
        heidi2060_4.SetActive(true);

        heidi2060_5.GetComponent<SpriteRenderer>().sprite = heidi2060Sprite5;
    }

    private void SacrificeSelf() {
        Debug.Log("DEAD");
        heidi2040.GetComponent<SpriteRenderer>().sprite = emptyPng;

        // just heidi (or empty)
        heidi2060.GetComponent<SpriteRenderer>().sprite = emptyPng;

        // heidi says something
        //heidi2060_2.GetComponent<SpriteRenderer>().sprite = youngHeidiBlue;
        heidiBlueMouthOpen2.SetActive(true);
        heidi2060_2.SetActive(false);

        //shiv responds
        heidiBlueMouthClosed3.SetActive(true);
        heidi2060_3.SetActive(false);

        //moment of silence
        heidiBlueMouthClosed4.SetActive(true);
        heidi2060_4.SetActive(false);

        //vanish
        heidi2060_5.GetComponent<SpriteRenderer>().sprite = emptyPng;
    }
}
