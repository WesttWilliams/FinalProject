using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject WinScreen;

    public int pointsToWin = 5;

    public int points = 0;
    public TextMeshProUGUI papersText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(points >= pointsToWin)
        {
            WinScreen.SetActive(true);
        }
        papersText.text = points.ToString();

        
    }
}
