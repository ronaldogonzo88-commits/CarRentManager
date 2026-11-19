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
            //Refresh the car list when the car opens
            RefreshingCarList();
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

            //Display message when all details are valid
            lblOutput.Text = "Details are valid.";

            //Convert the registration plate to capital letters
            string plate = txtPlate.Text.ToUpper();

            //Check wheather car already exists
            foreach (Car car in cars)
            {
                if (car.Plate == plate)
                {
                    lblOutput.Text = "A car with that plate already exist";
                    return;
                }
            }

            //Create a new car and add it to the list
            Car car1 = new Car(plate, txtModel.Text, rate);
            cars.Add(car1);

            //Refresh the car list adding
            RefreshingCarList();

            //Clear all input boxes
            txtPlate.Clear();
            txtModel.Clear();
            txtDailyRate.Clear();

            //Daily success msg
            lblOutput.Text = "Car added";
        }

        //Refreshing the car list display on the form
        private void RefreshingCarList()
        {
            //Clear the list before refreshing
            lstCars.Items.Clear();
            //Go thru every car in the list
            foreach (Car car in cars)
            {
                //Format each cars details for display
                string details = car.Plate + " | " + car.Model + " | $" + car.DailyRate.ToString("F2") + " per day | " + car.GetStatus();

                //Add the car details to the list box
                lstCars.Items.Add(details);
            }
        }
        //Button used to clear all the text box an lebels
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPlate.Clear();
            txtModel.Clear();
            txtDailyRate.Clear();
            lblOutput.Text = "";
        }
    }
}
