using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IngameButtonManager : MonoBehaviour {

    [SerializeField]
    private PlayerStatus player;
    [SerializeField]
    private GameObject PauseWindow;
    [SerializeField]
    private GameObject PauseButton;
    [SerializeField]
    private GameObject BgmButton;
    [SerializeField]
    private GameObject SoundButton;
    [SerializeField]
    private Text redtext;
    [SerializeField]
    private Text greentext;
    [SerializeField]
    private Text bluetext;
    [SerializeField]
    private GameObject[] GameStage;
    [SerializeField]
    private Sprite[] ButtonImage;
    private int Bgm;
    private int Sound;
    private int stagenum;
    private bool bgmison;
    private bool soundison;
    // Use this for initialization
    void Start () {
        Bgm = PlayerPrefs.GetInt("Bgm", 0);
        Sound = PlayerPrefs.GetInt("Sound", 0);
        stagenum = PlayerPrefs.GetInt("StageNum", 0);
        GameStage[stagenum].SetActive(true);
        if (Bgm == 1)
        {
            bgmison = true;
            BgmButton.GetComponent<Image>().sprite = ButtonImage[1];
        }
        else
        {
            bgmison = false;
            BgmButton.GetComponent<Image>().sprite = ButtonImage[2];
        }
        if (Sound == 1)
        {
            soundison = true;
            SoundButton.GetComponent<Image>().sprite = ButtonImage[3];
        }
        else
        {
            soundison = false;
            SoundButton.GetComponent<Image>().sprite = ButtonImage[4];
        }
    }
	
	// Update is called once per frame
	void Update () {
		switch(stagenum)
        {
            case 1:
                redtext.GetComponent<Text>().text = "" +player.red +"/1";
                greentext.GetComponent<Text>().text = "" +player.green +"/0";
                bluetext.GetComponent<Text>().text = "" +player.blue +"/0";
                break;
            case 2:
                redtext.GetComponent<Text>().text = "" + player.red + "/1";
                greentext.GetComponent<Text>().text = "" + player.green + "/1";
                bluetext.GetComponent<Text>().text = "" + player.blue + "/0";
                break;
            case 3:
                redtext.GetComponent<Text>().text = "" + player.red + "/1";
                greentext.GetComponent<Text>().text = "" + player.green + "/1";
                bluetext.GetComponent<Text>().text = "" + player.blue + "/1";
                break;
            case 4:
                redtext.GetComponent<Text>().text = "" + player.red + "/1";
                greentext.GetComponent<Text>().text = "" + player.green + "/2";
                bluetext.GetComponent<Text>().text = "" + player.blue + "/1";
                break;
            case 5:
                redtext.GetComponent<Text>().text = "" + player.red + "/2";
                greentext.GetComponent<Text>().text = "" + player.green + "/2";
                bluetext.GetComponent<Text>().text = "" + player.blue + "/2";
                break;
            case 6:
                redtext.GetComponent<Text>().text = "" + player.red + "/3";
                greentext.GetComponent<Text>().text = "" + player.green + "/1";
                bluetext.GetComponent<Text>().text = "" + player.blue + "/2";
                break;
            case 7:
                redtext.GetComponent<Text>().text = "" + player.red + "/4";
                greentext.GetComponent<Text>().text = "" + player.green + "/1";
                bluetext.GetComponent<Text>().text = "" + player.blue + "/3";
                break;

        }

	}
    public void oPauseButton()
    {
        Time.timeScale = 0;
        
        PauseWindow.SetActive(true);
        PauseButton.SetActive(false);
    }
    public void ClosePauseButton()
    {
        Time.timeScale = 1;
        PauseWindow.SetActive(false);
        PauseButton.SetActive(true);
    }
    public void BgmButtons()
    {
        if (bgmison == false)
        {
            bgmison = true;
            PlayerPrefs.SetInt("Bgm", 1);
            BgmButton.GetComponent<Image>().sprite = ButtonImage[1];
        }
        else
        {
            bgmison = false;
            PlayerPrefs.SetInt("Bgm", 0);
            BgmButton.GetComponent<Image>().sprite = ButtonImage[2];
        }
    }
    public void SoundButtons()
    {
        if (soundison == false)
        {
            soundison = true;
            PlayerPrefs.SetInt("Sound", 1);
            SoundButton.GetComponent<Image>().sprite = ButtonImage[3];
        }
        else
        {
            soundison = false;
            PlayerPrefs.SetInt("Sound", 0);
            SoundButton.GetComponent<Image>().sprite = ButtonImage[4];
        }
    }
    public void BackButton()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("istomain", 1);
        SceneManager.LoadScene("LoadingScene");
    }
}
