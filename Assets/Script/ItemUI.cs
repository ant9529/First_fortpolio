using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private Image image;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprite(Sprite _spr)
    {
        image = GetComponent<Image>();
        image.sprite = _spr;
        image.SetNativeSize();
    }


}
