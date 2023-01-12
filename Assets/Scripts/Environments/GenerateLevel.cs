using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 10;
    public bool creatingSection = false;
    public int secNum;
    public int seconds = 1;

    // Update is called once per frame
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }        
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, section.Length);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 10;
        yield return new WaitForSeconds(seconds);
        creatingSection = false;
    }
}
