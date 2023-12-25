using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteractive : MonoBehaviour
{
    [SerializeField] private float RayLength = 50f;

    [SerializeField] private Camera PlayerCamera;
    private Ray ray;
    
    
    void Update()
    {
        // Створюємо промінь
        ray = PlayerCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
      
        Debug.DrawRay(ray.origin, ray.direction * RayLength, Color.blue);

        if(Physics.Raycast(ray.origin, ray.direction, out var hit))
        {
            
            // Debug.Log("Hit something");

            Debug.Log ($"{hit.collider.gameObject.name}", hit.collider.gameObject);

            Debug.DrawRay(ray.origin, ray.direction * RayLength, Color.red);
        }
    }
}
