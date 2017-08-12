using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {
    [SerializeField]
    private GameObject soundmanager;
    [SerializeField]
    private GameObject auidosource;
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
    [SerializeField]
    private GameObject BgmButton;
    [SerializeField]
    private GameObject SoundButton;
    [SerializeField]
    private GameObject Logo;
    [SerializeField]
    private GameObject[] AlbumList;
    [SerializeField]
    private GameObject[] starList;
    [SerializeField]
    private Sprite[] Album;
    [SerializeField]
    private Sprite[] AlbumClear;
    [SerializeField]
    private Sprite[] ButtonImage;
    private int speed = 8;
    private int whereisnow;
    private int Bgm;
    private int Sound;
    private bool bgmison;
    private bool soundison;
    private bool stageison;
    private bool stageison2;
   // PlayerPrefs.SetInt("SceneClear1", 1);  그 스테이지 클리어 했을때

    private void Awake()
    {
      
        stageison = false;
        stageison2 = false;
    }
    void Start () {
       
        Bgm = PlayerPrefs.GetInt("Bgm",0);
        Sound = PlayerPrefs.GetInt("Sound",0);
        for (int i = 1; i<=7; i++)
        {
          
            if (PlayerPrefs.GetInt("SceneClear" + i) == 1)
            {
                starList[i].SetActive(true);
                AlbumList[i].GetComponent<Image>().sprite = AlbumClear[i];
            }
            else
                AlbumList[i].GetComponent<Image>().sprite = Album[i];
        }
        if (Bgm == 1)
        {
            bgmison = true;
            BgmButton.GetComponent<Image>().sprite = ButtonImage[1];
            auidosource.SetActive(false);
        }
        else
        {
            bgmison = false;
            BgmButton.GetComponent<Image>().sprite = ButtonImage[2];
            auidosource.SetActive(true);
        }
        if (Sound == 1)
        {
            soundison = true;
            SoundButton.GetComponent<Image>().sprite = ButtonImage[3];
            soundmanager.SetActive(false);
        }
        else
        {
            soundison = false;
            SoundButton.GetComponent<Image>().sprite = ButtonImage[4];
            soundmanager.SetActive(true);
        }



    }
    public void Update()
    {
      
        if (stageison == true)
        {
            TitleWindow.transform.position = new Vector3(0, TitleWindow.transform.position.y + (speed * Time.deltaTime), 0);
       
            if (TitleWindow.transform.position.y >= 10) 
            {
                stageison = false;
                TitleWindow.transform.position = new Vector3(0,10, 0);
                whereisnow = 1;

            }  
        }
        if (stageison2 == true)
        {
            TitleWindow.transform.position = new Vector3(0, TitleWindow.transform.position.y - (speed * Time.deltaTime), 0);

            if (TitleWindow.transform.position.y <= 0)
            {
                stageison2 = false;
                TitleWindow.transform.position = new Vector3(0, 0, 0);
                whereisnow = 0;
            }
        }
    }

    private void MoveTitle()
    {
      
    }


    public void StartGame()
    {
        SoundManager.instance.PlaySound();
        stageison = true;
    }
    public void CloseStart()
    {
        SoundManager.instance.PlaySound();
        stageison2 = true;
    }
    public void Option()
    {
        SoundManager.instance.PlaySound();
        Logo.SetActive(false);
        OptionWindow.SetActive(true);
        Buttons.SetActive(false);
    }
    public void CloseOption()
    {
        SoundManager.instance.PlaySound();
        Logo.SetActive(true);
        OptionWindow.SetActive(false);
        Buttons.SetActive(true);
    }
    public void Bgmbutton()
    {
        SoundManager.instance.PlaySound();
        if (bgmison == false)
        {
            bgmison = true;
            PlayerPrefs.SetInt("Bgm", 1);
            BgmButton.GetComponent<Image>().sprite = ButtonImage[1];
            auidosource.SetActive(false);
        }
        else
        {
            bgmison = false;
            PlayerPrefs.SetInt("Bgm", 0);
            BgmButton.GetComponent<Image>().sprite = ButtonImage[2];
            auidosource.SetActive(true);
        }
    }
    public void Soundbutton()
    {
        SoundManager.instance.PlaySound();
        if (soundison == false)
        {

            soundison = true;
            PlayerPrefs.SetInt("Sound", 1);
            SoundButton.GetComponent<Image>().sprite = ButtonImage[3];
            soundmanager.SetActive(false);
        }
        else
        {
            soundison = false;
            PlayerPrefs.SetInt("Sound", 0);
            SoundButton.GetComponent<Image>().sprite = ButtonImage[4];
            soundmanager.SetActive(true);
        }
    }
    public void Developers()
    {
        SoundManager.instance.PlaySound();
        DeveloperWindow.SetActive(true);
        OptionWindow.SetActive(false);
    } 
    public void DevelopersClose()
    {
        SoundManager.instance.PlaySound();
        DeveloperWindow.SetActive(false);
        OptionWindow.SetActive(true);
    }
    public void StageButton(int num)
    {
        SoundManager.instance.PlaySound();
        PlayerPrefs.SetInt("istomain", 0);
        PlayerPrefs.SetInt("StageNum", num);
        SceneManager.LoadScene("LoadingScene");
    }


}
