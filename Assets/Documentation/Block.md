# Block

## API

### Variables

#### tileSize:

 Refers to the number of rows/columns of the tilesheet. The value is 
 calculated by dividing 1 by the number of rows/columns in the tile 
 tilesheets are supported.

 This value is used when calculating the Tile Position when
 texturing

Example:
```c#
const float tileSize = (float) 1 / 6
```
 For a square tilesheet which measures 6 faces by 6 faces. Faces
 refers to each texture, so a total of 36 different faces can fit
 on a tilesheet measuring 6 * 6.

#### Tile:

 Struct for x and y postion

 TODO: Replace with Vector2

#### Direction

 {North, East, South, West, Up, Down}

 The enum is used as a reference to the different faces of each block

### Methods
####  TexturePostion:

 (Direction direction)
 Virtual function that allows each Block to provide its own texture
 coordinates. With the direction provided, each Block is further 
 able to customize the texture for each face.

 By default the texture will point to (0, 0) on the TileSheet which
 should contain a Void Texture. (0, 0) refers to the bottom left.

Example #1:
```c#
public virtual Tile TexturePosition(Direction direction)
{
	Tile tile = new Tile();

	tile.x = 1;
	tile.y = 1;

	return tile;
}
```

 The above example gives the Block the same texture for each face,
 the texture being at (1, 1) on the TileSheet.

Example #2:

```c#
public override Tile TexturePosition(Direction direction)
{
	Tile tile = new Tile();

	switch(direction)
	{
		case Direction.up: // Texture (2, 0) for top face
			tile.x = 2;
			tile.y = 0;
			return tile;

		case Direction.down: // Texture (1, 0) for bottom face
			tile.x = 1;
			tile.y = 0;
			return tile;
	}

	// Other faces (Sides) are Texture (3, 0)
	tile.x = 3;
	tile.y = 0;

	return tile;
}
```

 The above example checks the `Direction` of the face and sets the
 texture accordingly. The Top and Bottom have unique textures, while
 all the sides have the same texture. This example is of a Grass 
 Block.

#### FaceUVs:

 (Direction direction)

 Creates the UV data for texturing based on the tile returned from
 `TexturePosition.` This method is virtual and only needs to be overrided when
 the texture of the block is different, usually this means that `Blockdata` has
 also been overrided

#### Blockdata:

 (Chunk chunk, int x, int y, int z, MeshData meshData)

 Checks the solidity each face we want to render and creates `MeshData` for each
 . The variable `MeshData.useRenderDataForCol` is set to true so that the same
 mesh data is used for the collider, this is useful for blocks since there are
 no special structures and so the mesh filter and mesh collider can use the same
 data.

#### FaceData[Up, Down, North, East, South, West]:

 (Chunk chunk, int x, int y, int z, MeshData meshData)

 The vertices of the [Direction] face are added to `meshData` and then arranged 
 into 2 triangles, which form a quad, in `meshData.AddquadTriangles()`. The 
 textures are added to `meshData` using `FaceUVs`.

#### IsSolid:

 (Direction direction)

 Determines solidity of `Block`, always returns true as all sides of a `Block`
 are solid. Although, the general idea is that depending on `direction` we can
 determine which faces of the block should be solid. For example, if we wanted 
 to create a special block where the bottom face was NOT solid, we could use the
 following override.

```c#

	public override bool IsSolid(Direction direction)
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
				return false;		// Bottom face is not solid
		}
```
