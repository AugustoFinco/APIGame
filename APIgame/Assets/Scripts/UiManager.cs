using UnityEngine;

public class UiManager : MonoBehaviour
{

    public GameObject UI;
    public TesteAPI api;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && UI)
        {
            UI.SetActive(true);
            api.SavePause();
        }

        if (Input.GetKeyUp(KeyCode.Escape) && UI == true)
        {
            UI.SetActive(false);
        }
    }
}
