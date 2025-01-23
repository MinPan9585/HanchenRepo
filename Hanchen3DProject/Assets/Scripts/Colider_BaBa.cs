using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider_BaBa : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bigBaBa;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Name:" +other.name);
        if (other.name == "DiMian")
        {
            Debug.Log("2222");
            transform.GetChild(0).gameObject.SetActive(false);
            bigBaBa.SetActive(true);
        }
        else
        {
            
            transform.parent.gameObject.SetActive(false);
        }
      
    }
}
