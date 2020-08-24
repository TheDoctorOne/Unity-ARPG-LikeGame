using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class spinSpell : MonoBehaviour
{
    public GameObject origin;
    public GameObject prefab;
    public GameObject characterBody;
    private GameObject[] generatedPrefabs;
    private bool isSpellDeactivated = false;
    // Start is called before the first frame update
    void Start()
    {
        generatedPrefabs = new GameObject[4];

        characterBody = GameObject.FindGameObjectWithTag(characterBody.tag);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)) //Right Mouse Button
        {
            origin.SetActive(false);
            if (isSpellDeactivated)
            {
                generatedPrefabs[0] = Instantiate(prefab, characterBody.transform);
                isSpellDeactivated = false;
            }
        }
        else
        {
            if (!isSpellDeactivated)
            {
                Destroy(generatedPrefabs[0]);
                origin.SetActive(true);
                isSpellDeactivated = true;
            }
        }
    }
}
