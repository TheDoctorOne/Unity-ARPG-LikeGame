using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffofSpheres : MonoBehaviour
{
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        latestShoot = Time.time;
        latestFistSpell = Time.time;
    }


    private float latestShoot;
    private float latestFistSpell;
    private float shootCooldown = 0.3f;
    private float fistSpellCd = 2f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - latestShoot > shootCooldown) 
        {
            Instantiate(sphere, this.transform);
            latestShoot = Time.time;
        }
        if (Input.GetKey(KeyCode.Alpha1) && Time.time - latestFistSpell > fistSpellCd)
        {
            firstSpell();
            latestFistSpell = Time.time;
        }
    }

    public int sphereCount = 144;
    public float playerDist = 3f;
    public float heightStart = -1f;
    public float heightDist = 0.01f;
    private Vector3 v3;
    void firstSpell()
    {

        for (int k = 0; k < 5; k++)
        {
            v3 = new Vector3(transform.position.x, transform.position.y+this.heightStart+(float)k, transform.position.z);
            v3.x = v3.x + playerDist;
            float heightStart = this.heightStart;
            int loop = sphereCount / 4;
            float sphereDist = playerDist / loop;
        /*
         * z si aynı x'i yüksek
         * x si aynı z'si yüksek
         * z si aynı x'i düşük
         * x si aynı z'si düşük
         */
            for (int i = 0; i < loop; i++) //z si aynı x'i yüksek => x'i düşür, z'yi yükselt
            {
                v3.y = v3.y + heightDist;

                instantiateFirstSpell(v3);

                v3.x = v3.x - sphereDist;
                v3.z = v3.z + sphereDist;
            }

            for (int i = 0; i < loop; i++) //x si aynı z'si yüksek
            {
                v3.y = v3.y + heightDist;

                instantiateFirstSpell(v3);

                v3.x = v3.x - sphereDist;
                v3.z = v3.z - sphereDist;
            }


            for (int i = 0; i < loop; i++) //z si aynı x'i düşük
            {
                v3.y = v3.y + heightDist;

                instantiateFirstSpell(v3);

                v3.x = v3.x + sphereDist;
                v3.z = v3.z - sphereDist;
            }

            for (int i = 0; i < loop; i++) //x si aynı z'si düşük
            {
                v3.y = v3.y + heightDist;

                instantiateFirstSpell(v3);

                v3.x = v3.x + sphereDist;
                v3.z = v3.z + sphereDist;
            }
        }
    }

    private void instantiateFirstSpell(Vector3 v3)
    {
        GameObject go = Instantiate(sphere, v3, transform.rotation);

        go.SendMessage("setMODE", 1);

    }

}
