using DozyGrove.Models;
using DozyGrove.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DozyGrove.Locations
{
    public class Location
    {
        public string locationName { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int[] startingPlayerIdx { get; set; }
        public int[] playerIdx { get; set; }
        public List<BarrierModel> barriers { get; set; }
        public List<DecorationModel> decorations { get; set; }
        public List<SoilModel> soils { get; set; }
        public Tile[,] tiles { get; set; }
        protected int selectionDistance = 1;
        public class BarrierModel : JSONSpriteModel { }
        public class DecorationModel : JSONSpriteModel { }
        public class SoilModel : JSONSpriteModel { }

        public class JSONSpriteModel
        {
            public string type { get; set; }
            public List<int[]> positions { get; set; }
        }

        // Barrier dictionary
        protected Dictionary<string, Sprite> barrierTileAssignments = new Dictionary<string, Sprite>()
        {
            { "dark_green_tree_1", new Barrier(Game1.textures["barriers"], new Rectangle(0 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "dark_green_tree_2", new Barrier(Game1.textures["barriers"], new Rectangle(1 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "dark_green_tree_3", new Barrier(Game1.textures["barriers"], new Rectangle(2 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "dark_green_tree_4", new Barrier(Game1.textures["barriers"], new Rectangle(3 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "light_green_tree_1", new Barrier(Game1.textures["barriers"], new Rectangle(0 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "light_green_tree_2", new Barrier(Game1.textures["barriers"], new Rectangle(1 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "light_green_tree_3", new Barrier(Game1.textures["barriers"], new Rectangle(2 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "light_green_tree_4", new Barrier(Game1.textures["barriers"], new Rectangle(3 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "yellow_tree_1", new Barrier(Game1.textures["barriers"], new Rectangle(0 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "yellow_tree_2", new Barrier(Game1.textures["barriers"], new Rectangle(1 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "yellow_tree_3", new Barrier(Game1.textures["barriers"], new Rectangle(2 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "yellow_tree_4", new Barrier(Game1.textures["barriers"], new Rectangle(3 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "red_tree_1", new Barrier(Game1.textures["barriers"], new Rectangle(0 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "red_tree_2", new Barrier(Game1.textures["barriers"], new Rectangle(1 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "red_tree_3", new Barrier(Game1.textures["barriers"], new Rectangle(2 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "red_tree_4", new Barrier(Game1.textures["barriers"], new Rectangle(3 * Tile.tileSize, 3 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_tree_1", new Barrier(Game1.textures["barriers"], new Rectangle(0 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_tree_2", new Barrier(Game1.textures["barriers"], new Rectangle(1 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_tree_3", new Barrier(Game1.textures["barriers"], new Rectangle(2 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_tree_4", new Barrier(Game1.textures["barriers"], new Rectangle(3 * Tile.tileSize, 4 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "rock_1", new Barrier(Game1.textures["barriers"], new Rectangle(0 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "rock_2", new Barrier(Game1.textures["barriers"], new Rectangle(1 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_rock_1", new Barrier(Game1.textures["barriers"], new Rectangle(2 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "snowy_rock_2", new Barrier(Game1.textures["barriers"], new Rectangle(3 * Tile.tileSize, 5 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "fallen_log", new Barrier(Game1.textures["barriers"], new Rectangle(4 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "tree_stump_1", new Barrier(Game1.textures["barriers"], new Rectangle(4 * Tile.tileSize, 1 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "tree_stump_2", new Barrier(Game1.textures["barriers"], new Rectangle(4 * Tile.tileSize, 2 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) }, 
        };
        // Decoration dictionary
        protected Dictionary<string, Sprite> decorationTileAssignments = new Dictionary<string, Sprite>()
        {
            { "patch", new Decoration(Game1.textures["decorations"], new Rectangle(0 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "grass_1", new Decoration(Game1.textures["decorations"], new Rectangle(1 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
            { "grass_2", new Decoration(Game1.textures["decorations"], new Rectangle(2 * Tile.tileSize, 0 * Tile.tileSize, Tile.tileSize, Tile.tileSize)) },
        };

        public void FormGrid()
        {
            tiles = new Tile[height, width];
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    tiles[j, i] = new Tile(new Vector2(i * Tile.tileSize, j * Tile.tileSize));
                }
            }
        }

        public virtual void AddSprites()
        {
            foreach (var barrier in barriers) // Add barriers
                foreach (var position in barrier.positions)
                    tiles[position[0], position[1]].sprite = barrierTileAssignments[barrier.type];
            foreach (var decoration in decorations) // Add decorations
                foreach (var position in decoration.positions)
                    tiles[position[0], position[1]].sprite = decorationTileAssignments[decoration.type];
            foreach (var soil in soils) // Add soils
                foreach (var position in soil.positions)
                {
                    tiles[position[0], position[1]].sprite = new Soil() { currentlyInteractive = true };
                }
            tiles[startingPlayerIdx[0], startingPlayerIdx[1]].entity = new Player();
            playerIdx = startingPlayerIdx;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var tile in tiles)
                tile.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in tiles)
                tile.DrawBottomLayer(spriteBatch);
            foreach (var tile in tiles)
                tile.DrawMiddleLayer(spriteBatch);
            foreach (var tile in tiles)
                tile.DrawTopLayer(spriteBatch);
        }

        public bool MovePlayer(int vertical, int horizontal)
        {
            bool moved = false;
            bool attemptVerticalAgain = false;
            Vector2 movementDirection = Vector2.Zero;
            int newPlayerRow = playerIdx[0] + vertical;
            int newPlayerCol = playerIdx[1] + horizontal;
            // Vertical
            // Checking if the new player vertical position is not out of bounds
            if ((vertical != 0) && (newPlayerRow >= 0) && (newPlayerRow < height))
            {
                if (!(tiles[newPlayerRow, playerIdx[1]].sprite is Barrier))
                {
                    moved = true;
                    movementDirection.Y += vertical;
                    tiles[newPlayerRow, playerIdx[1]].entity = tiles[playerIdx[0], playerIdx[1]].entity;
                    tiles[playerIdx[0], playerIdx[1]].entity = null;
                    playerIdx[0] = newPlayerRow;
                }
                else attemptVerticalAgain = true;
            }

            // Horizontal
            // Checking if the new player horizontal position is not out of bounds
            if ((horizontal != 0) && (newPlayerCol >= 0) && (newPlayerCol < width))
            {
                if (!(tiles[playerIdx[0], newPlayerCol].sprite is Barrier))
                {
                    moved = true;
                    movementDirection.X += horizontal;
                    tiles[playerIdx[0], newPlayerCol].entity = tiles[playerIdx[0], playerIdx[1]].entity;
                    tiles[playerIdx[0], playerIdx[1]].entity = null;
                    playerIdx[1] = newPlayerCol;
                }
            }

            if (attemptVerticalAgain)
            {
                if (!(tiles[newPlayerRow, playerIdx[1]].sprite is Barrier))
                {
                    moved = true;
                    movementDirection.Y += vertical;
                    tiles[newPlayerRow, playerIdx[1]].entity = tiles[playerIdx[0], playerIdx[1]].entity;
                    tiles[playerIdx[0], playerIdx[1]].entity = null;
                    playerIdx[0] = newPlayerRow;
                }
            }

            if (moved)
                tiles[playerIdx[0], playerIdx[1]].EntitySmoothTransition(movementDirection, 0.15f);
            
            return moved;
        }

        public void DailyUpdate()
        {
            foreach (var tile in tiles)
                tile.DailyUpdate();
        }

        public void CheckHover()
        {
            // Loop through each of the tiles
            for (int i = 0; i < tiles.GetLength(0); ++i) // Row
            {
                for (int j = 0; j < tiles.GetLength(1); ++j) // Column
                {
                    tiles[i, j].highlight = false;
                    // If the mouse is current over a tile that is in proximity of the player, highlight it
                    if (tiles[i, j].hoverRectangle.Contains(Game1.mousePosition) 
                        && Math.Abs(i - playerIdx[0]) <= selectionDistance
                        && Math.Abs(j - playerIdx[1]) <= selectionDistance)
                    {
                        tiles[i, j].highlight = true;
                    }
                }
            }
        }

        public void CheckInteract()
        {
            foreach (var tile in tiles)
            {
                if (tile.hasSprite && tile.highlight && tile.sprite is InteractiveBarrier)
                {
                    Console.WriteLine();
                    InteractiveBarrier sprite = (InteractiveBarrier)tile.sprite;
                    sprite.InteractAction();
                }
                else if (tile.hasSprite && tile.highlight && tile.sprite is InteractiveSprite)
                {
                    InteractiveSprite sprite = (InteractiveSprite)tile.sprite;
                    sprite.InteractAction();
                }
            }
        }
    }
}
