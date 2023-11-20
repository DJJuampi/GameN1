using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Slider mySlider;
    [SerializeField] private Toggle myToggle;
    [SerializeField] private TMP_InputField myInput;
    void Start()
    {
        mySlider.value = PersistanceManager.Instance.GetFloat("MusicVolume");
        myToggle.isOn = PersistanceManager.Instance.GetBool(PersistanceManager.KeyMusic);
        myInput.text = PersistanceManager.Instance.GetString("UserName");
    }

   private void OnDisable()
   {
    PersistanceManager.Instance.Save();
   }
}
