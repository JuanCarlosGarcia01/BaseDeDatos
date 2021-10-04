using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManajer : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Obetener Score");
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
