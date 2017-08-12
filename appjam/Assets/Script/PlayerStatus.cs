using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    
    float Timer, noHitTime = 0.7f;
    int red = 0, blue = 0, green = 0;
    bool GameOver = false, nohit = false;
    public Sprite RedStar, BlueStar, GreenStar, YellowStar;

	void Start () {
        Timer = 100;
	}
	
	void Update () {
        Timer -= Time.deltaTime;

        if(Timer <= 0)  //게임오버
        {
            GameOver = true;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //-----------감정(점수)획득
        if (col.tag == "red")
        {
            red++;
            GetComponent<SpriteRenderer>().sprite = RedStar;
            Destroy(col.gameObject);
        }
        if (col.tag == "blue")
        {
            blue++;
            GetComponent<SpriteRenderer>().sprite = BlueStar;
            Destroy(col.gameObject);
        }
        if (col.tag == "green")
        {
            green++;
            GetComponent<SpriteRenderer>().sprite = GreenStar;
            Destroy(col.gameObject);
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