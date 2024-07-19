using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameOver : MonoBehaviour
{

    public GameObject GameOverScreen;

    public void PlayerDie()
    {
        GameOverScreen.SetActive(true);
        FindObjectOfType<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;



    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerDie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

