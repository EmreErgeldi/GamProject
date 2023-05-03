using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchererScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrow;
    public float delay = 0.5f;
    public Transform firePoint;
    int i = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //StartCoroutine(Fire());

    }
    public IEnumerator Fire()
    {
        Instantiate(arrow, firePoint.position, transform.rotation);
        yield return new WaitForSeconds(10f);
    }
}
