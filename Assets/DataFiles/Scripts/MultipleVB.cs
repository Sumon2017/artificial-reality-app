using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MultipleVB : MonoBehaviour
{
    public GameObject AGO, BGO, CGO;

    VirtualButtonBehaviour[] vrb;

    // Start is called before the first frame update
    void Start()
    {
        AGO.SetActive(false);
        BGO.SetActive(false);
        CGO.SetActive(false);

        vrb = GetComponentsInChildren<VirtualButtonBehaviour>();

        for( int i = 0; i < vrb.Length; i++)
        {
            vrb[i].RegisterOnButtonPressed(onButtonPressed);
            vrb[i].RegisterOnButtonReleased(onButtonReleased);
        }
    }

    
    public void onButtonPressed(VirtualButtonBehaviour vb)
    {
        if(vb.VirtualButtonName == "AVB")
        {
            AGO.SetActive(true);
            BGO.SetActive(false);
            CGO.SetActive(false);
        }
        else if(vb.VirtualButtonName == "BVB")
        {
            AGO.SetActive(false);
            BGO.SetActive(true);
            CGO.SetActive(false);
        }
        else if (vb.VirtualButtonName == "CVB")
        {
            AGO.SetActive(false);
            BGO.SetActive(false);
            CGO.SetActive(true);
        }
        else
        {
            throw new UnityException(vb.VirtualButtonName + "Button is not supported");
        }

    }

    public void onButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("button released");
    }

}
