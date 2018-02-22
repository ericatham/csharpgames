/*
 * Programmer: Erica de Sousa Menezes 
 * Revision history: 
 *     20-Sep-17: project created
 *     22-Sep-17: project debbuged
 * 
 * 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdeSousaMenezesAssignment1
{
    /// <summary>
    /// Application of reservation system for an airflight seating
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructor of the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        //Determining the quantity of seats available and quantity of possible entries for the waiting list
        string[,] seats = new string[5, 3];
        string[] waitlist = new string[10];

        /// <summary>
        /// Load event handler for the form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //inicialize the seats and waiting list array
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    seats[i, j] = "";
                }
            }

            for (int i = 0; i < waitlist.Length; i++)
            {
                waitlist[i] = "";
            }

            //display the options for rows and columns through the listbox
            listboxRow.Items.Add(0);
            listboxRow.Items.Add(1);
            listboxRow.Items.Add(2);
            listboxRow.Items.Add(3);
            listboxRow.Items.Add(4);

            listboxColumn.Items.Add(0);
            listboxColumn.Items.Add(1);
            listboxColumn.Items.Add(2);
        }

        /// <summary>
        /// Click event handler for the "Show All button"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            string result = "";
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                   result += "[" + i + ","+ j+"] -- " + seats[i,j] +"\n";
                }
            }
            richtextReservation.Text = result;
        }

        /// <summary>
        /// This function checks how many seats are already taken
        /// </summary>
        /// <returns>the number of seats already taken</returns>
        private int CheckReservations()
        {
            int check;

            check = 0;
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    if (seats[i, j] != "")
                    {
                        check++;
                    }
                }
            }
            return check;
        }
        
        /// <summary>
        /// This function store the length of the waiting list based on the spots taken
        /// </summary>
        /// <returns>the number of the seats in waiting list taken</returns>
        private int CheckWaitingList()
        {
            int check;

            check = 0;
            for (int i = 0; i < waitlist.Length; i++)
            {
                if (waitlist[i] != "")
                {
                    check++;
                }
            }
            return check;
        }
        /// <summary>
        /// This function check if there is any available seat in the waiting list
        /// </summary>
        /// <returns>the next available position in the waiting list</returns>
        private int AvaliabilityWaitList()
        {
            int position;
            position = -1; //random value assigned just to work as a flag 

            for (int i = 0; i < waitlist.Length; i++)
            {
                if (waitlist[i] == "")
                {
                    position = i;
                    break;
                }           
            }
            return position;
        }

        /// <summary>
        /// Click event handler for the "Book" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBook_Click(object sender, EventArgs e)
        {
            int row;
            int column;
            int checkBook;
            int positionWaitList;
            try
            {
                row = listboxRow.SelectedIndex;
                column = listboxColumn.SelectedIndex;

                checkBook = CheckReservations();
                positionWaitList = AvaliabilityWaitList();
                //Check the entry of the name text field 
                if (txtName.Text == "")
                {
                    MessageBox.Show("You should insert a name in the proper field above");
                }
                //Check if the user selected a row and column option for the seat
                else if (row == -1 || column == -1)
                {
                    MessageBox.Show("Please, select one of the rows and one of the columns for the desired seat");
                }
                //Check if there is still any available seat and inform if not
                else if (checkBook == 15 && positionWaitList == -1)
                {
                    MessageBox.Show("There are no more seats available and the waiting list is full");
                }
                //Check if there are still available spots in the waiting list and add inform the user
                else if (checkBook == 15 && positionWaitList != -1)
                {
                    waitlist[positionWaitList] = txtName.Text; //add to the waiting list
                    MessageBox.Show("There are no more seats available, but you've been successfully added to the waiting list");      
                }
                //Check if the required seat is not taken yet and inform the user 
                else if (seats[row, column] != "")
                {
                    MessageBox.Show("This place is already taken. Please, choose another seat and click 'Book' again");
                }
                //Check if the selected seat is not taken and proceed with the book
                else if (seats[row, column] == "")
                {
                    seats[row, column] = txtName.Text;
                    MessageBox.Show($"You successfully booked the seat [{row},{column}]");
                }
                //Inform if, for any reason, the book was not completed
                else
                {
                    MessageBox.Show("Something went wrong! Please, provide the required information and click 'Book' again");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("The error found is:" + ex.Message);
            }
            
        }

        /// <summary>
        /// Click event handler for the "Status" button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatus_Click(object sender, EventArgs e)
        {
            int rowSeat;
            int columnSeat;
            try
            {
                rowSeat = listboxRow.SelectedIndex;
                columnSeat = listboxColumn.SelectedIndex;
                if (seats[rowSeat,columnSeat] != "")
                {
                    txtStatus.Text = "Not Available";
                }
                else
                {
                    txtStatus.Text = "Available";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("The error found is: "+ex.Message);
            }
            
        }

        /// <summary>
        /// Click event handler for the "Add to Waiting List" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddWaitList_Click(object sender, EventArgs e)
        {
            int checkSeats;
            int positionWaitList;

            try
            {
                checkSeats = CheckReservations();
                positionWaitList = AvaliabilityWaitList();
                //Check if the entry in text name field is valid
                if (txtName.Text == "")
                {
                    MessageBox.Show("You should insert a name in the proper field above");
                }
                //Check and inform user if there are still available seats
                else if (checkSeats < 15)
                {
                    MessageBox.Show("Seats are available");
                }
                //Use the return value from the function to check if waiting list is full 
                else if (positionWaitList == -1)
                {
                    MessageBox.Show("The waiting list is full. No seats available");
                }
                //Add to waiting list if there are still places available
                else if (positionWaitList != -1)
                {
                    waitlist[positionWaitList] = txtName.Text;
                    MessageBox.Show("You've been successfull added to the waiting list");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("The error found is: " + ex.Message );
            }
            
        }

        /// <summary>
        /// Event handler for the "Cancel" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            int row;
            int column;
            int checkWaitList; //variable created to store the number of seats taken
            int positionWaitList; //variable that stores the position of the next available seat;
            try
            {
                row = listboxRow.SelectedIndex;
                column = listboxColumn.SelectedIndex;

                if (row == -1 || column == -1)
                {
                    MessageBox.Show("You should select the position of the seat you want to be cancelled");
                }
                else
                {
                    seats[row, column] = "";
                    MessageBox.Show("You successfully cancelled the seat");
                }

                checkWaitList = CheckWaitingList();
                positionWaitList = AvaliabilityWaitList();
                if (checkWaitList > 0)
                {
                    positionWaitList = positionWaitList - 1;
                    seats[row, column] = waitlist[0];
                    for (int i = 0; i < positionWaitList; i++)
                    {
                        waitlist[i] = waitlist[i + 1];
                    }
                    waitlist[positionWaitList] = "";
                    MessageBox.Show("The first person in the waiting list was moved to the recent cancelled seat");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("The error found is: "+ ex.Message);
            }
           
        }

        /// <summary>
        /// Click event handler for the "Fill All(Debug)" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFillAll_Click(object sender, EventArgs e)
        {
            string passenger;

            passenger = txtName.Text;
            if(passenger == "")
            {
                MessageBox.Show("You should insert a name to the proper field");
            }
            else
            {
                for (int i = 0; i < seats.GetLength(0); i++)
                {
                    for (int j = 0; j < seats.GetLength(1); j++)
                    {
                        seats[i, j] = passenger;
                    }
                }
            }
        }

        /// <summary>
        /// Click event handler for the "Show Waiting List" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowWaitList_Click(object sender, EventArgs e)
        {
            string result = "";

            for (int i = 0; i < waitlist.Length; i++)
            {
                result += "[" + i + "] -- " + waitlist[i] + "\n"; 
            }

            richtextWaitingList.Text = result;
        }
    }
}
