/*
 * Programmers: Bill Wilson
 *              Erica Menezes
 * Revision history:
 *              30-Nov-2017: project created
 *              30-Nov-2017: project debbuged
 * 
 */
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Program to generate, load and save the N-Puzzle game 
/// </summary>
namespace GameOfSquare
{

    public partial class Form1 : Form
    {
        private const int NUMBER_OF_MOVES = 1000;

        private Tile[,] tiles;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Function to generate the array and shuffle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btngener_Click(object sender, EventArgs e)
        {
            if (int.Parse(tbhigh.Text) > 1 || int.Parse(tblong.Text) > 1)
            {
                int heightOfGrid = int.Parse(tbhigh.Text);
                int widthOfGrid = int.Parse(tblong.Text);
                this.Populate(widthOfGrid, heightOfGrid);
                this.Shuffle(widthOfGrid - 1, heightOfGrid - 1);
            }
            else
            {
                MessageBox.Show("error please select a valid entry");
            }
        }

        /// <summary>
        /// Function to fill the array with ordered numbers on tiles
        /// </summary>
        /// <param name="columns">number of columns for the grid</param>
        /// <param name="rows">number of rows for the grid</param>
        private void Populate(int columns, int rows)
        {
            int total = columns * rows;
            int[,] numbers = new int[columns, rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int num = j + (i * columns) + 1;
                    if (num == total)
                    {
                        numbers[j, i] = -1;
                        continue;
                    }
                    numbers[j, i] = num;
                }
            }
            this.Populate(numbers);
        }
        /// <summary>
        /// Function to generate the actual array of tiles
        /// </summary>
        /// <param name="numbers">array created for the tiles</param>
        private void Populate(int[,] numbers)
        {
            if (this.tiles != null)
            {
                foreach (Tile tile in this.tiles)
                {
                    this.Controls.Remove(tile);
                }
                this.tiles = null;
            }

            int columns = numbers.GetLength(0);
            int rows = numbers.GetLength(1);
            int total = columns * rows;
            this.tiles = new Tile[columns, rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int num = numbers[j, i];
                    if (num == -1)
                    {
                        continue;
                    }
                    this.tiles[j, i] = new Tile(j, i, num, this);
                    this.Controls.Add(this.tiles[j, i]);
                }
            }
        }
        /// <summary>
        /// Function to randomize tiles when game opens
        /// </summary>
        /// <param name="emptyColumn">column position for the empty tile</param>
        /// <param name="emptyRow">row position for the empty row</param>
        private void Shuffle(int emptyColumn, int emptyRow)
        {
            for (int i = 0; i < NUMBER_OF_MOVES; i++)
            {
                Tile nextMove = this.RandomNeighbour(emptyColumn, emptyRow);
                if (nextMove == null)
                {
                    continue;
                }

                emptyColumn = nextMove.Column;
                emptyRow = nextMove.Row;
                this.ShiftTile(nextMove.Column, nextMove.Row);
            }

            foreach (Tile tile in this.tiles)
            {
                if (tile == null)
                {
                    continue;
                }
                tile.UpdatePosition();
            }
        }
        /// <summary>
        /// Function to randomise the moves
        /// </summary>
        /// <param name="column">the column position</param>
        /// <param name="row">the row position</param>
        /// <returns></returns>
        private Tile RandomNeighbour(int column, int row)
        {
            List<Tile> neighbours = new List<Tile>();
            if (column > 0)
            {
                neighbours.Add(this.tiles[column - 1, row]);
            }

            if (column < this.tiles.GetLength(0) - 1)
            {
                neighbours.Add(this.tiles[column + 1, row]);
            }

            if (row > 0)
            {
                neighbours.Add(this.tiles[column, row - 1]);
            }

            if (row < this.tiles.GetLength(1) - 1)
            {
                neighbours.Add(this.tiles[column, row + 1]);
            }
          
                return neighbours[this.random.Next(neighbours.Count)];
          

        }
        /// <summary>
        /// Function to move the tiles on click
        /// </summary>
        /// <param name="column">the column position</param>
        /// <param name="row">the row position</param>
        public void ShiftTile(int column, int row)
        {
            Tile tempTile = this.tiles[column, row];
            if (row > 0 && this.tiles[column, row - 1] == null)
            {
                this.tiles[column, row] = null;
                row--;
            }
            else if (row < this.tiles.GetLength(1) - 1 && tiles[column, row + 1] == null)
            {
                this.tiles[column, row] = null;
                row++;
            }
            else if (column > 0 && tiles[column - 1, row] == null)
            {
                this.tiles[column, row] = null;
                column--;
            }
            else if (column < this.tiles.GetLength(0) - 1 && tiles[column + 1, row] == null)
            {
                this.tiles[column, row] = null;
                column++;
            }
            else
            {
                MessageBox.Show("this is not a valid move");
                return;
            }


            tempTile.Column = column;
            tempTile.Row = row;
            this.tiles[column, row] = tempTile;
        }
        /// <summary>
        /// Function to check the game state to see if player won
        /// </summary>
        /// <returns>boolean value true if player wins</returns>
        public bool CheckWin()
        {
            Tile previousValue = null;
            for (int i = 0; i < tiles.GetLength(1); i++)
            {
                for (int j = 0; j < tiles.GetLength(0); j++)

                {
                    if (previousValue != null)
                    {
                        if (tiles[j, i] == null)
                        {
                            if (tiles.GetLength(1) - 1 == i && tiles.GetLength(0) - 1 == j)
                            {
                                break;
                            }
                            return false;
                        }
                        if (tiles[j, i].Number < previousValue.Number)
                        {
                            return false;
                        }
                    }

                    previousValue = tiles[j, i];

                }
            }

            MessageBox.Show("you win");

            return true;
        }
        /// <summary>
        /// Function to load a saved game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open GOSSave";
            open.Filter = "Comma-separated (*.csv)|*.csv|All files (*.*)|*.*";
            open.InitialDirectory = @"C:\";
            if (open.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string[] lines = null;
            try
            {
                lines = File.ReadAllLines(open.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                return;
            }

            if (lines == null || lines.Length == 0)
            {
                return;
            }

            int columns = lines[0].Split(',').Length;
            int[,] numbers = new int[columns, lines.Length];
            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                string[] cols = lines[i].Split(',');
                for (int j = 0; j < numbers.GetLength(0); j++)
                {
                    numbers[j, i] = int.Parse(cols[j]);
                }
            }

            this.Populate(numbers);
        }
        /// <summary>
        /// Event handler to save the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "GOSSave.csv";
            save.Filter = "Comma-separated (*.csv)|*.csv|All files (*.*)|*.*";

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(save.FileName))
                {
                    for (int i = 0; i < tiles.GetLength(1); i++)
                    {
                        string[] line = new string[tiles.GetLength(0)];
                        for (int j = 0; j < tiles.GetLength(0); j++)
                        {
                            line[j] = tiles[j, i] == null ? "-1" : tiles[j, i].Number.ToString();
                        }

                        sw.WriteLine(string.Join(",", line));
                    }
                }
            }
        }

    }
}
