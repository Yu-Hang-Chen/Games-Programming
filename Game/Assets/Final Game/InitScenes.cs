using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScenes : MonoBehaviour
{
    [Header("tag Name")]
    public string targetTag = "Bed";        
    public float minY = -45f;                  
    public float maxY = 172f;                   

    // Start is called before the first frame update
    void Start()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objects)
        {
            float randomY = Random.Range(minY, maxY);

           
            Vector3 rot = obj.transform.eulerAngles;
            obj.transform.rotation = Quaternion.Euler(rot.x, randomY, rot.z);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
