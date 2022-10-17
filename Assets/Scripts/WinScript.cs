using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField] private TMP_Text winText;
    [SerializeField] private TMP_Text rKeyText;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            winText.SetText("You Win!");
            rKeyText.SetText("Press 'R' to restart");
            Time.timeScale = 0;
        }
    }

    void Update() {
        if (Input.GetKey(KeyCode.R)) {
            Time.timeScale = 1;
            SingleAxisMovement.isRestart = true;
            Debug.Log("hello");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
