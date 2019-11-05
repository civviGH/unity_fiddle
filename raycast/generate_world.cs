using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Generate_world : MonoBehaviour
{

  public int x_size, y_size;
  public Tile default_tile;

  private Tilemap farm_map;

  private void Awake() {
    if (x_size < 0) {
      x_size = 10;
    }
    if (y_size < 0) {
      y_size = 10;
    }
    generate();
  }

  private void generate(){
    farm_map = GetComponent<Tilemap>();
    Debug.Log(farm_map.cellBounds);

    // farm_map.SetTile(new Vector3Int (0, 0, 0), default_tile);

    BoundsInt bbox = new BoundsInt(0, 0, 1, x_size, y_size, 1);
    TileBase[] tile_array = new TileBase[bbox.size.x * bbox.size.y * bbox.size.z];
    for (int i = 0; i < tile_array.Length; i++){
      tile_array[i] = default_tile;
    }
    Debug.Log("setting tiles block");
    farm_map.SetTilesBlock(bbox, tile_array);
    Debug.Log("done");
  }

  void Update(){
    if (Input.GetMouseButtonDown(0)){
      Vector3 click_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector3Int tile_position = Utils.get_farm_tile_from_mouse_position(click_position);
      Tile clicked_tile = farm_map.GetTile(tile_position) as Tile;
      if (clicked_tile != null){
        farm_map.SetTileFlags(tile_position, TileFlags.None);
        if (Player.current_selection_position == tile_position){
          farm_map.SetColor(tile_position, Color.white);
          Player.current_selection_position = new Vector3Int(-1, -1, -1);
          return;
        }
        if (Player.current_selection_position != new Vector3Int(-1, -1, -1)){
          farm_map.SetColor(Player.current_selection_position, Color.white);
        }
        Player.current_selection_position = tile_position;
        farm_map.SetColor(tile_position, Color.red);
      }
    }
  }

}
