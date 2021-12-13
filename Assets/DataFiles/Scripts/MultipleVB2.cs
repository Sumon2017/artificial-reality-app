using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MultipleVB2 : MonoBehaviour
{
    public GameObject SqGO, TriGO, CirGO;

    VirtualButtonBehaviour[] vrb;

    // Start is called before the first frame update
    void Start()
    {
        SqGO.SetActive(false);
        TriGO.SetActive(false);
        CirGO.SetActive(false);

        vrb = GetComponentsInChildren<VirtualButtonBehaviour>();

        for( int i = 0; i < vrb.Length; i++)
        {
            vrb[i].RegisterOnButtonPressed(onButtonPressed);
            vrb[i].RegisterOnButtonReleased(onButtonReleased);
        }
    }

    
    public void onButtonPressed(VirtualButtonBehaviour vb)
    {
        if(vb.VirtualButtonName == "ASQVB")
        {
            SqGO.SetActive(true);
            TriGO.SetActive(false);
            CirGO.SetActive(false);
        }
        else if(vb.VirtualButtonName == "BTRIVB")
        {
            SqGO.SetActive(false);
            TriGO.SetActive(true);
            CirGO.SetActive(false);
        }
        else if (vb.VirtualButtonName == "CCIRVB")
        {
            SqGO.SetActive(false);
            TriGO.SetActive(false);
            CirGO.SetActive(true);
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
