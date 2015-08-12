# Mesh Data

## API

### Variables

#### vertices:
 
 List<Vector3>

 Keeps track of all the vertices which are used to form triangles in
 `AddQuadTriangles()`.

#### triangles:
	 
	List<int>

	Keeps track of all the triangles for the mesh filter. The triangles are used
	in pairs to create quads, which make up the faces of the blocks.

#### uv:

	List<Vector2>

	Keeps track of UV Coordinates for texturing.

#### colVertices:

 List<Vector3>

 Keeps track of all the vertices which are to form triangles and then for the 
 mesh collider. This is only used when `useRenderDataForCol` is true and the
 same data is being used to render the mesh collider as the mesh filter.


#### colTriangles:

 List<int>

 Keeps track of all the triangles for the `Mesh Collider`. The triangles are
 used to create quads for the faces of the blocks. This data is only used when
 `useRenderDataForCol` is true, meaning the same data is being used in the
 collider and filter - this works for blocks since they are just cubes and have
 no special collision mechanism.

#### useRenderDataForCol:

 bool

 If this is true, then the data for the mesh filter is also used for the mesh
 collider. Usually this will be set true only for Blocks which are solid on all
 faces and are regular cubes.


### Methods

####
