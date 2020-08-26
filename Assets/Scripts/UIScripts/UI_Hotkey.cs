using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Hotkey : MonoBehaviour
{
    public GameObject inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryUI.activeInHierarchy)
            {
                inventoryUI.SetActive(false);
            }
            else
            {
                inventoryUI.SetActive(true);
            }
        }
    }
}
