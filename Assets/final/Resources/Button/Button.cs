using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Gameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void random()
    {
        SceneManager.LoadScene("random");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Shopping()
    {
        SceneManager.LoadScene("shopping");
    }

    public void breaking()
    {
        SceneManager.LoadScene("BreakScene");
    }

    public void quit()
    {
        Application.Quit();
    }
}
