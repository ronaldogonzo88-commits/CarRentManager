namespace CarRentManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnAddCar = new Button();
            txtPlate = new TextBox();
            lblPlate = new Label();
            lblRegistredCars = new Label();
            lblDailyRate = new Label();
            lblCategory = new Label();
            lblModel = new Label();
            btnClear = new Button();
            txtDailyRate = new TextBox();
            txtCategory = new TextBox();
            txtModel = new TextBox();
            lstCars = new ListBox();
            lblOutput = new Label();
            lblCustomerDetails = new Label();
            label2 = new Label();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            btnReturn = new Button();
            btnRent = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(75, 56);
            label1.Name = "label1";
            label1.Size = new Size(152, 25);
            label1.TabIndex = 0;
            label1.Text = "Car Registration";
            // 
            // btnAddCar
            // 
            btnAddCar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCar.ForeColor = SystemColors.ActiveCaptionText;
            btnAddCar.Location = new Point(111, 293);
            btnAddCar.Name = "btnAddCar";
            btnAddCar.Size = new Size(62, 23);
            btnAddCar.TabIndex = 1;
            btnAddCar.Text = "Add Car";
            btnAddCar.UseVisualStyleBackColor = true;
            btnAddCar.Click += btnAddCar_Click;
            // 
            // txtPlate
            // 
            txtPlate.Location = new Point(111, 112);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(185, 23);
            txtPlate.TabIndex = 2;
            // 
            // lblPlate
            // 
            lblPlate.AutoSize = true;
            lblPlate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlate.Location = new Point(29, 118);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(41, 17);
            lblPlate.TabIndex = 3;
            lblPlate.Text = "Plate:";
            // 
            // lblRegistredCars
            // 
            lblRegistredCars.AutoSize = true;
            lblRegistredCars.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegistredCars.Location = new Point(29, 380);
            lblRegistredCars.Name = "lblRegistredCars";
            lblRegistredCars.Size = new Size(102, 17);
            lblRegistredCars.TabIndex = 4;
            lblRegistredCars.Text = "Registered Cars";
            // 
            // lblDailyRate
            // 
            lblDailyRate.AutoSize = true;
            lblDailyRate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDailyRate.Location = new Point(29, 247);
            lblDailyRate.Name = "lblDailyRate";
            lblDailyRate.Size = new Size(71, 17);
            lblDailyRate.TabIndex = 5;
            lblDailyRate.Text = "Daily Rate:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(29, 205);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(67, 17);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Category:";
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModel.Location = new Point(29, 164);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(49, 17);
            lblModel.TabIndex = 7;
            lblModel.Text = "Model:";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(233, 293);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(63, 23);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtDailyRate
            // 
            txtDailyRate.Location = new Point(111, 241);
            txtDailyRate.Name = "txtDailyRate";
            txtDailyRate.Size = new Size(185, 23);
            txtDailyRate.TabIndex = 9;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(111, 199);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(185, 23);
            txtCategory.TabIndex = 10;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(111, 158);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(185, 23);
            txtModel.TabIndex = 11;
            // 
            // lstCars
            // 
            lstCars.FormattingEnabled = true;
            lstCars.ItemHeight = 15;
            lstCars.Location = new Point(29, 422);
            lstCars.Name = "lstCars";
            lstCars.Size = new Size(267, 64);
            lstCars.TabIndex = 12;
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOutput.Location = new Point(93, 342);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(11, 17);
            lblOutput.TabIndex = 13;
            lblOutput.Text = ":";
            // 
            // lblCustomerDetails
            // 
            lblCustomerDetails.AutoSize = true;
            lblCustomerDetails.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCustomerDetails.Location = new Point(492, 60);
            lblCustomerDetails.Name = "lblCustomerDetails";
            lblCustomerDetails.Size = new Size(135, 21);
            lblCustomerDetails.TabIndex = 14;
            lblCustomerDetails.Text = "Customer Details";
            // 
            // label2
            // 
            label2.AccessibleDescription = "lblOutput";
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(424, 246);
            label2.Name = "label2";
            label2.Size = new Size(0, 17);
            label2.TabIndex = 15;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(424, 120);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(97, 15);
            lblCustomerName.TabIndex = 16;
            lblCustomerName.Text = "Customer Name:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(548, 112);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(185, 23);
            txtCustomerName.TabIndex = 17;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(430, 166);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(91, 15);
            lblPhoneNumber.TabIndex = 18;
            lblPhoneNumber.Text = "Phone Number:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(548, 158);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(185, 23);
            txtPhoneNumber.TabIndex = 19;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(548, 203);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(75, 23);
            btnReturn.TabIndex = 20;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnRent
            // 
            btnRent.Location = new Point(658, 203);
            btnRent.Name = "btnRent";
            btnRent.Size = new Size(75, 23);
            btnRent.TabIndex = 22;
            btnRent.Text = "Rent";
            btnRent.UseVisualStyleBackColor = true;
            btnRent.Click += btnRent_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 509);
            Controls.Add(btnRent);
            Controls.Add(btnReturn);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtCustomerName);
            Controls.Add(lblCustomerName);
            Controls.Add(label2);
            Controls.Add(lblCustomerDetails);
            Controls.Add(lblOutput);
            Controls.Add(lstCars);
            Controls.Add(txtModel);
            Controls.Add(txtCategory);
            Controls.Add(txtDailyRate);
            Controls.Add(btnClear);
            Controls.Add(lblModel);
            Controls.Add(lblCategory);
            Controls.Add(lblDailyRate);
            Controls.Add(lblRegistredCars);
            Controls.Add(lblPlate);
            Controls.Add(txtPlate);
            Controls.Add(btnAddCar);
            Controls.Add(label1);
            Name = "Form1";
            Text = "CarRegistration";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAddCar;
        private TextBox txtPlate;
        private Label lblPlate;
        private Label lblRegistredCars;
        private Label lblDailyRate;
        private Label lblCategory;
        private Label lblModel;
        private Button btnClear;
        private TextBox txtDailyRate;
        private TextBox txtCategory;
        private TextBox txtModel;
        private ListBox lstCars;
        private Label lblOutput;
        private Label lblCustomerDetails;
        private Label label2;
        private Label lblCustomerName;
        private TextBox txtCustomerName;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Button btnReturn;
        private Button btnRent;
    }
}
