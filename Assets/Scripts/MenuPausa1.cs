using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuPausa1 : MonoBehaviour
{
    public GameObject menuPausa1;
    public bool activar=true;
    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();
    }
    public void pausaBoton(InputAction.CallbackContext context){
        if(context.performed){
            DisplayWristUI();
        }
    }
    public void DisplayWristUI(){
        if(activar){
            menuPausa1.SetActive(false);
            activar=false;
            Time.timeScale=1;
        }else if(!activar){
            menuPausa1.SetActive(true);
            activar=true;
            Time.timeScale=0;
        }
    }

}
