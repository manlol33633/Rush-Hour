using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAxisMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float xVelocity;
    [SerializeField] private float yVelocity;
    [SerializeField] private Vector2 speed;
    [SerializeField] private int[] rangeMap = new int[2];
    [SerializeField] private int carType;
    private Vector3 mousePosition;
    private string Axis;
    private RaycastHit2D mouseCast;
    private RaycastHit2D[] vehicleCast = new RaycastHit2D[2];
    private Vector2[] vehicleCastPoint = new Vector2[2];
    private Vector2 mousePositionY;
    private bool mouseDown;
    private Vector2 endPoint;
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition = new Vector2(mousePosition3D.x, mousePosition3D.y);
        vehicleCastPoint[0] = new Vector2(transform.position.x, transform.position.y - 2);
        vehicleCastPoint[1] = new Vector2(transform.position.x, transform.position.y + 2);
        
        mouseCast = Physics2D.Raycast(mousePosition, Vector2.zero);
        vehicleCast[0] = Physics2D.Raycast(vehicleCastPoint[0], Vector2.down);
        vehicleCast[1] = Physics2D.Raycast(vehicleCastPoint[1], Vector2.up);
    
        mousePositionY = new Vector2(transform.position.x, mousePosition.y);

        endPoint = new Vector2(transform.position.x, mousePosition.y);

        
    }

    void FixedUpdate() {
        
    }

    void OnMouseDrag() {
        if (mousePositionY.y >= rangeMap[0] && mousePositionY.y <= rangeMap[1]) {
            rb2d.MovePosition(mousePositionY);
        }
        if (mousePositionY.y <= rangeMap[0]) {
            transform.position = new Vector2(transform.position.x, rangeMap[0]);
        } else if (mousePositionY.y >= rangeMap[1]) {
            transform.position = new Vector2(transform.position.x, rangeMap[1]);
        }
        if (vehicleCast[0].collider != null) {
            if (vehicleCast[0].collider.gameObject.tag == "Car") {
                if (vehicleCast[0].distance <= 0.1) {

                }
            }
        } 
    }

    void lockOn() {
        
    }
}