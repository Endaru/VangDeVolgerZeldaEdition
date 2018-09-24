using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger.Objects
{
    class World
    {
        public Space[,] BuildLevel(Space[,] level, int pillarPercentage, int stonePercentage, int numberHammers, int numberShields, out Player player, out Enemy enemy) {
            //create a random number for use with what wil inhabit the space.
            Random rnd = new Random();
            player = new Player();
            enemy = new Enemy();

            //variable's to check if the maximum amount has been reached.
            int maxNumberOfPillars = (level.GetLength(0) * level.GetLength(1)) / 100 * pillarPercentage;
            int maxNumberOfStone = (level.GetLength(0) * level.GetLength(1)) / 100 * stonePercentage;
            int maxNumbeOfHammers = numberHammers;
            int maxNumberOfShields = numberShields;

            //given values to the world.
            int playerPosition = level.GetLength(0) - level.GetLength(0);
            int enemyPosition = level.GetLength(0) - 1;
            int maxlevelsize = level.GetLength(0) * level.GetLength(1);

            //the max number of how many are allowed to spawn.
            int stoneSpawnValue = (level.GetLength(0) * level.GetLength(1)) / 100 * stonePercentage;
            int pillarSpawnValue = (level.GetLength(0) * level.GetLength(1)) / 100 * pillarPercentage;

            //with this we go through the full 2D array starting with the X axis.
            for (int x = 0; x < level.GetLength(0); x++)
            {
                //Go through the Y axis
                for (int y = 0; y < level.GetLength(1); y++)
                {
                    level[x, y] = new Space();
                    int number = rnd.Next(0,(level.GetLength(0)*level.GetLength(1)));

                    if (x == playerPosition && y == playerPosition)
                    {
                        player = new Player();
                        level[x, y].inhabitant = player;
                    }
                    else if (x == enemyPosition && y == enemyPosition)
                    {
                        enemy = new Enemy();
                        level[x, y].inhabitant = enemy;
                    }
                    else
                    {
                        //if the number is between a specific range and the max has not been met. also if the chosen array position is null
                        if (number > (maxlevelsize - pillarSpawnValue) && maxNumberOfPillars > 0 && level[x, y].inhabitant == null)
                        {
                            //then add pillar and decrease by 1.
                            level[x, y].inhabitant = new Pillar(false);
                            maxNumberOfPillars--;
                        }
                        //same as if above this. but with another range.
                        if (number > (maxlevelsize - pillarSpawnValue - stoneSpawnValue) && number <= (maxlevelsize - pillarSpawnValue) && maxNumberOfStone > 0 && level[x, y].inhabitant == null)
                        {
                            //add a stone and decrease by 1.
                            level[x, y].inhabitant = new Stone();
                            maxNumberOfStone--;
                        }
                        //spawn pickup items
                        if (number > (maxlevelsize - pillarSpawnValue - stoneSpawnValue - numberHammers) && number <= (maxlevelsize - numberHammers) && maxNumbeOfHammers > 0 && level[x, y].inhabitant == null)
                        {
                            level[x, y].inhabitant = new Hammer();
                            maxNumbeOfHammers--;
                        }
                        if (number > (maxlevelsize - pillarSpawnValue - stoneSpawnValue - numberHammers - numberShields) && number <= (maxlevelsize - numberShields) && maxNumberOfShields > 0 && level[x, y].inhabitant == null)
                        {
                            level[x, y].inhabitant = new Shield();
                            maxNumberOfShields--;
                        }
                    }
                }
            }
            return level;
        }
        public void AddNeighbors(Space[,] level)
        {
            //go through the X axis
            for (int x = 0; x < level.GetLength(0); x++)
            {
                //Go through the Y axis
                for (int y = 0; y < level.GetLength(1); y++)
                {
                    if (y > 0)
                    {
                        //North
                        level[x, y].CreateNeighbors(ref level[x, y - 1], @enum.Direction.North);
                    }
                    if (x < level.GetLength(0) - 1)
                    {
                        //East
                        level[x, y].CreateNeighbors(ref level[x + 1, y], @enum.Direction.East);
                    }
                    if (y < level.GetLength(1) - 1)
                    {
                        //South
                        level[x, y].CreateNeighbors(ref level[x, y + 1], @enum.Direction.South);
                    }
                    if (x > 0)
                    {
                        //West
                        level[x, y].CreateNeighbors(ref level[x - 1, y], @enum.Direction.West);
                    }
                    if (level[x, y].inhabitant != null)
                    {
                        level[x, y].inhabitant.myPosition = level[x, y];
                    }
                }
            }
            //show the level on the form.
            Build(level);
        }
        public Bitmap Build(Space[,] level)
        {
            //the number of cells the array has so the grid will be large enough.
            int numOfCells = level.GetLength(0);
            //the pixel size of the cells.
            int cellSize = 25;
            //starting X as for images.
            int xas = 1;
            //starting Y as for images.
            int yas = 1;

            //first we create a bitmap so the level wil be loaded in one go later
            Bitmap bmp = new Bitmap((numOfCells * cellSize) + 1,(numOfCells * cellSize) + 1);

            //we us graphics so we can write the drawing to the bitmap
            using (var graphics = Graphics.FromImage(bmp))
            {

                //Create a pen for the grid with the color black.
                Pen p = new Pen(Color.FromArgb(255, 66, 105, 81));
                //make a rectangle so the grid will be closed and not open at the last row
                Rectangle rect = new Rectangle(0, 0, numOfCells * cellSize, numOfCells * cellSize);

                //as long as the number of cells has not been reached keep drawing lines.
                for (int i = 0; i < numOfCells; i++)
                {
                    //draw the drawings for real on the bitmap
                    graphics.DrawRectangle(p, rect);
                    graphics.DrawLine(p, i * cellSize, 0, i * cellSize, numOfCells * cellSize);
                    graphics.DrawLine(p, 0, i * cellSize, numOfCells * cellSize, i * cellSize);
                }

                //here we use the same for loop to go through the level.
                for (int x = 0; x < level.GetLength(0); x++)
                {
                    for (int y = 0; y < level.GetLength(1); y++)
                    {
                        //if the space is not ocuppied do nothing otherwise draw the image
                        if (level[x, y].inhabitant != null)
                        {
                            //draw the image with a size of 24 pixels by 24 pixels
                            graphics.DrawImage(level[x, y].inhabitant.image, xas, yas, 24, 24);
                        }
                        //increase so we go to the next grid.
                        yas += 25;
                    }
                    //go to the next row.
                    xas += 25;
                    //back to 1 so we start at the top again
                    yas = 1;
                }
                //add the image to the picturebox.
                return bmp;
            }
        }
    }
}
