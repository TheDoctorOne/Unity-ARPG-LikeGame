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
        /*
         * If there is no weapon defined, just add the new one
         * If there is a weapon on the hand, remove it and add new one
         */
        if(orgCharacterUIRightHand.transform.childCount > 0)
        {
            GameObject inst = null;
            Transform transformOrj = orgCharacterUIRightHand.transform.GetChild(0);
            if (UIWeaponRightHand.transform.childCount < 1)
            {
                inst = Instantiate(transformOrj.gameObject, UIWeaponRightHand.transform);
                inst.layer = this.gameObject.layer;
            }
            else
            {
                Transform transformUI = UIWeaponRightHand.transform.GetChild(0);
                if (transformOrj.name != transformUI.name)
                {
                    Destroy(transformUI.gameObject);
                    inst = Instantiate(transformOrj.gameObject, UIWeaponRightHand.transform);
                    inst.layer = this.gameObject.layer;
                    
                }
            }
            foreach (Transform trans in inst.GetComponentsInChildren<Transform>(true))
            {
                trans.gameObject.layer = this.gameObject.layer;
            }
        }

        if (orgCharacterUILeftHand.transform.childCount > 0)
        {
            Instantiate(orgCharacterUILeftHand.transform.GetChild(0), UIWeaponLeftHand.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
