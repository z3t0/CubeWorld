using UnityEngine;
using System.Collections;

public class BlockStone : Block {
	
	public BlockStone()
		: base()
	{

	}



public override Tile TexturePosition(Direction direction)
    {
    	Tile tile = new Tile();

    	tile.x = 0;
    	tile.y = 0;	

        return tile;
    }
}
