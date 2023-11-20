using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
   public void StartGame()
   {
      
      if (PersistanceManager.Instance.GetInt("CurrentLevel") < 1)
      {
         SceneManager.LoadScene(PersistanceManager.Instance.GetInt("CurrentLevel") + 1);
      }
      else
      {
         SceneManager.LoadScene(PersistanceManager.Instance.GetInt("CurrentLevel"));
      }
   }
}
