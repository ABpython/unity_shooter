using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
  public Vector2 turn;
  public float sensitivity = 0.5f;

  public Vector3 deltaMove;
  public float horizontalMove;
  public float verticalMove;
  public float speed = 2;

  public GameObject player;
  private Animator PlayerAnimator;
   

  void Start() 
  {
    // Забороняємо вказівнику виходити за рамки гри
    Cursor.lockState = CursorLockMode.Locked;

    PlayerAnimator = player.GetComponent<Animator>();
  }
  void Update()
  {
        // Отримуємо координати миші
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        // Обмежуємо поворот камери по осі Y 
        turn.y = Mathf.Clamp(turn.y, -20, 20);
        
        // Застосовуємо поворот для камери
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        // Застосовуємо поворот тільки для гравця
        player.transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        // Застосовуємо рух для гравця
       horizontalMove = Input.GetAxis("Horizontal");
       verticalMove = Input.GetAxis("Vertical");
       deltaMove = new Vector3(horizontalMove, 0, verticalMove) * speed * Time.deltaTime;
       player.transform.Translate(deltaMove);

       PlayerController();
      
  }
  
  void PlayerController()
  {
    if(verticalMove > 0)
    {
      if(Input.GetKey(KeyCode.LeftShift))
      {
        PlayerAnimator.SetInteger("Move", 2);
        speed = 4;
      }
      else
      {
        PlayerAnimator.SetInteger("Move", 1);
        speed = 2;
      }
    }
      
    else if(verticalMove < 0)
    {
      PlayerAnimator.SetInteger("Move", -1);
      speed = 2;
    }

    else
    {
      PlayerAnimator.SetInteger("Move", 0);
      speed = 0;
    }
  }

}
