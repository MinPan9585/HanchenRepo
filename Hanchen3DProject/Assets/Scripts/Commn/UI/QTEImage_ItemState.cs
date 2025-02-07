using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEImage_ItemState : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> thisSpreite;
    public Image thisImage;
    void Start()
    {
        thisImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSperite_1()
    {
        thisImage.sprite = thisSpreite[0];
        Invoke("SetSperite_2", 0.15f);
    }

    public void SetSperite_2()
    {
        thisImage.sprite = thisSpreite[1];
        Invoke("SetSperite_1", 0.15f);
    }

    public void StopInvoke()
    {
        CancelInvoke();
        thisImage.sprite = thisSpreite[0];
    }
}
