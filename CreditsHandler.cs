using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsHandler : MonoBehaviour
{
//this script exists so no errors occur due to the main menu and credits not existing in other levels.
    public GameObject credits;
    public GameObject Menu;
    // Start is called before the first frame update
    private void Start()
    {
        CloseCredits();              
    }

    public void OpenCredits(){
        credits.SetActive(true);
        Menu.SetActive(false);
    }

    public void CloseCredits(){
        credits.SetActive(false);
        Menu.SetActive(true);
    }

    // Update is called once per frame
    
}
