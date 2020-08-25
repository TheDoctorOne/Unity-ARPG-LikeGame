using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StaffofSpheres : MonoBehaviour
{
    public GameObject sphere;
    public GameObject characterBody;
    public Transform sphereLoc;
    // Start is called before the first frame update
    void Start()
    {
        latestShoot = Time.time - shootCooldown;
        latestFistSpell = Time.time- fistSpellCd;
        latestSecondSpell = Time.time-secondSpellCd;

        characterBody = GameObject.FindGameObjectWithTag(characterBody.tag);
    }


    private float latestShoot;
    private float latestFistSpell;
    private float latestSecondSpell;
    private float shootCooldown = 0.3f;
    private float fistSpellCd = 2f;
    private float secondSpellCd = 4.5f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - latestShoot > shootCooldown) 
        {
            Instantiate(sphere, sphereLoc.position, characterBody.transform.rotation);
            latestShoot = Time.time;
        }
        if (Input.GetKey(KeyCode.Alpha1) && Time.time - latestFistSpell > fistSpellCd)
        {
            if (!isFirstSpellReady && !isFirstSpellPreparing)
            {
                Vector3 current = transform.position;
                new Thread(() => { firstSpell(current); }).Start();
                latestFistSpell = Time.time;
            }
        }
        if (Input.GetKey(KeyCode.Alpha2) && Time.time - latestSecondSpell > secondSpellCd)
        {
            if (!isSecondSpellReady && !isSecondSpellPreparing)
            {
                Vector3 current = transform.position;
                new Thread(() => { secondSpell(current); }).Start();
                latestSecondSpell = Time.time;
            }
        }

        if (isFirstSpellReady)
        {
            foreach (Vector3 v3 in v3ListFirst)
            {
                instantiateFirstSpell(v3);
            }
            v3ListFirst.Clear();
            isFirstSpellPreparing = false;
            isFirstSpellReady = false;
        }

        if (isSecondSpellReady)
        {
            foreach (Vector3 v3 in v3ListSecond)
            {
                instantiateSecondSpell(v3);
            }
            v3ListSecond.Clear();
            isSecondSpellPreparing = false;
            isSecondSpellReady = false;
        }
    }

    public int sphereCountFirst = 15;
    public float playerDist = 3f;
    public float heightStart = -1f;
    public float heightDist = 0.01f;
    private Vector3 v3First;
    private List<Vector3> v3ListFirst = new List<Vector3>();
    private bool isFirstSpellReady = false;
    private bool isFirstSpellPreparing = false;
    void firstSpell(Vector3 current)
    {
        isFirstSpellPreparing = true;

        for (int k = 0; k < 3; k++)
        {

            v3First = new Vector3(current.x, current.y + this.heightStart + (float)k, current.z);
            
            float inc = 1f / sphereCountFirst;
            for (float i=0; i< sphereCountFirst; i += inc)
            {

                float r = playerDist;
                float theta = i * 2 * Mathf.PI;

                v3First.x = current.x + r * Mathf.Cos(theta);
                v3First.z = current.z + r * Mathf.Sin(theta);
                v3ListFirst.Add(new Vector3(v3First.x, v3First.y, v3First.z));
            }

            
        }

        isFirstSpellReady = true;
    }

    public int sphereCountSecond = 30;
    private Vector3 v3Second;
    private List<Vector3> v3ListSecond = new List<Vector3>();
    private bool isSecondSpellReady = false;
    private bool isSecondSpellPreparing = false;
    private float secondSpellHeight = 1.5f;
    void secondSpell(Vector3 current)
    {
        isSecondSpellPreparing = true;

        for (int k = 0; k < 1; k++)
        {

            v3Second = new Vector3(current.x, current.y + this.secondSpellHeight + this.heightStart + (float)k, current.z);

            float inc = 2f / sphereCountSecond;
            for (float i = 1f; i < sphereCountSecond; i += inc)
            {

                float r = playerDist * Mathf.Sqrt(i);
                float theta = i * 2 * Mathf.PI;

                v3Second.x = current.x + r * Mathf.Cos(theta);
                v3Second.z = current.z + r * Mathf.Sin(theta);
                v3ListSecond.Add(new Vector3(v3Second.x, v3Second.y, v3Second.z));
            }


        }

        isSecondSpellReady = true;
    }
    private void instantiateFirstSpell(Vector3 v3)
    {
        GameObject go = Instantiate(sphere, v3, characterBody.transform.rotation);

        go.SendMessage("setMODE", 1);

    }
    private void instantiateSecondSpell(Vector3 v3)
    {
        GameObject go = Instantiate(sphere, v3, characterBody.transform.rotation);

        go.SendMessage("setMODE", 2);

    }

}

// Can be a future spell but has no future
/*for (float i = 0; i < loop; i += inc) //z si aynı x'i yüksek => x'i düşür, z'yi yükselt
            {
                v3.y = v3.y + heightDist;

                instantiateFirstSpell(v3);

                v3.x = v3.x - sphereDist;
                v3.z = v3.z + sphereDist;
            }

            for (float i = 0; i < loop; i += inc) //x si aynı z'si yüksek
            {
                v3.y = v3.y + heightDist;

                instantiateFirstSpell(v3);

                v3.x = v3.x - sphereDist;
                v3.z = v3.z - sphereDist;
            }


            for (float i = 0; i < loop; i += inc) //z si aynı x'i düşük
            {
                v3.y = v3.y + heightDist;

                instantiateFirstSpell(v3);

                v3.x = v3.x + sphereDist;
                v3.z = v3.z - sphereDist;
            }

            for (float i = 0; i < loop; i += inc) //x si aynı z'si düşük
            {
                v3.y = v3.y + heightDist;

                instantiateFirstSpell(v3);

                v3.x = v3.x + sphereDist;
                v3.z = v3.z + sphereDist;
            }*/