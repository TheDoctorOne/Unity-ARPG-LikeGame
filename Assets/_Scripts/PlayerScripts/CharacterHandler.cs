using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    public PlayerStats Stats { get; } = new PlayerStats();
    // Start is called before the first frame update
    void Start()
    {
        Stats.Health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
