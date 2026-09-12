namespace SarasaviLibrarySystem
{
    partial class ReturnProcessingForm
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
            this.pnlReservationAlert = new System.Windows.Forms.Panel();
            this.lblAlertMsg = new System.Windows.Forms.Label();
            this.lblAlertTitle = new System.Windows.Forms.Label();
            this.btnAcceptReturn = new System.Windows.Forms.Button();
            this.pnlLoanDetails = new System.Windows.Forms.Panel();
            this.lblOverdueStatus = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblIssuedDate = new System.Windows.Forms.Label();
            this.lblBorrower = new System.Windows.Forms.Label();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.btnFindLoan = new System.Windows.Forms.Button();
            this.txtCopyNumber = new System.Windows.Forms.TextBox();
            this.lblCopyNumber = new System.Windows.Forms.Label();
            this.lblFormHeader = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvReturnedBooks = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlReservationAlert.SuspendLayout();
            this.pnlLoanDetails.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedBooks)).BeginInit();
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
            this.lblTitle.Text = "Book Return Processing";
            
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlForm.Controls.Add(this.pnlReservationAlert);
            this.pnlForm.Controls.Add(this.btnAcceptReturn);
            this.pnlForm.Controls.Add(this.pnlLoanDetails);
            this.pnlForm.Controls.Add(this.btnFindLoan);
            this.pnlForm.Controls.Add(this.txtCopyNumber);
            this.pnlForm.Controls.Add(this.lblCopyNumber);
            this.pnlForm.Controls.Add(this.lblFormHeader);
            this.pnlForm.Location = new System.Drawing.Point(20, 90);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(410, 585);
            this.pnlForm.TabIndex = 1;
            
            this.lblFormHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFormHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.lblFormHeader.Location = new System.Drawing.Point(20, 15);
            this.lblFormHeader.Name = "lblFormHeader";
            this.lblFormHeader.Size = new System.Drawing.Size(370, 25);
            this.lblFormHeader.Text = "Process Book Return";
            
            this.lblCopyNumber.AutoSize = true;
            this.lblCopyNumber.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCopyNumber.ForeColor = System.Drawing.Color.White;
            this.lblCopyNumber.Location = new System.Drawing.Point(20, 50);
            this.lblCopyNumber.Text = "Book Copy Number";
            
            this.txtCopyNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtCopyNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCopyNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCopyNumber.ForeColor = System.Drawing.Color.White;
            this.txtCopyNumber.Location = new System.Drawing.Point(20, 70);
            this.txtCopyNumber.Name = "txtCopyNumber";
            this.txtCopyNumber.Size = new System.Drawing.Size(260, 25);
            this.txtCopyNumber.TabIndex = 1;
            
            this.btnFindLoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnFindLoan.FlatAppearance.BorderSize = 0;
            this.btnFindLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindLoan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnFindLoan.ForeColor = System.Drawing.Color.White;
            this.btnFindLoan.Location = new System.Drawing.Point(290, 70);
            this.btnFindLoan.Name = "btnFindLoan";
            this.btnFindLoan.Size = new System.Drawing.Size(100, 25);
            this.btnFindLoan.TabIndex = 2;
            this.btnFindLoan.Text = "Find Loan";
            this.btnFindLoan.UseVisualStyleBackColor = false;
            this.btnFindLoan.Click += new System.EventHandler(this.btnFindLoan_Click);
            
            this.pnlLoanDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlLoanDetails.Controls.Add(this.lblOverdueStatus);
            this.pnlLoanDetails.Controls.Add(this.lblDueDate);
            this.pnlLoanDetails.Controls.Add(this.lblIssuedDate);
            this.pnlLoanDetails.Controls.Add(this.lblBorrower);
            this.pnlLoanDetails.Controls.Add(this.lblBookTitle);
            this.pnlLoanDetails.Location = new System.Drawing.Point(20, 110);
            this.pnlLoanDetails.Name = "pnlLoanDetails";
            this.pnlLoanDetails.Size = new System.Drawing.Size(370, 190);
            this.pnlLoanDetails.TabIndex = 3;
            
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBookTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.lblBookTitle.Location = new System.Drawing.Point(15, 12);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(340, 25);
            this.lblBookTitle.Text = "Book Title: -";
             
            this.lblBorrower.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBorrower.ForeColor = System.Drawing.Color.White;
            this.lblBorrower.Location = new System.Drawing.Point(15, 45);
            this.lblBorrower.Name = "lblBorrower";
            this.lblBorrower.Size = new System.Drawing.Size(340, 25);
            this.lblBorrower.Text = "Borrower: -";
            
            this.lblIssuedDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIssuedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblIssuedDate.Location = new System.Drawing.Point(15, 80);
            this.lblIssuedDate.Name = "lblIssuedDate";
            this.lblIssuedDate.Size = new System.Drawing.Size(340, 25);
            this.lblIssuedDate.Text = "Issued Date: -";
           
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDueDate.Location = new System.Drawing.Point(15, 115);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(340, 25);
            this.lblDueDate.Text = "Due Date: -";
            
            this.lblOverdueStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOverdueStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblOverdueStatus.Location = new System.Drawing.Point(15, 150);
            this.lblOverdueStatus.Name = "lblOverdueStatus";
            this.lblOverdueStatus.Size = new System.Drawing.Size(340, 25);
            this.lblOverdueStatus.Text = "Status: -";
            
            this.pnlReservationAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlReservationAlert.Controls.Add(this.lblAlertMsg);
            this.pnlReservationAlert.Controls.Add(this.lblAlertTitle);
            this.pnlReservationAlert.Location = new System.Drawing.Point(20, 315);
            this.pnlReservationAlert.Name = "pnlReservationAlert";
            this.pnlReservationAlert.Size = new System.Drawing.Size(370, 140);
            this.pnlReservationAlert.TabIndex = 4;
           
            this.lblAlertTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAlertTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.lblAlertTitle.Location = new System.Drawing.Point(15, 10);
            this.lblAlertTitle.Name = "lblAlertTitle";
            this.lblAlertTitle.Size = new System.Drawing.Size(340, 20);
            this.lblAlertTitle.Text = "📌 Reservation Notice";
           
            this.lblAlertMsg.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblAlertMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblAlertMsg.Location = new System.Drawing.Point(15, 35);
            this.lblAlertMsg.Name = "lblAlertMsg";
            this.lblAlertMsg.Size = new System.Drawing.Size(340, 95);
            this.lblAlertMsg.Text = "When a book copy is returned, the system automatically checks for reservations on" +
    " this Title.";
           
            this.btnAcceptReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.btnAcceptReturn.Enabled = false;
            this.btnAcceptReturn.FlatAppearance.BorderSize = 0;
            this.btnAcceptReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptReturn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAcceptReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnAcceptReturn.Location = new System.Drawing.Point(20, 480);
            this.btnAcceptReturn.Name = "btnAcceptReturn";
            this.btnAcceptReturn.Size = new System.Drawing.Size(370, 45);
            this.btnAcceptReturn.TabIndex = 5;
            this.btnAcceptReturn.Text = "CONFIRM && ACCEPT RETURN";
            this.btnAcceptReturn.UseVisualStyleBackColor = false;
            this.btnAcceptReturn.Click += new System.EventHandler(this.btnAcceptReturn_Click);
           
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlGrid.Controls.Add(this.txtSearch);
            this.pnlGrid.Controls.Add(this.lblSearch);
            this.pnlGrid.Controls.Add(this.dgvReturnedBooks);
            this.pnlGrid.Location = new System.Drawing.Point(450, 90);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(710, 585);
            this.pnlGrid.TabIndex = 2;
           
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Text = "Search Loan History by User, Copy or Book Title:";
           
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(300, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(390, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            
            this.dgvReturnedBooks.AllowUserToAddRows = false;
            this.dgvReturnedBooks.AllowUserToDeleteRows = false;
            this.dgvReturnedBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReturnedBooks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvReturnedBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReturnedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnedBooks.Location = new System.Drawing.Point(20, 55);
            this.dgvReturnedBooks.Name = "dgvReturnedBooks";
            this.dgvReturnedBooks.ReadOnly = true;
            this.dgvReturnedBooks.Size = new System.Drawing.Size(670, 510);
            this.dgvReturnedBooks.TabIndex = 2;
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1184, 700);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReturnProcessingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Return Processing";
            this.Load += new System.EventHandler(this.ReturnProcessingForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlReservationAlert.ResumeLayout(false);
            this.pnlLoanDetails.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedBooks)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormHeader;
        private System.Windows.Forms.Label lblCopyNumber;
        private System.Windows.Forms.TextBox txtCopyNumber;
        private System.Windows.Forms.Button btnFindLoan;
        private System.Windows.Forms.Panel pnlLoanDetails;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblBorrower;
        private System.Windows.Forms.Label lblIssuedDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblOverdueStatus;
        private System.Windows.Forms.Panel pnlReservationAlert;
        private System.Windows.Forms.Label lblAlertTitle;
        private System.Windows.Forms.Label lblAlertMsg;
        private System.Windows.Forms.Button btnAcceptReturn;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvReturnedBooks;
    }
}