using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage5 : MonoBehaviour {

    public GameObject Red, Blue, Green, redD, blueD, greenD, pinkD, cyanD, yellowD, grayD, Player;

	void Start () {
        InvokeRepeating("Spawn", 1, 3);
	}
	
	void Update () {
		if(Player.GetComponent<PlayerStatus>().red == 2 && Player.GetComponent<PlayerStatus>().blue == 2 && Player.GetComponent<PlayerStatus>().green == 2)
        {
            PlayerPrefs.SetInt("SceneClear1", 1);
            Time.timeScale = 1;
            PlayerPrefs.SetInt("istomain", 1);
            SceneManager.LoadScene("LoadingScene");
        }
	}

    void Spawn()
    {
        int r = Random.Range(0, 3);
        int r2;
        float PositionX = Random.Range(-2.2f, 2.2f);
        float PositionY = Random.Range(-4.0f, 4.5f);
        float RotationZ;
        switch (r)
        {
            case 0:
                Instantiate(Red, new Vector3(PositionX, PositionY, -1), transform.rotation);
                break;

            case 1:
                Instantiate(Blue, new Vector3(PositionX, PositionY, -1), transform.rotation);
                break;

            case 2:
                Instantiate(Green, new Vector3(PositionX, PositionY, -1), transform.rotation);
                break;
        }
        
        r = Random.Range(0, 3);
        r2 = Random.Range(0, 6);
        PositionX = Random.Range(-1.0f, 1.0f);
        PositionY = Random.Range(-2.0f, 2.0f);
        
        switch (r)
        {
            case 0:
                RotationZ = Random.Range(-45, 45);
                switch(r2)
                {
                    case 0:
                        Instantiate(redD, new Vector3(-3.3f, PositionY, -1), Quaternion.Euler(0, 0, RotationZ));
                        break;
                    case 1:
                        Instantiate(blueD, new Vector3(-3.3f, PositionY, -1), Quaternion.Euler(0, 0, RotationZ));
                        break;
                    case 2:
                        Instantiate(greenD, new Vector3(-3.3f, PositionY, -1), Quaternion.Euler(0, 0, RotationZ));
                        break;
                    case 3:
                        Instantiate(yellowD, new Vector3(-3.3f, PositionY, -1), Quaternion.Euler(0, 0, RotationZ));
                        break;
                    case 4:
                        Instantiate(pinkD, new Vector3(-3.3f, PositionY, -1), Quaternion.Euler(0, 0, RotationZ));
                        break;
                    case 5:
                        Instantiate(cyanD, new Vector3(-3.3f, PositionY, -1), Quaternion.Euler(0, 0, RotationZ));
                        break;
                }
                break;

            case 1:
                RotationZ = Random.Range(-120, -60);
                Instantiate(blueD, new Vector3(PositionX, 5.4f, -1), Quaternion.Euler(0, 0, RotationZ));
                break;

            case 2:
                RotationZ = Random.Range(130, 220);
                Instantiate(greenD, new Vector3(3.3f, PositionY, -1), Quaternion.Euler(0, 0, RotationZ));
                break;

            case 3:
                RotationZ = Random.Range(60, 120);
                Instantiate(greenD, new Vector3(PositionX, -5.4f, -1), Quaternion.Euler(0, 0, RotationZ));
                break;
        }
        


    }
}
