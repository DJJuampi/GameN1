using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntToStr : MonoBehaviour
{
    public PlayerData playerData;
    public Text ValueText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ValueText.text = playerData.xp.ToString();
    }
}
