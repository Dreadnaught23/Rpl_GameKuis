using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kembali : MonoBehaviour
{
    public void OnBackMenuClicked()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Kembali ke manu");
    }

    public void ReplayClicked()
    {
        SceneManager.LoadScene("Kuis");
        Debug.Log("Main Lagi Guys!");
    }
}
