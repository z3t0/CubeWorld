using UnityEngine;
using System.Collections;

public class Block
{

	const float tileSize = 0.25f; // 1 divided by rows

	public struct Tile
	{
		public int x;
		public int y;
	}


	public enum Direction
	{
		North,
		East,
		South,
		West,
		Up,
		Down
	};

	public virtual Tile TexturePosition(Direction direction)
	{
		Tile tile = new Tile();
		tile.x = 0;
		tile.y = 0;

		return tile;
	}

	public virtual Vector2[] FaceUVs(Direction direction)
	{
		Vector2[] UVs = new Vector2[4];
		Tile tilePos = TexturePosition(direction);

		UVs[0] = new Vector2(tileSize * tilePos.x + tileSize,
				tileSize * tilePos.y);
		UVs[1] = new Vector2(tileSize * tilePos.x + tileSize,
				tileSize * tilePos.y + tileSize);
		UVs[2] = new Vector2(tileSize * tilePos.x,
				tileSize * tilePos.y + tileSize);
		UVs[3] = new Vector2(tileSize * tilePos.x,
				tileSize * tilePos.y);

		return UVs;
	}

	public Block()
	{

	}


	public virtual MeshData Blockdata(Chunk chunk, int x, int y, int z, MeshData meshData)
	{ 
		meshData.useRenderDataForCol = true;    

		if (!chunk.GetBlock(x, y + 1, z).IsSolid(Direction.Down))
		{
			meshData = FaceDataUp(chunk, x, y, z, meshData);
		}

		if (!chunk.GetBlock(x, y - 1, z).IsSolid(Direction.Up))
		{
			meshData = FaceDataDown(chunk, x, y, z, meshData);
		}

		if (!chunk.GetBlock(x, y, z + 1).IsSolid(Direction.South))
		{
			meshData = FaceDataNorth(chunk, x, y, z, meshData);
		}

		if (!chunk.GetBlock(x, y, z - 1).IsSolid(Direction.North))
		{
			meshData = FaceDataSouth(chunk, x, y, z, meshData);
		}

		if (!chunk.GetBlock(x + 1, y, z).IsSolid(Direction.West))
		{
			meshData = FaceDataEast(chunk, x, y, z, meshData);
		}

		if (!chunk.GetBlock(x - 1, y, z).IsSolid(Direction.East))
		{
			meshData = FaceDataWest(chunk, x, y, z, meshData);
		}


		return meshData;
	}

	protected virtual MeshData FaceDataUp
		(Chunk chunk, int x, int y, int z, MeshData meshData)
		{
			meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
			meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
			meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
			meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));

			meshData.AddQuadTriangles();

			meshData.uv.AddRange(FaceUVs(Direction.Up));

			return meshData;
		}

	protected virtual MeshData FaceDataDown
		(Chunk chunk, int x, int y, int z, MeshData meshData)
		{
			meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
			meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
			meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
			meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));

			meshData.AddQuadTriangles();

			meshData.uv.AddRange(FaceUVs(Direction.Down));

			return meshData;
		}

	protected virtual MeshData FaceDataNorth
		(Chunk chunk, int x, int y, int z, MeshData meshData)
		{
			meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
			meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
			meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
			meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));

			meshData.AddQuadTriangles();

			meshData.uv.AddRange(FaceUVs(Direction.North));

			return meshData;
		}

	protected virtual MeshData FaceDataEast
		(Chunk chunk, int x, int y, int z, MeshData meshData)
		{
			meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
			meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
			meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
			meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));

			meshData.AddQuadTriangles();

			meshData.uv.AddRange(FaceUVs(Direction.East));

			return meshData;
		}

	protected virtual MeshData FaceDataSouth
		(Chunk chunk, int x, int y, int z, MeshData meshData)
		{
			meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
			meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
			meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
			meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));

			meshData.AddQuadTriangles();

			meshData.uv.AddRange(FaceUVs(Direction.South));

			return meshData;
		}

	protected virtual MeshData FaceDataWest
		(Chunk chunk, int x, int y, int z, MeshData meshData)
		{
			meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
			meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
			meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
			meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));

			meshData.AddQuadTriangles();

			meshData.uv.AddRange(FaceUVs(Direction.West));

			return meshData;
		}


	public virtual bool IsSolid(Direction direction)
	{
		switch (direction)
		{
			case Direction.North:
				return true;
			case Direction.East:
				return true;
			case Direction.South:
				return true;
			case Direction.West:
				return true;
			case Direction.Up:
				return true;
			case Direction.Down:
				return true;
		}

		return false;
	}
}
