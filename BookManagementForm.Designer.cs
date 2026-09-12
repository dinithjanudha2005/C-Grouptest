namespace SarasaviLibrarySystem
{
    partial class BookManagementForm
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
            this.chkReferenceOnly = new System.Windows.Forms.CheckBox();
            this.numCopies = new System.Windows.Forms.NumericUpDown();
            this.lblCopies = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblISBN = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.txtBookNumber = new System.Windows.Forms.TextBox();
            this.lblBookNumber = new System.Windows.Forms.Label();
            this.cmbClassification = new System.Windows.Forms.ComboBox();
            this.lblClassification = new System.Windows.Forms.Label();
            this.lblFormHeader = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
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
            this.lblTitle.Text = "Book & Copies Management";
            
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlForm.Controls.Add(this.chkReferenceOnly);
            this.pnlForm.Controls.Add(this.numCopies);
            this.pnlForm.Controls.Add(this.lblCopies);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.txtISBN);
            this.pnlForm.Controls.Add(this.lblISBN);
            this.pnlForm.Controls.Add(this.txtAuthor);
            this.pnlForm.Controls.Add(this.lblAuthor);
            this.pnlForm.Controls.Add(this.txtBookTitle);
            this.pnlForm.Controls.Add(this.lblBookTitle);
            this.pnlForm.Controls.Add(this.txtBookNumber);
            this.pnlForm.Controls.Add(this.lblBookNumber);
            this.pnlForm.Controls.Add(this.cmbClassification);
            this.pnlForm.Controls.Add(this.lblClassification);
            this.pnlForm.Controls.Add(this.lblFormHeader);
            this.pnlForm.Location = new System.Drawing.Point(20, 90);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(360, 580);
            this.pnlForm.TabIndex = 1;
            
            this.lblFormHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFormHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.lblFormHeader.Location = new System.Drawing.Point(20, 15);
            this.lblFormHeader.Name = "lblFormHeader";
            this.lblFormHeader.Size = new System.Drawing.Size(320, 25);
            this.lblFormHeader.Text = "Register New Book";
            
            this.lblClassification.AutoSize = true;
            this.lblClassification.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClassification.ForeColor = System.Drawing.Color.White;
            this.lblClassification.Location = new System.Drawing.Point(20, 55);
            this.lblClassification.Text = "Classification (Category)";
            
            this.cmbClassification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.cmbClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClassification.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbClassification.ForeColor = System.Drawing.Color.White;
            this.cmbClassification.FormattingEnabled = true;
            this.cmbClassification.Location = new System.Drawing.Point(20, 77);
            this.cmbClassification.Name = "cmbClassification";
            this.cmbClassification.Size = new System.Drawing.Size(320, 25);
            this.cmbClassification.TabIndex = 1;
            this.cmbClassification.SelectedIndexChanged += new System.EventHandler(this.cmbClassification_SelectedIndexChanged);
           
            this.lblBookNumber.AutoSize = true;
            this.lblBookNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBookNumber.ForeColor = System.Drawing.Color.White;
            this.lblBookNumber.Location = new System.Drawing.Point(20, 115);
            this.lblBookNumber.Text = "Book Number (Auto X9999)";
            
            this.txtBookNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtBookNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtBookNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.txtBookNumber.Location = new System.Drawing.Point(20, 137);
            this.txtBookNumber.Name = "txtBookNumber";
            this.txtBookNumber.ReadOnly = true;
            this.txtBookNumber.Size = new System.Drawing.Size(320, 25);
            this.txtBookNumber.TabIndex = 2;
            
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBookTitle.ForeColor = System.Drawing.Color.White;
            this.lblBookTitle.Location = new System.Drawing.Point(20, 175);
            this.lblBookTitle.Text = "Book Title";
            
            this.txtBookTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtBookTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBookTitle.ForeColor = System.Drawing.Color.White;
            this.txtBookTitle.Location = new System.Drawing.Point(20, 197);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(320, 25);
            this.txtBookTitle.TabIndex = 3;
            
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAuthor.ForeColor = System.Drawing.Color.White;
            this.lblAuthor.Location = new System.Drawing.Point(20, 235);
            this.lblAuthor.Text = "Author";
             
            this.txtAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAuthor.ForeColor = System.Drawing.Color.White;
            this.txtAuthor.Location = new System.Drawing.Point(20, 257);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(320, 25);
            this.txtAuthor.TabIndex = 4;
             
            this.lblISBN.AutoSize = true;
            this.lblISBN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblISBN.ForeColor = System.Drawing.Color.White;
            this.lblISBN.Location = new System.Drawing.Point(20, 295);
            this.lblISBN.Text = "ISBN";
            
            this.txtISBN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtISBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtISBN.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtISBN.ForeColor = System.Drawing.Color.White;
            this.txtISBN.Location = new System.Drawing.Point(20, 317);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(320, 25);
            this.txtISBN.TabIndex = 5;
                        this.lblCopies.AutoSize = true;
            this.lblCopies.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCopies.ForeColor = System.Drawing.Color.White;
            this.lblCopies.Location = new System.Drawing.Point(20, 355);
            this.lblCopies.Text = "Number of Copies (Max 10)";
            
            this.numCopies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.numCopies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCopies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numCopies.ForeColor = System.Drawing.Color.White;
            this.numCopies.Location = new System.Drawing.Point(20, 377);
            this.numCopies.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numCopies.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCopies.Name = "numCopies";
            this.numCopies.Size = new System.Drawing.Size(320, 25);
            this.numCopies.TabIndex = 6;
            this.numCopies.Value = new decimal(new int[] { 1, 0, 0, 0 });
            
            this.chkReferenceOnly.AutoSize = true;
            this.chkReferenceOnly.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkReferenceOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.chkReferenceOnly.Location = new System.Drawing.Point(20, 420);
            this.chkReferenceOnly.Name = "chkReferenceOnly";
            this.chkReferenceOnly.Size = new System.Drawing.Size(185, 21);
            this.chkReferenceOnly.TabIndex = 7;
            this.chkReferenceOnly.Text = "Is Reference Only (No Loan)";
            this.chkReferenceOnly.UseVisualStyleBackColor = true;
       
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnSave.Location = new System.Drawing.Point(20, 470);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(320, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "SAVE BOOK && COPIES";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
           
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlGrid.Controls.Add(this.txtSearch);
            this.pnlGrid.Controls.Add(this.lblSearch);
            this.pnlGrid.Controls.Add(this.dgvBooks);
            this.pnlGrid.Location = new System.Drawing.Point(400, 90);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(760, 580);
            this.pnlGrid.TabIndex = 2;
       
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Text = "Search by Title, Author or Copy Number:";
           
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(270, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(470, 25);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
           
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(20, 55);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.Size = new System.Drawing.Size(720, 505);
            this.dgvBooks.TabIndex = 2;
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1184, 700);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BookManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Management";
            this.Load += new System.EventHandler(this.BookManagementForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCopies)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormHeader;
        private System.Windows.Forms.Label lblClassification;
        private System.Windows.Forms.ComboBox cmbClassification;
        private System.Windows.Forms.Label lblBookNumber;
        private System.Windows.Forms.TextBox txtBookNumber;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label lblCopies;
        private System.Windows.Forms.NumericUpDown numCopies;
        private System.Windows.Forms.CheckBox chkReferenceOnly;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvBooks;
    }
}