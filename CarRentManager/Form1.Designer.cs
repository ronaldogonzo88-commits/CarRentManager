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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(316, 58);
            label1.Name = "label1";
            label1.Size = new Size(152, 25);
            label1.TabIndex = 0;
            label1.Text = "Car Registration";
            // 
            // btnAddCar
            // 
            btnAddCar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCar.ForeColor = SystemColors.ActiveCaptionText;
            btnAddCar.Location = new Point(345, 283);
            btnAddCar.Name = "btnAddCar";
            btnAddCar.Size = new Size(62, 23);
            btnAddCar.TabIndex = 1;
            btnAddCar.Text = "Add Car";
            btnAddCar.UseVisualStyleBackColor = true;
            // 
            // txtPlate
            // 
            txtPlate.Location = new Point(304, 103);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(185, 23);
            txtPlate.TabIndex = 2;
            // 
            // lblPlate
            // 
            lblPlate.AutoSize = true;
            lblPlate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlate.Location = new Point(231, 111);
            lblPlate.Name = "lblPlate";
            lblPlate.Size = new Size(41, 17);
            lblPlate.TabIndex = 3;
            lblPlate.Text = "Plate:";
            // 
            // lblRegistredCars
            // 
            lblRegistredCars.AutoSize = true;
            lblRegistredCars.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegistredCars.Location = new Point(231, 331);
            lblRegistredCars.Name = "lblRegistredCars";
            lblRegistredCars.Size = new Size(102, 17);
            lblRegistredCars.TabIndex = 4;
            lblRegistredCars.Text = "Registered Cars";
            // 
            // lblDailyRate
            // 
            lblDailyRate.AutoSize = true;
            lblDailyRate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDailyRate.Location = new Point(231, 247);
            lblDailyRate.Name = "lblDailyRate";
            lblDailyRate.Size = new Size(71, 17);
            lblDailyRate.TabIndex = 5;
            lblDailyRate.Text = "Daily Rate:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(231, 204);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(67, 17);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Category:";
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModel.Location = new Point(231, 151);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(49, 17);
            lblModel.TabIndex = 7;
            lblModel.Text = "Model:";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(426, 283);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(63, 23);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // txtDailyRate
            // 
            txtDailyRate.Location = new Point(304, 239);
            txtDailyRate.Name = "txtDailyRate";
            txtDailyRate.Size = new Size(185, 23);
            txtDailyRate.TabIndex = 9;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(304, 196);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(185, 23);
            txtCategory.TabIndex = 10;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(304, 143);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(185, 23);
            txtModel.TabIndex = 11;
            // 
            // lstCars
            // 
            lstCars.FormattingEnabled = true;
            lstCars.ItemHeight = 15;
            lstCars.Location = new Point(231, 365);
            lstCars.Name = "lstCars";
            lstCars.Size = new Size(258, 49);
            lstCars.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 486);
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
    }
}
