using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject playUI;
    [SerializeField] GameObject finishOne;
    [SerializeField] GameObject secondLevelPiles;
    [SerializeField] GameObject congratsPanel1;
    Transform ball;
    [SerializeField] bool soundButtonBool;
    [SerializeField] AudioSource gameMusic;
    [SerializeField] GameObject soundCancelBar;
    Vector3 cameraStartingPosition = new Vector3(0,27,-7.5f);
    [SerializeField] GameObject camera;
   void Awake()
   {
    BallBehaviour.OnNextLevel+=NextLevel;
    ball = GameObject.Find("Ball").transform;
    gameMusic = GetComponent<AudioSource>();
    soundButtonBool = true;
   }
   public void OnPause()
   {
     pauseMenu.SetActive(true);
     playUI.SetActive(false);
     
     Time.timeScale = 0;
   }
   public void OnResume()
   {
     pauseMenu.SetActive(false);
     Time.timeScale = 1;
     playUI.SetActive(true);
   }
   public void OnMainMenu()
   {
     SceneManager.LoadScene("MainMenu");
   }
   public void NextLevel()
   {
     playUI.SetActive(true);
     Time.timeScale = 1;
     congratsPanel1?.SetActive(false);
     if (congratsPanel1 == null)
     {
      Debug.LogError("CongratsPannel1 is not attached");
     }
     finishOne?.SetActive(false);
     secondLevelPiles?.SetActive(true);
     ball.position = new Vector3(0 ,18.5f,-1.1f);
     if (camera == null)
     {
      Debug.Log("camera is not assigned");
     }
     else
     camera.transform.position = cameraStartingPosition;

   }
   public void Quit()
   {
    Application.Quit();
   }
  
   public void PlayAgain()
   {
     SceneManager.LoadScene("MainGame");
     Time.timeScale = 1;
   }

   public void MusicSound()
   {
    if (soundButtonBool)
    {
      soundButtonBool = false;
      gameMusic.enabled = false;
      soundCancelBar.SetActive(true);
      
    }
    else if(!soundButtonBool)
    {
    soundButtonBool = true;
    gameMusic.enabled = true;
    soundCancelBar.SetActive(false);
    }
     Debug.Log("Sound button has been pressed");  
   }
   
}
