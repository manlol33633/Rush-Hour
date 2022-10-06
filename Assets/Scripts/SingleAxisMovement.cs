using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAxisMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float xVelocity;
    [SerializeField] private float yVelocity;
    private Vector3 mousePosition;
    private string Axis;
    private RaycastHit2D hitOrMiss;
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePosition = new Vector2(mousePosition3D.x, mousePosition3D.y);

            hitOrMiss = Physics2D.Raycast(mousePosition, Vector2.zero);
        }
        if (hitOrMiss.collider != null) {
            if (hitOrMiss.collider.gameObject.tag == "Car") {
            Debug.Log("Works!");
            }
        }
    }

    void FixedUpdate() {

    }

    void OnMouseDrag() {
        
    }
}
