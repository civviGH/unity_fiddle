using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int available_slots;

    private int selected;
    private GameObject[] slots;

    void Awake(){
      selected = -1;
      slots = new GameObject[available_slots];
      for (int i=0; i < available_slots; i++){
        slots[i] = GameObject.Find("Slot" + (i+1).ToString());
      }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      int selected_slot = select_slot();

      if (selected_slot == selected){
        selected = -1;
      }
      else if (selected_slot != -1){
        selected = selected_slot;
      }

      for (int i=0; i < available_slots; i++){
        if (i == selected){
          slots[i].GetComponent<Image>().color = Color.red;
        }
        else {
          slots[i].GetComponent<Image>().color = Color.white;
        }
      }

      if (selected == -1){
        if (Input.GetMouseButtonDown(0)){
          Debug.Log("Mouse down with hoe.");
        }
      }
      if (selected == 0){
        hoe_tool();
      }
    }

    private int select_slot(){
      for (int i=1; i <= available_slots; i++){
        if (Input.GetKeyDown(i.ToString())){
          return i-1;
        }
      }
      return -1;
    }

    private void hoe_tool(){
      if (Input.GetMouseButtonDown(0)){
        Debug.Log("Mouse down with hoe.");
      }
    }
}
