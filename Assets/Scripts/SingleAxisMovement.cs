using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAxisMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private string Axis;
    [SerializeField] private int type;
    private Vector3 mousePosition;
    private Vector2 mousePositionY;
    private Vector2 mousePositionX;
    private bool mouseDown;
    private Vector2 verticalLock;
    private Vector2 horizontalLock;
    private Vector2 initialPosition;
    public static bool isRestart = false;
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update() {
        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition = new Vector2(mousePosition3D.x, mousePosition3D.y);
    
        mousePositionY = new Vector2(transform.position.x, mousePosition.y);
        mousePositionX = new Vector2(mousePosition.x, transform.position.y);

        switch (type) {
            case 2:
                verticalLock = new Vector2(transform.position.x, Mathf.Round(transform.position.y));
                horizontalLock = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
                break;
            case 3:
                switch (Axis) {
                    case "Vertical":
                        if (transform.position.y > Mathf.Round(transform.position.y)) {
                            verticalLock = new Vector2(transform.position.x, Mathf.Round(transform.position.y) + 0.5f);
                        } else if (transform.position.y < Mathf.Round(transform.position.y)) {
                            verticalLock = new Vector2(transform.position.x, Mathf.Round(transform.position.y) - 0.5f);
                        }
                    break;
                    case "Horizontal":
                        if (transform.position.x > Mathf.Round(transform.position.x)) {
                            horizontalLock = new Vector2(Mathf.Round(transform.position.x) + 0.5f, transform.position.y);
                        } else if (transform.position.x < Mathf.Round(transform.position.x)){
                            horizontalLock = new Vector2(Mathf.Round(transform.position.x) - 0.5f, transform.position.y);
                        }
                        break;
                }
                break;
        }
        

        if (Input.GetMouseButtonUp(0)) {
            switch (Axis) {
                case "Vertical":
                    transform.position = verticalLock;
                    break;
                case "Horizontal":
                    transform.position = horizontalLock;
                    break;
            }
        }

        if (isRestart) {
            transform.position = initialPosition;
            isRestart = false;
        }
    }

    void FixedUpdate() {
        
    }

    void OnMouseDrag() {
        switch (Axis) {
            case "Vertical":
                rb2d.MovePosition(mousePositionY);
                break;
            case "Horizontal":
                rb2d.MovePosition(mousePositionX);
                break;
        }
    }
}