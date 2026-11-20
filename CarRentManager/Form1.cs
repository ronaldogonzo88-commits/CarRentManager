using System.Runtime.CompilerServices;

namespace CarRentManager
{
    public partial class Form1 : Form
    {
        //List which stores all registered cars
        List<Car> cars = new List<Car>();

        //Store all history of rentals
        private List<Rental> rentals = new List<Rental>();
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

        //Check wheather the phone number contains 7 to 10 digits
        private bool IsValidPhone(string phone)
        {
            //checks if plate is 7 to 10 digits
            if (phone.Length < 7 || phone.Length > 10)
            {
                return false;
            }
            //checks if each character is digit
            for (int i = 0; i < phone.Length; i++)
            {
                if (!char.IsDigit(phone[i]))
                    return false;
            }
            //return true if all are correct
            return true;
        }

        //Refresh the rental history
        private void RefreshHistory()
        {
            //empty the history list
            lstHistory.Items.Clear();
            //go thru every rental
            foreach(Rental rental in rentals)
            {
                if (rental.IsReturned)
                {
                    lstHistory.Items.Add($"{rental.Plate} | {rental.CustomerName} | {rental.CustomerPhone} | {rental.RentDate:yyyy-MM-dd} to {rental.ReturnDate:yyyy-MM-dd} | {rental.Days} days | ${rental.TotalCost:F2}");
                }
                else
                {
                    lstHistory.Items.Add($"{rental.Plate} |  {rental.CustomerName} | {rental.CustomerPhone} | out since {rental.RentDate:yyyy-MM-dd}");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Refresh the car list when the car opens
            RefreshingCarList();
            RefreshHistory();
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

        private void btnRent_Click(object sender, EventArgs e)
        {
            //Check if car has been selected
            if (lstCars.SelectedIndex == -1)
            {
                lblOutput.Text = "Please select a car";
                return;
            }
            //Get selected car from the car list
            Car selectedCar = cars[lstCars.SelectedIndex];
            //Check if the selected car is already rented
            if (selectedCar.IsRented)
            {
                lblOutput.Text = "This car is already rented";
                return;
            }
            //Check if the customer name is empty
            if (txtCustomerName.Text == "")
            {
                lblOutput.Text = "Please customer name";
                return;
            }
            //check if the phone number is valid
            if (!IsValidPhone(txtPhoneNumber.Text))
            {
                lblOutput.Text = "Please enter a valid phone number";
                return;
            }
            //check that the return date is not before the rent date
            if (dtpReturnDate.Value.Date <dptRentDate.Value.Date)
            {
                lblOutput.Text = "Return date cannot be before the rent date.";
                return;
            }
            //Create  a rental using the selected rent date
            Rental rental = new Rental(selectedCar.Plate, txtCustomerName.Text, txtPhoneNumber.Text, dptRentDate.Value.Date);
            //Add the rental record to the rentals list
            rentals.Add(rental);
            RefreshHistory();
            //Mark car as rented 
            selectedCar.IsRented = true;
            //Refresh the car list to show update status
            RefreshingCarList();
            //Clear the customer name and phone number textboxes
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            //Display a success message
            lblOutput.Text = selectedCar.Plate + "rented to " + rental.CustomerName + " on" + rental.RentDate.ToString("yyyy-MM-dd");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //checks if car has been selected 
            if (lstCars.SelectedIndex == -1)
            {
                lblOutput.Text = "Please select a car";
                return;
            }
            //get the selected car from the cars list
            Car selectedCar = cars[lstCars.SelectedIndex];
            //Check if the car is currently rented
            if (!selectedCar.IsRented)
            {
                lblOutput.Text = "This car is not currently rented";
                return;
            }
            //find the active rental record
            Rental activeRental = null;
            foreach (Rental rental in rentals)
            {
                if (rental.Plate == selectedCar.Plate && !rental.IsReturned)
                {
                    activeRental = rental;
                    break;
                }
            }
            //check if an active rental recoed was found
            if (activeRental == null)
            {
                lblOutput.Text = "No active rental record found";
                return;
            }
            //mark rental as returned using todays date
            if(dtpReturnDate.Value.Date < activeRental.RentDate.Date)
            {
                lblOutput.Text = "Return date cannot br before rent date.";
                return;
            }
            activeRental.MarkReturned(dtpReturnDate.Value.Date, selectedCar.DailyRate);
            //change the car status to availabe
            selectedCar.IsRented = false;
            //refresh the car list to show the updated status
            RefreshingCarList();
            RefreshHistory();
            //Display the return confirmation
            lblOutput.Text = $"{selectedCar.Plate} returned. {activeRental.Days} days, total ${activeRental.TotalCost:F2}";
        }
    }
}
