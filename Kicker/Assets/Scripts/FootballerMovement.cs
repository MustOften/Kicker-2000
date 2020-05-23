using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootballerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public int FootballersCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Movement(KeyCode.W);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            Movement(KeyCode.S);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion rot = Quaternion.Euler(rotationSpeed * Time.deltaTime, 0, 0);
            transform.localRotation *= rot;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion rot = Quaternion.Euler(-rotationSpeed * Time.deltaTime, 0, 0);
            transform.localRotation *= rot;
        }
    }

    public void Movement(KeyCode key)
    {
        switch (FootballersCount)
        {
            case 1:
                if (key == KeyCode.W)
                    if (transform.position.x > -0.24)
                        transform.position -= transform.right * speed * Time.deltaTime;
                if (key == KeyCode.S)
                    if (transform.position.x < 0.24)
                        transform.position += transform.right * speed * Time.deltaTime;
                break;
            case 2: 
                if (key == KeyCode.W)               
                    if(transform.position.x > -0.16)
                        transform.position -= transform.right * speed * Time.deltaTime;
                if (key == KeyCode.S)
                    if (transform.position.x < 0.16)
                        transform.position += transform.right * speed * Time.deltaTime;
                break;
            case 3:
                if (key == KeyCode.W)
                    if (transform.position.x > -0.12)
                        transform.position -= transform.right * speed * Time.deltaTime;
                if (key == KeyCode.S)
                    if (transform.position.x < 0.12)
                        transform.position += transform.right * speed * Time.deltaTime; break;
            case 5:
                if (key == KeyCode.W)
                    if (transform.position.x > -0.08)
                        transform.position -= transform.right * speed * Time.deltaTime;
                if (key == KeyCode.S)
                    if (transform.position.x < 0.08)
                        transform.position += transform.right * speed * Time.deltaTime; 
                break;
        }
    }
}