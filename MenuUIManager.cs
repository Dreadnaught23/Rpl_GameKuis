using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Menu");
    }

}
