using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detective : MonoBehaviour
{
    DetecManager manager;
    public Hitzone myZone;

    // Start is called before the first frame update
    void Start()
    {
        manager = transform.parent.GetComponentInParent<DetecManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collisione");
        manager.DetectedCollision(myZone);
    }
}
