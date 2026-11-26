using System.Runtime.CompilerServices;
using MySql.Data.MySqlClient;

namespace CarRentManager
{
    public partial class Form1 : Form
    {
        //List which stores all registered cars
        List<Car> cars = new List<Car>();

        //Store all history of rentals
        private List<Rental> rentals = new List<Rental>();

        //store the connection details for the carrent DB
        private string connectionString = "server=localhost;user id=root;password=;database=carrent;";
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
            foreach (Rental rental in rentals)
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
            //load cars and rentals from DB
            LoadCars();
            LoadRentals();

            //Refresh the car list when the car opens
            RefreshingCarList();
            RefreshHistory();
        }

        //insert a new car into the database
        private bool InsertCars(Car car)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO cars (plate, model, category, daily_rate, is_rented) " + "VALUES (@plate, @model, @category, @rate, @rented)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plate", car.Plate);
                        cmd.Parameters.AddWithValue("@model", car.Model);
                        cmd.Parameters.AddWithValue("@category", car.GetCategory());
                        cmd.Parameters.AddWithValue("@rate", car.DailyRate);
                        cmd.Parameters.AddWithValue("@rented", car.IsRented);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not save car to database: " + ex.Message);
                return false;
            }
        }

        //Insert a new rental into the database
        private bool InsertRental(Rental rental)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO rentals (plate, customer_name, customer_phone, rent_date) VALUES(@plate, @name, @phone, @rentDate)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@plate", rental.Plate);
                        cmd.Parameters.AddWithValue("@name", rental.CustomerName);
                        cmd.Parameters.AddWithValue("@phone", rental.CustomerPhone);
                        cmd.Parameters.AddWithValue("@rentDate", rental.RentDate);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not save rental: " + ex.Message);
                return false;
            }
        }

        //update wheather a car is rented in the DB
        private bool UpdateCarRented(string plate, bool isRented)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE cars SET is_rented = @rented WHERE plate = @plate";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@rented", isRented);
                        cmd.Parameters.AddWithValue("@plate", plate);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not update car status: " + ex.Message);
                return false;
            }
        }

        //update a rental record when the car is returned
        private bool UpdateRentalReturned(Rental rental)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                { 
                    conn.Open();
                    string query = @"UPDATE rentals SET return_date = @returnDate, days = @days, total_cost = @totalCost WHERE plate = @plate AND return_date IS NULL";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@returnDate", rental.ReturnDate);
                        cmd.Parameters.AddWithValue("@days", rental.Days);
                        cmd.Parameters.AddWithValue("@totalCost", rental.TotalCost);
                        cmd.Parameters.AddWithValue("@plate", rental.Plate);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not update rental: " + ex.Message);
                return false;
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            //check that the a car category has been selected
            if (cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a car category.");
                return;
            }
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

            //Create a car based on category
            Car car1;
            switch (cboCategory.Text)
            {
                case "Economy":
                    car1 = new Economy(plate, txtModel.Text, rate);
                    break;
                case "SUV":
                    car1 = new SUV(plate, txtModel.Text, rate);
                    break;
                case "Luxury":
                    car1 = new Luxury(plate, txtModel.Text, rate);
                    break;
                default:
                    lblOutput.Text = "Invalid car category.";
                    return;
            }

            //save the car to the database first
            if (!InsertCars(car1))
            {
                return;
            }
            //add the car to the list after saving
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
                //added formatted cardeatils to the list box
                lstCars.Items.Add(FormatCarLine(car));

            }
        }
        //format car info forr display
        private string FormatCarLine(Car car)
        {
            return $"{car.Plate} | {car.Model} | {car.GetCategory()} |$ {car.DailyRate:F2} per day | {car.GetStatus()}";
        }
        //Button used to clear all the text box an lebels
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPlate.Clear();
            txtModel.Clear();
            txtDailyRate.Clear();
            lblOutput.Text = "";
        }

        //Load all cars from the database
        private void LoadCars()
        {
            cars.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM cars";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Read car details from DB
                            string plate = reader["plate"].ToString()!;
                            string model = reader["model"].ToString()!;
                            string category = reader["category"].ToString()!;
                            decimal dailyRate = Convert.ToDecimal(reader["daily_rate"]);
                            bool isRented = Convert.ToBoolean(reader["is_rented"]);

                            //create the correct car object
                            Car car;
                            if (category == "Economy")
                            {

                                car = new Economy(plate, model, dailyRate);
                                ;
                            }
                            else if (category == "SUV")
                            {
                                car = new SUV(plate, model, dailyRate);
                            }
                            else if (category == "Luxury")
                            {
                                car = new Luxury(plate, model, dailyRate);
                            }
                            else
                            {
                                continue;
                            }
                            //restore the cars rental status
                            car.IsRented = isRented;
                            //add the car to the list
                            cars.Add(car);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Could not connect to the database. Is MySQL running " + ex.Message);
            }
        }

        //Load all rental records from the database
        private void LoadRentals()
        {
            rentals.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM rentals";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Read rental details from DB
                            string plate = reader["plate"].ToString()!;
                            string customerName = reader["customer_name"].ToString()!;
                            string customerPhone = reader["customer_phone"].ToString()!;
                            DateTime rentDate = Convert.ToDateTime(reader["rent_date"]);

                            //create the correct car object
                            Rental rental = new Rental(plate, customerName, customerPhone, rentDate);

                            //check wheather the rental has been returned
                            if (reader["return_date"] != DBNull.Value)
                            {
                                DateTime returnDate = Convert.ToDateTime(reader["return_date"]);
                                int days = Convert.ToInt32(reader["days"]);
                                decimal totalCost = Convert.ToDecimal(reader["total_cost"]);

                            //restore the returned rental details
                            rental.MarkReturned(returnDate, days, totalCost);
                        }
                        //add the rental to the list
                        rentals.Add(rental);
                        }

                    }
                }
            }
        catch (MySqlException ex)
            {
            MessageBox.Show("Could not load rentals. Is MySQL running? " + ex.Message);
            }
        }
        //find a car using its plate
        private Car? FindCar(string plate)
        {
            foreach(Car car in cars)
            {
                if (car.Plate == plate)
                {
                    return car;
                }
            }
            return null;
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
            if (dtpReturnDate.Value.Date < dptRentDate.Value.Date)
            {
                lblOutput.Text = "Return date cannot be before the rent date.";
                return;
            }
            //Create  a rental using the selected rent date
            Rental rental = new Rental(selectedCar.Plate, txtCustomerName.Text, txtPhoneNumber.Text, dptRentDate.Value.Date);
            //save rental to the database first
            if (!InsertRental(rental))
            {
                return;
            }
            //Add the rental record to the rentals list after saving succeeds
            rentals.Add(rental);
            RefreshHistory();
            //update the cars status in the DB
            if (!UpdateCarRented(selectedCar.Plate, true))
            {
                return;
            }
            //UPDATE THE CARS STATUS IN THE PROGRAM
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
            if (dtpReturnDate.Value.Date < activeRental.RentDate.Date)
            {
                lblOutput.Text = "Return date cannot br before rent date.";
                return;
            }
            int days = (dtpReturnDate.Value.Date - activeRental.RentDate.Date).Days;
            if (days < 1)
            {
                days = 1;
            }
            decimal finalCost = selectedCar.CalculateTotal(days);
            activeRental.MarkReturned(dtpReturnDate.Value, days, finalCost);

            //save returned details and update availabilityin DB
            if (!UpdateRentalReturned(activeRental) || !UpdateCarRented(selectedCar.Plate, false))
            {
                return;
            }
            //change the car status to availabe
            selectedCar.IsRented = false;
            //refresh the car list to show the updated status
            RefreshingCarList();
            RefreshHistory();
            //Display the return confirmation
            lblOutput.Text = $"{selectedCar.Plate} returned. {activeRental.Days} days, total ${activeRental.TotalCost:F2}";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //check if search button is empty
            if (txtSearch.Text.Trim() == "")
            {
                lblOutput.Text = "Please enter something to search";
                return;
            }
            //get search text and convert it to lowercase
            string searchText = txtSearch.Text.Trim().ToLower();
            //clear previous search
            lstResults.Items.Clear();
            //going thru every car in list
            foreach (Car car in cars)
            {
                //check if the plate or model contains the search text
                if (car.Plate.ToLower().Contains(searchText) || car.Model.ToLower().Contains(searchText))
                {
                    lstResults.Items.Add(FormatCarLine(car));
                }
            }
            //check if any cars matched the search 
            if (lstResults.Items.Count == 0)
            {
                lstResults.Items.Add("No cars found");
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //count totan num of cars
            int totalCars = cars.Count;
            //start the availabe and return rented counts at zero
            int availableCars = 0;
            int rentedCars = 0;
            //go thru every car and check its status
            foreach (Car car in cars)
            {
                if (car.IsRented)
                {
                    rentedCars++;
                }
                else
                {
                    availableCars++;
                }
            }
            //store total income for each car category
            decimal totalIncome = 0m;
            decimal economyIncome = 0m;
            decimal suvIncome = 0;
            decimal luxuryIncome = 0m;

            //Go thru every rental in rental history
            foreach (Rental rental in rentals)
            {
                //store the total income and income for each car category history
                if (rental.IsReturned)
                {
                    //find the car connected to this rental
                    Car? car = FindCar(rental.Plate);
                    //make sure the car was found
                    if (car != null)
                    {
                        //add this rental cost to the total income
                        totalIncome += rental.TotalCost;
                        //check the car category and add income to the correct category
                        string category = car.GetCategory();
                        if (category == "Economy")
                        {
                            economyIncome += rental.TotalCost;
                        }
                        else if (category == "SUV")
                        {
                            suvIncome += rental.TotalCost;
                        }
                        else if (category == "Luxury")
                        {
                            luxuryIncome += rental.TotalCost;
                        }
                    }
                }
            }
            //clearany previous report
            lstReport.Items.Clear();
            //display the car counts
            lstReport.Items.Add("Total cars: " + totalCars);
            lstReport.Items.Add("Available cars: " + availableCars);
            lstReport.Items.Add("Rented cars: " + rentedCars);
            //display the income figures
            lstReport.Items.Add("Total income: $" + totalIncome.ToString("F2"));
            lstReport.Items.Add("Economy income: $" + economyIncome.ToString("F2"));
            lstReport.Items.Add("SUV income: $" + suvIncome.ToString("F2"));
            lstReport.Items.Add("Luxury income: $" + luxuryIncome.ToString("F2"));
        }
    }
}
