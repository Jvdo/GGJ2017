using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleOnFreq : MonoBehaviour
{

    Speach speach;
    GameObject child;

    public int threshold;
    public bool lowerThan;
    // Use this for initialization
    void Start()
    {
        speach = FindObjectOfType<Speach>();
        child = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if (speach.IsInputValid())
        {
            if (lowerThan)
            {
                if (speach.frequency > threshold && child.activeInHierarchy)
                    child.SetActive(false);

                if (speach.frequency < threshold && !child.activeInHierarchy)
                    child.SetActive(true);
            }
            else
            {
                if (speach.frequency < threshold && child.activeInHierarchy)
                    child.SetActive(false);

                if (speach.frequency > threshold && !child.activeInHierarchy)
                    child.SetActive(true);
            }
        }
    }
}
