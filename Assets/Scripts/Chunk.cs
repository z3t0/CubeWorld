using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]


// Stores data of the Chunk's contents and create mesh
// which is sent off to the Mesh Renderer and Mesh Collider 

public class Chunk : MonoBehaviour {

	private Block[ , , ] blocks = new Block[chunkSize, chunkSize, chunkSize];    // 3 Dimensional Array of Blocks
	public static int chunkSize = 16;
	public bool update = true;

	MeshFilter filter;
	MeshCollider collider;

	public World world;
	public WorldPos pos;

	void Start() {
		filter = gameObject.GetComponent<MeshFilter>();
		collider = gameObject.GetComponent<MeshCollider>();
	}

	void Update()
	{
		if (update)
		{
			update = false;
			UpdateChunk();
		}
	}

	// Returns Block from Chunk
	public Block GetBlock(int x, int y, int z) {
		if(InRange(x) && InRange(y) && InRange(z))
			return blocks[x, y, z];
		return world.GetBlock(pos.x + x, pos.y +y, pos.z + z);
	}

	public static bool InRange(int index)
	{
		if(index < 0 || index >= chunkSize)
			return false;
		return true;
	}

	public void SetBlock(int x, int y, int z, Block block)
	{
		if (InRange(x) && InRange(y) && InRange(z))
		{
			blocks[x, y, z] = block;
		}
		else
		{
			world.SetBlock(pos.x + x, pos.y +y, pos.z + z, block);
		}
	}

	// Build Mesh by looping through all blocks
	void UpdateChunk() {
		MeshData meshData = new MeshData();

		for (int x = 0; x < chunkSize; x++) {
			for (int y = 0; y < chunkSize; y++) {
				for (int z = 0; z < chunkSize; z++) {
					meshData = blocks[x, y, z].Blockdata(this, x, y, z, meshData);
				}
			}
		}

		RenderMesh(meshData);
	}

	// Sends Calculated Mesh to MeshRender and MeshCollider
	void RenderMesh(MeshData meshData){
		filter.mesh.Clear();
		filter.mesh.vertices = meshData.vertices.ToArray();
		filter.mesh.triangles = meshData.triangles.ToArray();

		// Texturing
		filter.mesh.uv = meshData.uv.ToArray();
		filter.mesh.RecalculateNormals();

		// Collision
		collider.sharedMesh = null;
		Mesh mesh = new Mesh();
		mesh.vertices = meshData.colVertices.ToArray();
		mesh.triangles = meshData.colTriangles.ToArray();
		mesh.RecalculateNormals();

		collider.sharedMesh = mesh;

	}

}