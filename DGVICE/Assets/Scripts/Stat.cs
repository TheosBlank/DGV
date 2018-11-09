using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class Stat
{
    
    public Bar bar;

    public GameObject imageDisp;
    Image m_Image;

    public float high;
    
    public float low;

    public float maxVal;
    
    public float currVal;

    public float CurrVal
    {
        get
        {
            return currVal;
        }

        set
        {
            currVal = Mathf.Clamp(value,0,MaxVal);
            bar.Value = currVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            maxVal = value;
            bar.MaxValue = maxVal;
        }
    }

    public void InitializeBar()
    {
        this.MaxVal = maxVal;
        this.CurrVal = currVal;
    }

    public void BarStatusCheck()
    {
        high = MaxVal * 0.7f;
        low = MaxVal * 0.3f;
        m_Image = imageDisp.GetComponent<Image>();

        if(CurrVal >= high)
        {
            m_Image.sprite = imageDisp.GetComponent<ImageManager>().sprites[0];
        }else if(CurrVal < high && CurrVal >= low)
        {
            m_Image.sprite = imageDisp.GetComponent<ImageManager>().sprites[1];
        }else
        {
            m_Image.sprite = imageDisp.GetComponent<ImageManager>().sprites[2];
        }
    }
}
