using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private int iLoad = 0;
    public void btn() {
        SceneManager.LoadScene(iLoad); 
    }
} 
