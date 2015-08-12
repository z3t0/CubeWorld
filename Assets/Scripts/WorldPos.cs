using UnityEngine;
using System.Collections;

public struct WorldPos
{
	public int x, y, z;

	public WorldPos(int x, int y, int z) 
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

public override bool Equals(object obj)
    {
        if (!(obj is WorldPos))
        	return false;

        WorldPos pos = (WorldPos) obj;
        if (pos.x != x || pos.y != y || pos.z != z)
        {
        	return false;
        }
        
       	return true;
    }
}
