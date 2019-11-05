using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;

    private float attack_timer;

    private bool is_hitting = false;

    public float speed = 5f;



    void Awake(){
      rb = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
    }

    void Update(){
      handle_movement();
      handle_hitting2();
    }

    void handle_hitting(){
      if (is_hitting){
        attack_timer -= Time.deltaTime;
        if (attack_timer <= 0f){
          is_hitting = false;
        }
        return;
      }
      bool hit_button_pressed = Input.GetButtonDown("Fire1");
      if (!hit_button_pressed){
        return;
      }
      is_hitting = true;
      attack_timer = 0.25f;
      anim.SetBool("is_hitting", hit_button_pressed);
    }

    void handle_hitting2(){

      anim.SetBool("is_hitting", Input.GetButtonDown("Fire1"));
    }

    void handle_movement(){
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      if (movement.magnitude > 0.01){
        anim.SetBool("is_moving", true);
        anim.SetFloat("speed_multiplier", Mathf.Lerp(0.5f, 1f, movement.magnitude));
      } else {
        anim.SetFloat("speed_multiplier", 1f);
        anim.SetBool("is_moving", false);
      }
      anim.SetFloat("horizontal", movement.x);
      anim.SetFloat("vertical", movement.y);
    }

    void FixedUpdate(){
      rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
