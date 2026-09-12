namespace SarasaviLibrarySystem
{
    partial class ReservationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.btnCancelReservation = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.pnlBookInfo = new System.Windows.Forms.Panel();
            this.lblCopiesAvailability = new System.Windows.Forms.Label();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.btnCheckBook = new System.Windows.Forms.Button();
            this.txtBookNumber = new System.Windows.Forms.TextBox();
            this.lblBookNumber = new System.Windows.Forms.Label();
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.btnCheckUser = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblFormHeader = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlBookInfo.SuspendLayout();
            this.pnlUserInfo.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.SuspendLayout();
            
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1184, 70);
            this.pnlHeader.TabIndex = 0;
            
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(20, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "← Dashboard";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(140, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 30);
            this.lblTitle.Text = "Book Reservation & Waitlist";
            
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlForm.Controls.Add(this.btnCancelReservation);
            this.pnlForm.Controls.Add(this.btnReserve);
            this.pnlForm.Controls.Add(this.pnlBookInfo);
            this.pnlForm.Controls.Add(this.btnCheckBook);
            this.pnlForm.Controls.Add(this.txtBookNumber);
            this.pnlForm.Controls.Add(this.lblBookNumber);
            this.pnlForm.Controls.Add(this.pnlUserInfo);
            this.pnlForm.Controls.Add(this.btnCheckUser);
            this.pnlForm.Controls.Add(this.txtUserID);
            this.pnlForm.Controls.Add(this.lblUserID);
            this.pnlForm.Controls.Add(this.lblFormHeader);
            this.pnlForm.Location = new System.Drawing.Point(20, 90);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(400, 585);
            this.pnlForm.TabIndex = 1;
            
            this.lblFormHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFormHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.lblFormHeader.Location = new System.Drawing.Point(20, 15);
            this.lblFormHeader.Name = "lblFormHeader";
            this.lblFormHeader.Size = new System.Drawing.Size(360, 25);
            this.lblFormHeader.Text = "Add to Reservation Queue";
            
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUserID.ForeColor = System.Drawing.Color.White;
            this.lblUserID.Location = new System.Drawing.Point(20, 55);
            this.lblUserID.Text = "Member User ID";
            
            this.txtUserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUserID.ForeColor = System.Drawing.Color.White;
            this.txtUserID.Location = new System.Drawing.Point(20, 75);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(250, 25);
            this.txtUserID.TabIndex = 1;
            
            this.btnCheckUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCheckUser.FlatAppearance.BorderSize = 0;
            this.btnCheckUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckUser.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCheckUser.ForeColor = System.Drawing.Color.White;
            this.btnCheckUser.Location = new System.Drawing.Point(280, 75);
            this.btnCheckUser.Name = "btnCheckUser";
            this.btnCheckUser.Size = new System.Drawing.Size(100, 25);
            this.btnCheckUser.TabIndex = 2;
            this.btnCheckUser.Text = "Verify User";
            this.btnCheckUser.UseVisualStyleBackColor = false;
            this.btnCheckUser.Click += new System.EventHandler(this.btnCheckUser_Click);
            
            this.pnlUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlUserInfo.Controls.Add(this.lblMemberName);
            this.pnlUserInfo.Location = new System.Drawing.Point(20, 110);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Size = new System.Drawing.Size(360, 40);
            this.pnlUserInfo.TabIndex = 3;
            
            this.lblMemberName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMemberName.ForeColor = System.Drawing.Color.White;
            this.lblMemberName.Location = new System.Drawing.Point(12, 10);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(335, 20);
            this.lblMemberName.Text = "Member: Not verified";
            
            this.lblBookNumber.AutoSize = true;
            this.lblBookNumber.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBookNumber.ForeColor = System.Drawing.Color.White;
            this.lblBookNumber.Location = new System.Drawing.Point(20, 165);
            this.lblBookNumber.Text = "Book Title Number (e.g. S0001)";
            
            this.txtBookNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtBookNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBookNumber.ForeColor = System.Drawing.Color.White;
            this.txtBookNumber.Location = new System.Drawing.Point(20, 185);
            this.txtBookNumber.Name = "txtBookNumber";
            this.txtBookNumber.Size = new System.Drawing.Size(250, 25);
            this.txtBookNumber.TabIndex = 4;
             
            this.btnCheckBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCheckBook.FlatAppearance.BorderSize = 0;
            this.btnCheckBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckBook.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCheckBook.ForeColor = System.Drawing.Color.White;
            this.btnCheckBook.Location = new System.Drawing.Point(280, 185);
            this.btnCheckBook.Name = "btnCheckBook";
            this.btnCheckBook.Size = new System.Drawing.Size(100, 25);
            this.btnCheckBook.TabIndex = 5;
            this.btnCheckBook.Text = "Verify Book";
            this.btnCheckBook.UseVisualStyleBackColor = false;
            this.btnCheckBook.Click += new System.EventHandler(this.btnCheckBook_Click);
            
            this.pnlBookInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlBookInfo.Controls.Add(this.lblCopiesAvailability);
            this.pnlBookInfo.Controls.Add(this.lblBookTitle);
            this.pnlBookInfo.Location = new System.Drawing.Point(20, 220);
            this.pnlBookInfo.Name = "pnlBookInfo";
            this.pnlBookInfo.Size = new System.Drawing.Size(360, 60);
            this.pnlBookInfo.TabIndex = 6;
            
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookTitle.ForeColor = System.Drawing.Color.White;
            this.lblBookTitle.Location = new System.Drawing.Point(12, 10);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(335, 20);
            this.lblBookTitle.Text = "Title: Not verified";
           
            this.lblCopiesAvailability.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCopiesAvailability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblCopiesAvailability.Location = new System.Drawing.Point(12, 32);
            this.lblCopiesAvailability.Name = "lblCopiesAvailability";
            this.lblCopiesAvailability.Size = new System.Drawing.Size(335, 20);
            this.lblCopiesAvailability.Text = "Availability: -";
            
            this.btnReserve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnReserve.FlatAppearance.BorderSize = 0;
            this.btnReserve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserve.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReserve.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnReserve.Location = new System.Drawing.Point(20, 310);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(360, 42);
            this.btnReserve.TabIndex = 7;
            this.btnReserve.Text = "RESERVE BOOK (ADD TO QUEUE)";
            this.btnReserve.UseVisualStyleBackColor = false;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            
            this.btnCancelReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelReservation.FlatAppearance.BorderSize = 0;
            this.btnCancelReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelReservation.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelReservation.ForeColor = System.Drawing.Color.White;
            this.btnCancelReservation.Location = new System.Drawing.Point(20, 515);
            this.btnCancelReservation.Name = "btnCancelReservation";
            this.btnCancelReservation.Size = new System.Drawing.Size(360, 38);
            this.btnCancelReservation.TabIndex = 8;
            this.btnCancelReservation.Text = "CANCEL SELECTED RESERVATION";
            this.btnCancelReservation.UseVisualStyleBackColor = false;
            this.btnCancelReservation.Click += new System.EventHandler(this.btnCancelReservation_Click);
           
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlGrid.Controls.Add(this.txtSearch);
            this.pnlGrid.Controls.Add(this.lblSearch);
            this.pnlGrid.Controls.Add(this.dgvReservations);
            this.pnlGrid.Location = new System.Drawing.Point(440, 90);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(720, 585);
            this.pnlGrid.TabIndex = 2;
            
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Text = "Search Queue by Book Title, Book ID, or Member Name:";
            
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(340, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(360, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            
            this.dgvReservations.AllowUserToAddRows = false;
            this.dgvReservations.AllowUserToDeleteRows = false;
            this.dgvReservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservations.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvReservations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Location = new System.Drawing.Point(20, 55);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.Size = new System.Drawing.Size(680, 510);
            this.dgvReservations.TabIndex = 2;
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1184, 700);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservations Management";
            this.Load += new System.EventHandler(this.ReservationForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlBookInfo.ResumeLayout(false);
            this.pnlUserInfo.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormHeader;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Button btnCheckUser;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.Label lblBookNumber;
        private System.Windows.Forms.TextBox txtBookNumber;
        private System.Windows.Forms.Button btnCheckBook;
        private System.Windows.Forms.Panel pnlBookInfo;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblCopiesAvailability;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Button btnCancelReservation;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvReservations;
    }
}