using UnityEngine;

public static class Utils
{
    public static Vector3Int get_farm_tile_from_mouse_position(Vector3 click_position){
      return new Vector3Int(
        (int) Mathf.Floor(click_position.x),
        (int) Mathf.Floor(click_position.y),
        1
      );
    }
}
