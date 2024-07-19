using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clip;
    public GameObject OpenDoor,CloseDoor;
    public bool DoorIsOpen;
    public void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled=false;
        if(DoorIsOpen)
        {
            source.PlayOneShot(clip);
            OpenDoor.SetActive(false);
            CloseDoor.SetActive(true);
     }
        else
        {
                        // source. .....
            source.PlayOneShot(clip);
            OpenDoor.SetActive(true);
            CloseDoor.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
