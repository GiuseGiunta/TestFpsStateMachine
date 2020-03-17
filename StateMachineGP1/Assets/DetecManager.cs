using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hitzone { figlio1, figlio2 }

public class DetecManager : MonoBehaviour
{

 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DetectedCollision(Hitzone zone)
    {
        Debug.Log(zone);
        switch (zone)
        {
            case Hitzone.figlio1:

                

                break;
            case Hitzone.figlio2:

               

                break;
            default:
                break;
        }

    }
}
