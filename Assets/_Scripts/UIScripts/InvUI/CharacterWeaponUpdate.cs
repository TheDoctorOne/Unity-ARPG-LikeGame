using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeaponUpdate : MonoBehaviour
{
    //public GameObject mainCharacter;
    public GameObject orgCharacterUIRightHand;
    public GameObject orgCharacterUILeftHand;
    public GameObject UIWeaponRightHand;
    public GameObject UIWeaponLeftHand;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag(UIWeaponLeftHand.tag))
        {
            if (obj != UIWeaponLeftHand) 
            {
                orgCharacterUILeftHand = obj;
                break;
            }
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(UIWeaponRightHand.tag))
        {
            if (obj != UIWeaponRightHand)
            {
                orgCharacterUIRightHand = obj;
                break;
            }
        }
    }


    private void AssignWeapon(GameObject orgHand, GameObject uiHand)
    {
        if (orgHand.transform.childCount > 0)
        {
            GameObject inst;
            Transform transformOrj = orgHand.transform.GetChild(0);

            if (uiHand.transform.childCount < 1)
            {
                inst = Instantiate(transformOrj.gameObject, uiHand.transform);
                inst.layer = this.gameObject.layer;
                setLayers(inst);
            }
            else
            {
                Transform transformUI = uiHand.transform.GetChild(0);
                if (transformOrj.gameObject == transformUI.gameObject)
                {
                    Destroy(transformUI.gameObject);
                    inst = Instantiate(transformOrj.gameObject, uiHand.transform);
                    inst.layer = this.gameObject.layer;
                    setLayers(inst);
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * If there is no weapon defined, just add the new one
         * If there is a weapon on the hand, remove it and add new one
         *//*
        if (orgCharacterUIRightHand.transform.childCount > 0)
        {
            GameObject inst;
            Transform transformOrj = orgCharacterUIRightHand.transform.GetChild(0);

            if (UIWeaponRightHand.transform.childCount < 1)
            {
                inst = Instantiate(transformOrj.gameObject, UIWeaponRightHand.transform);
                inst.layer = this.gameObject.layer;
                setLayers(inst);
            }
            else
            {
                Transform transformUI = UIWeaponRightHand.transform.GetChild(0);
                if (transformOrj.gameObject == transformUI.gameObject)
                {
                    Destroy(transformUI.gameObject);
                    inst = Instantiate(transformOrj.gameObject, UIWeaponRightHand.transform);
                    inst.layer = this.gameObject.layer;
                    setLayers(inst);
                }
            }

        }*/
        AssignWeapon(orgCharacterUIRightHand, UIWeaponRightHand);
        AssignWeapon(orgCharacterUILeftHand, UIWeaponLeftHand);
    }


    private void setLayers(GameObject inst)
    {
        foreach(Transform transform in inst.transform.GetComponentsInChildren<Transform>())
        {
            transform.gameObject.layer = gameObject.layer;
        }
    }
}
