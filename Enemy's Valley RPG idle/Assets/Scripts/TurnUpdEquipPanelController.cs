using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnUpdEquipPanelController : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TurnOnUpdEquipPanelBttn()
    {
        gameObject.GetComponent<Animation>().Play("TurnOnUpdEquipPanel");
    }
    public void TurnOffUpdEquipPanelBttn()
    {
        gameObject.GetComponent<Animation>().Play("TurnOffUpdEquipPanel");
    }
}
