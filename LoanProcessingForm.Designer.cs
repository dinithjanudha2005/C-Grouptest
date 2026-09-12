namespace SarasaviLibrarySystem
{
    partial class LoanProcessingForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.pnlValidationAlert = new System.Windows.Forms.Panel();
            this.lblValidationStatus = new System.Windows.Forms.Label();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.txtLoanDate = new System.Windows.Forms.TextBox();
            this.lblLoanDate = new System.Windows.Forms.Label();
            this.pnlBookDetails = new System.Windows.Forms.Panel();
            this.lblBookType = new System.Windows.Forms.Label();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.btnCheckBook = new System.Windows.Forms.Button();
            this.txtCopyNumber = new System.Windows.Forms.TextBox();
            this.lblCopyNumber = new System.Windows.Forms.Label();
            this.pnlMemberDetails = new System.Windows.Forms.Panel();
            this.lblActiveLoansCount = new System.Windows.Forms.Label();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.btnCheckMember = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblFormHeader = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvActiveLoans = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlValidationAlert.SuspendLayout();
            this.pnlBookDetails.SuspendLayout();
            this.pnlMemberDetails.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).BeginInit();
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
            this.lblTitle.Text = "Book Loan (Issue) Processing";
           
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlForm.Controls.Add(this.btnCancel);
            this.pnlForm.Controls.Add(this.btnAccept);
            this.pnlForm.Controls.Add(this.pnlValidationAlert);
            this.pnlForm.Controls.Add(this.txtDueDate);
            this.pnlForm.Controls.Add(this.lblDueDate);
            this.pnlForm.Controls.Add(this.txtLoanDate);
            this.pnlForm.Controls.Add(this.lblLoanDate);
            this.pnlForm.Controls.Add(this.pnlBookDetails);
            this.pnlForm.Controls.Add(this.btnCheckBook);
            this.pnlForm.Controls.Add(this.txtCopyNumber);
            this.pnlForm.Controls.Add(this.lblCopyNumber);
            this.pnlForm.Controls.Add(this.pnlMemberDetails);
            this.pnlForm.Controls.Add(this.btnCheckMember);
            this.pnlForm.Controls.Add(this.txtUserID);
            this.pnlForm.Controls.Add(this.lblUserID);
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
            this.lblFormHeader.Text = "Issue Book to Member";
           
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUserID.ForeColor = System.Drawing.Color.White;
            this.lblUserID.Location = new System.Drawing.Point(20, 48);
            this.lblUserID.Text = "Member User ID";
          
            this.txtUserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUserID.ForeColor = System.Drawing.Color.White;
            this.txtUserID.Location = new System.Drawing.Point(20, 68);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(260, 25);
            this.txtUserID.TabIndex = 1;
           
            this.btnCheckMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCheckMember.FlatAppearance.BorderSize = 0;
            this.btnCheckMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckMember.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCheckMember.ForeColor = System.Drawing.Color.White;
            this.btnCheckMember.Location = new System.Drawing.Point(290, 68);
            this.btnCheckMember.Name = "btnCheckMember";
            this.btnCheckMember.Size = new System.Drawing.Size(100, 25);
            this.btnCheckMember.TabIndex = 2;
            this.btnCheckMember.Text = "Verify User";
            this.btnCheckMember.UseVisualStyleBackColor = false;
            this.btnCheckMember.Click += new System.EventHandler(this.btnCheckMember_Click);
           
            this.pnlMemberDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlMemberDetails.Controls.Add(this.lblActiveLoansCount);
            this.pnlMemberDetails.Controls.Add(this.lblMemberName);
            this.pnlMemberDetails.Location = new System.Drawing.Point(20, 100);
            this.pnlMemberDetails.Name = "pnlMemberDetails";
            this.pnlMemberDetails.Size = new System.Drawing.Size(370, 50);
            this.pnlMemberDetails.TabIndex = 3;
          
            this.lblMemberName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMemberName.ForeColor = System.Drawing.Color.White;
            this.lblMemberName.Location = new System.Drawing.Point(10, 8);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(350, 18);
            this.lblMemberName.Text = "Member: Not verified";
           
            this.lblActiveLoansCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblActiveLoansCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblActiveLoansCount.Location = new System.Drawing.Point(10, 28);
            this.lblActiveLoansCount.Name = "lblActiveLoansCount";
            this.lblActiveLoansCount.Size = new System.Drawing.Size(350, 18);
            this.lblActiveLoansCount.Text = "Current Active Loans: 0 / 5";
           
            this.lblCopyNumber.AutoSize = true;
            this.lblCopyNumber.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCopyNumber.ForeColor = System.Drawing.Color.White;
            this.lblCopyNumber.Location = new System.Drawing.Point(20, 160);
            this.lblCopyNumber.Text = "Book Copy Number";
           
            this.txtCopyNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtCopyNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCopyNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCopyNumber.ForeColor = System.Drawing.Color.White;
            this.txtCopyNumber.Location = new System.Drawing.Point(20, 180);
            this.txtCopyNumber.Name = "txtCopyNumber";
            this.txtCopyNumber.Size = new System.Drawing.Size(260, 25);
            this.txtCopyNumber.TabIndex = 4;
           
            this.btnCheckBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCheckBook.FlatAppearance.BorderSize = 0;
            this.btnCheckBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckBook.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCheckBook.ForeColor = System.Drawing.Color.White;
            this.btnCheckBook.Location = new System.Drawing.Point(290, 180);
            this.btnCheckBook.Name = "btnCheckBook";
            this.btnCheckBook.Size = new System.Drawing.Size(100, 25);
            this.btnCheckBook.TabIndex = 5;
            this.btnCheckBook.Text = "Verify Copy";
            this.btnCheckBook.UseVisualStyleBackColor = false;
            this.btnCheckBook.Click += new System.EventHandler(this.btnCheckBook_Click);
           
            this.pnlBookDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlBookDetails.Controls.Add(this.lblBookType);
            this.pnlBookDetails.Controls.Add(this.lblBookTitle);
            this.pnlBookDetails.Location = new System.Drawing.Point(20, 212);
            this.pnlBookDetails.Name = "pnlBookDetails";
            this.pnlBookDetails.Size = new System.Drawing.Size(370, 50);
            this.pnlBookDetails.TabIndex = 6;
            
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookTitle.ForeColor = System.Drawing.Color.White;
            this.lblBookTitle.Location = new System.Drawing.Point(10, 8);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(350, 18);
            this.lblBookTitle.Text = "Book: Not verified";
            
            this.lblBookType.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBookType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblBookType.Location = new System.Drawing.Point(10, 28);
            this.lblBookType.Name = "lblBookType";
            this.lblBookType.Size = new System.Drawing.Size(350, 18);
            this.lblBookType.Text = "Type: - | Status: -";
           
            this.lblLoanDate.AutoSize = true;
            this.lblLoanDate.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLoanDate.ForeColor = System.Drawing.Color.White;
            this.lblLoanDate.Location = new System.Drawing.Point(20, 275);
            this.lblLoanDate.Text = "Loan Date (Today)";
           
            this.txtLoanDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtLoanDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoanDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtLoanDate.ForeColor = System.Drawing.Color.White;
            this.txtLoanDate.Location = new System.Drawing.Point(20, 295);
            this.txtLoanDate.Name = "txtLoanDate";
            this.txtLoanDate.ReadOnly = true;
            this.txtLoanDate.Size = new System.Drawing.Size(170, 24);
            this.txtLoanDate.TabIndex = 7;
           
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.lblDueDate.Location = new System.Drawing.Point(210, 275);
            this.lblDueDate.Text = "Due Date (+2 Weeks)";
           
            this.txtDueDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtDueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDueDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.txtDueDate.Location = new System.Drawing.Point(210, 295);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(180, 24);
            this.txtDueDate.TabIndex = 8;
           
            this.pnlValidationAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlValidationAlert.Controls.Add(this.lblValidationStatus);
            this.pnlValidationAlert.Location = new System.Drawing.Point(20, 335);
            this.pnlValidationAlert.Name = "pnlValidationAlert";
            this.pnlValidationAlert.Size = new System.Drawing.Size(370, 75);
            this.pnlValidationAlert.TabIndex = 9;
           
            this.lblValidationStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblValidationStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblValidationStatus.Location = new System.Drawing.Point(10, 10);
            this.lblValidationStatus.Name = "lblValidationStatus";
            this.lblValidationStatus.Size = new System.Drawing.Size(350, 55);
            this.lblValidationStatus.Text = "Please verify Member and Book Copy to check loan eligibility.";
            this.lblValidationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnAccept.Enabled = false;
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(20, 435);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(370, 40);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "ACCEPT LOAN";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancel.Location = new System.Drawing.Point(20, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(370, 35);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel Request";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlGrid.Controls.Add(this.txtSearch);
            this.pnlGrid.Controls.Add(this.lblSearch);
            this.pnlGrid.Controls.Add(this.dgvActiveLoans);
            this.pnlGrid.Location = new System.Drawing.Point(450, 90);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(710, 585);
            this.pnlGrid.TabIndex = 2;
            
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Text = "Search Active Loans by User, Copy or Book Title:";
           
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(300, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(390, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
           
            this.dgvActiveLoans.AllowUserToAddRows = false;
            this.dgvActiveLoans.AllowUserToDeleteRows = false;
            this.dgvActiveLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActiveLoans.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvActiveLoans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActiveLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveLoans.Location = new System.Drawing.Point(20, 55);
            this.dgvActiveLoans.Name = "dgvActiveLoans";
            this.dgvActiveLoans.ReadOnly = true;
            this.dgvActiveLoans.Size = new System.Drawing.Size(670, 510);
            this.dgvActiveLoans.TabIndex = 2;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1184, 700);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoanProcessingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan Processing";
            this.Load += new System.EventHandler(this.LoanProcessingForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlValidationAlert.ResumeLayout(false);
            this.pnlBookDetails.ResumeLayout(false);
            this.pnlMemberDetails.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLoans)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormHeader;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Button btnCheckMember;
        private System.Windows.Forms.Panel pnlMemberDetails;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.Label lblActiveLoansCount;
        private System.Windows.Forms.Label lblCopyNumber;
        private System.Windows.Forms.TextBox txtCopyNumber;
        private System.Windows.Forms.Button btnCheckBook;
        private System.Windows.Forms.Panel pnlBookDetails;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblBookType;
        private System.Windows.Forms.Label lblLoanDate;
        private System.Windows.Forms.TextBox txtLoanDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.Panel pnlValidationAlert;
        private System.Windows.Forms.Label lblValidationStatus;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvActiveLoans;
    }
}