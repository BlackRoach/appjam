﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {

    [SerializeField]
    private GameObject Buttons;
    [SerializeField]
    private GameObject TitleWindow;
    [SerializeField]
    private GameObject OptionWindow;
    [SerializeField]
    private GameObject StageWindow;
    [SerializeField]
    private GameObject DeveloperWindow;
    [SerializeField]
    private GameObject TitleBackground;

    private int speed = 8;
    private bool bgmison;
    private bool soundison;
    private bool stageison;
   
    private void Awake()
    {
        bgmison = false;
        soundison = false;
        stageison = false;
    }
    void Start () {
        

    }
    public void Update()
    {
        if(stageison == true)
        {
            TitleWindow.transform.position = new Vector3(0, TitleWindow.transform.position.y + (speed * Time.deltaTime), 0);
            Debug.Log(TitleWindow.transform.position.y);
            if (TitleWindow.transform.position.y >= 10) 
            {
                stageison = false;
                Debug.Log(1);
             
            }
               
        
            
        }
    }

    private void MoveTitle()
    {
      
    }


    public void StartGame()
    {
        stageison = true;

      
        //StageWindow.SetActive(true);
        //Buttons.SetActive(false);
        //TitleBackground.SetActive(false);
    }
    public void CloseStart()
    {
     
        StageWindow.SetActive(false);
        Buttons.SetActive(true);
        TitleBackground.SetActive(true);
    }
    public void Option()
    {
        
        OptionWindow.SetActive(true);
        Buttons.SetActive(false);
    }
    public void CloseOption()
    {
        OptionWindow.SetActive(false);
        Buttons.SetActive(true);
    }
    public void Bgmbutton()
    {
        if (bgmison == false)
        {
            bgmison = true;
            PlayerPrefs.SetInt("Bgm", 1);
        }
        else
        {
            bgmison = false;
            PlayerPrefs.SetInt("Bgm", 0);
        }
    }
    public void Soundbutton()
    {
        if (soundison == false)
        {
            soundison = true;
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            soundison = false;
            PlayerPrefs.SetInt("Sound", 0);
        }
    }
    public void Developers()
    {
        DeveloperWindow.SetActive(true);
        OptionWindow.SetActive(false);
    } 
    public void DevelopersClose()
    {
        DeveloperWindow.SetActive(false);
        OptionWindow.SetActive(true);
    }
    public void StageButton(int num)
    {

    }


}
