using UnityEngine;
using System.Collections;

public class BlockAir : Block {

	public BlockAir()
		:base () {	

	}

	// Return MeshData unchanged
	public override MeshData Blockdata(Chunk chunk, int x, int y, int z, MeshData meshData)
	    {
	        return meshData;
	    }

	// Always return as not solid
	public override bool IsSolid(Direction direction)
	    {
	        return false; // Air is never solid
	    }
}
