using System;
using System.Windows.Forms;
/// <summary>
/// Class created to help the manipulation of tile actions
/// </summary>
namespace GameOfSquare

{
    public class Tile : Button
    {
        private const int LEFT = 20;
        private const int TOP = 100;
        private const int WIDTH = 50;
        private const int HEIGHT = 50;
        private const int VGAP = 10;

        private Form1 form;

        public int Column { get; set; }

        public int Row { get; set; }

        public int Number { get; private set; }
        
        /// <summary>
        /// Constructor for new tile button
        /// </summary>
        /// <param name="column">column position</param>
        /// <param name="row">row position</param>
        /// <param name="number"></param>
        /// <param name="form">for form used for the game</param>
        public Tile(int column, int row, int number, Form1 form)
        {
            this.Number = number;
            this.Row = row;
            this.Column = column;
            this.Left = LEFT + column * (VGAP + WIDTH);
            this.Top = TOP + row * (VGAP + HEIGHT);
            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.Text = number.ToString();
            this.form = form;
        }
        /// <summary>
        /// Function to move tile and check for win
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            form.ShiftTile(this.Column, this.Row);
            this.UpdatePosition();
            form.CheckWin();
        }
        /// <summary>
        /// Function to update the position in the grid
        /// </summary>
        public void UpdatePosition()
        {
            this.Left = LEFT + Column * (VGAP + WIDTH);
            this.Top = TOP + Row * (VGAP + HEIGHT);
        }

       
    }
}
