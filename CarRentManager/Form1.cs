namespace CarRentManager
{
    public partial class Form1 : Form
    {
        //List which stores all registered cars
        List<Car> cars = new List<Car>();
        public Form1()
        {
            InitializeComponent();
        }
        //Checks whether a car registration plate is valid
        private bool IsValidPlate(string plate)
        {
            //checks if plate has 6 characters
            if (plate.Length != 6)
            {
                return false;
            }
            //checks each character in the plate
            int i;
            for (i = 0; i < plate.Length; i++)
            {
                if (!char.IsLetterOrDigit(plate[i]))
                    return false;
            }
            //Return true if all characters are valid
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            //Validate the car registration plate
            if (!IsValidPlate(txtPlate.Text))
            {
                lblOutput.Text = "Invalid plate. Must be exactly 6 letters or numbers.";
                return;
            }

            //Check that the car model is not empty
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                lblOutput.Text = "Car model cannot be empty.";
                return;
            }

            //Validate the daily rate is number above zero
            decimal rate;
            if (!decimal.TryParse(txtDailyRate.Text, out rate) || rate <= 0)
            {
                lblOutput.Text = "Invalid daily rate.";
                return;
            }

            //Display message when all ditails are valid
            lblOutput.Text = "Details are valid.";
        }
    }
}
