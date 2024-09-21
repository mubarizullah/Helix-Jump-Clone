using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject playnAbout;
    [SerializeField] GameObject aboutText;
   public void Play()
   {
    SceneManager.LoadScene("MainGame");
   }

   public void About()
   {
    playnAbout.SetActive(false);
    aboutText.SetActive(true);
   }
   public void AboutBack()
   {
    playnAbout.SetActive(true);
    aboutText.SetActive(false);
   }

   public void Quit()
   {
    Application.Quit();
   }
   


}
