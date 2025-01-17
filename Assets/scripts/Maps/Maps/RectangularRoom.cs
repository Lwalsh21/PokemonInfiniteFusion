using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangularRoom : MonoBehaviour
{	
   public int x;
   
   public int y;
   
   public int width;
   
   public into height;
   
   public RectangularRoom(int x, int y, int width, int height)
   {
   		this.x = x;
		this.y = y;
		this.width = width;
		this.height = height:
   }
   
   public Vector2Int Center() => new Vecotr2Int(x + width / 2, y + height / 2);
   
   public Bounds GetBounds() => new Bounds(new Vector3(x, y, 0), new Vector3(width, height, 0));
   
   public BoundsInt GetBoundsInt() => new BoundsInt(new Vector3Int(x, y, 0), new Vector3Int(width, height, 0));
   
   public bool OverLaps(List<RectangularRoom> otherRooms)
   {
   		foreach (RectangularRoom otherRoom in otherRooms)
		{
			if (GetBounds().Intersects(otherRoom.GetBounds()))
			{
				return true;
			}
		}
		return false;
   }
}
