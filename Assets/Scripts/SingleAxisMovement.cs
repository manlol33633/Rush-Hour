using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAxisMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float xVelocity;
    [SerializeField] private float yVelocity;
    [SerializeField] private Vector2 speed;
    private Vector3 mousePosition;
    private string Axis;
    private RaycastHit2D hitOrMiss;
    private Vector2 mousePositionY;
    private bool mouseDown;
    private Vector2 endPoint; 
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (hitOrMiss.collider != null) {
            if (hitOrMiss.collider.gameObject.tag == "Car" && Input.GetMouseButtonDown(0)) {
                mouseDown = true;
            } else if (Input.GetMouseButtonUp(0)) {
                mouseDown = false;
            }
        }
        
        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition = new Vector2(mousePosition3D.x, mousePosition3D.y);

        hitOrMiss = Physics2D.Raycast(mousePosition, Vector2.zero);

        mousePositionY = new Vector2(transform.position.x, mousePosition.y);

        endPoint = new Vector2(transform.position.x, mousePosition.y);
    }

    void FixedUpdate() {
        if (mouseDown) {
            
        }
    }

    void OnMouseDrag() {
        rb2d.MovePosition(rb2d.position + speed * Time.fixedDeltaTime);
    }
}
