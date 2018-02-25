using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetRandomizer : MonoBehaviour
{
    public GameObject[] planets;

    // Use this for initialization
    private void Awake()
    {
        Instantiate(planets[Random.Range(0, 9)], transform.position, Quaternion.identity);
    }
}
