using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerStatus : MonoBehaviour {

    public Text TimerText;
    float Timer, noHitTime = 0.3f;
    public int red = 0, blue = 0, green = 0;
    bool GameOver = false, nohit = false;
    public Sprite RedStar, BlueStar, GreenStar, YellowStar;

	void Start () {
        Timer = 100;
	}
	
	void Update () {
        Timer -= Time.deltaTime;
        TimerText.GetComponent<Text>().text = "" + (int)Timer;
        if (Timer <= 0)  //게임오버
        {
            SoundManager.instance.PlaySound();
            Time.timeScale = 1;
            PlayerPrefs.SetInt("istomain", 1);
            SceneManager.LoadScene("LoadingScene");
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        int r = Random.Range(1, 3);
        //-----------감정(점수)획득
        if (col.tag == "red")
        {
            red += r;
            GetComponent<SpriteRenderer>().sprite = RedStar;
            Destroy(col.gameObject);
        }
        if (col.tag == "blue")
        {
            blue += r;
            GetComponent<SpriteRenderer>().sprite = BlueStar;
            Destroy(col.gameObject);
        }
        if (col.tag == "green")
        {
            green += r;
            GetComponent<SpriteRenderer>().sprite = GreenStar;
            Destroy(col.gameObject);
        }
        if(col.tag == "cyan")
        {
            green += r;
            blue += r;
        }
        if(col.tag == "pink")
        {

        }
        if(col.tag == "yellow")
        {

        }

        //-----------장애물
        //------단색
        if (col.tag == "redD" && nohit == false)
        {
            if (red == 0)   //0일경우 시간감소
            {
                Timer -= 20;
            }
            else
            {
                red--;      //else red(분노) 1감소
            }
            nohit = true;
            Invoke("NoHitOff", noHitTime);
            Destroy(col.gameObject);
        }
        if (col.tag == "blueD" && nohit == false)
        {
            if (blue == 0)
            {
                Timer -= 20;
            }
            else
            {
                blue--;
            }
            nohit = true;
            Invoke("NoHitOff", noHitTime);
            Destroy(col.gameObject);
        }
        if (col.tag == "greenD" && nohit == false)
        {
            if (green == 0)
            {
                Timer -= 20;
            }
            else
            {
                green--;
            }
            nohit = true;
            Invoke("NoHitOff", noHitTime);
            Destroy(col.gameObject);
        }
        if (col.tag == "grayD" && nohit == false)
        {
            Timer -= 10;
            nohit = true;
            Invoke("NoHitOff", noHitTime);
            Destroy(col.gameObject);
        }

        //------혼합
        if (col.tag == "red_blue" && nohit == false)  //빨파 or 파빨
        {
            if (red == 0 && blue == 0)   //둘다 0일경우 시간-30
            {
                Timer -= 30;
            }
            else
            {
                if ((red == 0 && blue != 0))  //하나만 0 이면 
                {
                    blue--;
                    Timer -= 20;
                }
                else if (red != 0 && blue == 0)
                {
                    red--;
                    Timer -= 20;
                }
                else
                {
                    red--;
                    blue--;
                }
            }
            nohit = true;
            Invoke("NoHitOff", noHitTime);
            Destroy(col.gameObject);
        }
        if (col.tag == "red_green" && nohit == false)   //빨초 or 초빨
        {
            if (red == 0 && green == 0)
            {
                Timer -= 30;
            }
            else
            {
                if ((red == 0 && green != 0))  //하나만 0 이면 
                {
                    green--;
                    Timer -= 20;
                }
                else if (red != 0 && green == 0)
                {
                    red--;
                    Timer -= 20;
                }
                else
                {
                    red--;
                    green--;
                }
            }
            nohit = true;
            Invoke("NoHitOff", noHitTime);
            Destroy(col.gameObject);
        }
        if (col.tag == "blue_green" && nohit == false) //파초 or 초파
        {
            if (blue == 0 && green == 0)
            {
                Timer -= 30;
            }
            else
            {
                if ((blue == 0 && green != 0))  //하나만 0 이면 
                {
                    blue--;
                    Timer -= 20;
                }
                else if (blue != 0 && green == 0)
                {
                    blue--;
                    Timer -= 20;
                }
                else
                {
                    blue--;
                    green--;
                }
            }
            nohit = true;
            Invoke("NoHitOff", noHitTime);
            Destroy(col.gameObject);
        }
        Debug.Log("red : " + red + ", blue : " + blue + ", green : " + green + ", Time : " + Timer + " GameOver : " + GameOver);
    }

    void NoHitOff() //피격무적해제
    {
        nohit = false;
    }
}