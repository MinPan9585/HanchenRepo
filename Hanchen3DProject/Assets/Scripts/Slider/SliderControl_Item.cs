using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl_Item : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider sli;
    public float value_Slider = 0;

    public GameObject scene2Obj;
    public GameObject scene1Obj;
    public GameObject haiouObj;
    public GameObject Panel_Parent;
    void Start()
    {
        sli = GetComponent<Slider>();
    }
    private void OnEnable()
    {
       
        InvokeRepeating("SetValue",0,0.2f);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValue()
    {
       
        if (value_Slider >= 1)
        {
            scene2Obj.SetActive(true);
            scene1Obj.SetActive(false);
            haiouObj.SetActive(false);
            CancelInvoke();
            Panel_Parent.SetActive(false);
        }
     
        value_Slider += 0.02f;
        sli.value = value_Slider;

        //Debug.Log("value_Slider:"+ value_Slider);

    }
}
