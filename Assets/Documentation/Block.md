# Block

## API

### Variables
- tileSize
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

-  Tile
 Struct for x and y postion

 TODO: Replace with Vector2

### Methods
-  TexturePostion
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

 The above example checks the Direction of the face and sets the
 texture accordingly. The Top and Bottom have unique textures, while
 all the sides have the same texture. This example is of a Grass 
 Block.
