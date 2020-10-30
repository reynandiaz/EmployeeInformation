namespace EmployeeInformation
{
    partial class Employees
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMinPage = new System.Windows.Forms.Button();
            this.btnLessPage = new System.Windows.Forms.Button();
            this.btnAddPage = new System.Windows.Forms.Button();
            this.btnMaxPage = new System.Windows.Forms.Button();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtMaxPage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeCode,
            this.EmployeeName,
            this.DEPARTMENT,
            this.SECTION,
            this.Info});
            this.dataGridView1.Location = new System.Drawing.Point(12, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(791, 359);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.HeaderText = "EMPLOYEE ID";
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.Width = 120;
            // 
            // EmployeeName
            // 
            this.EmployeeName.HeaderText = "EMPLOYEE NAME";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Width = 250;
            // 
            // DEPARTMENT
            // 
            this.DEPARTMENT.HeaderText = "DEPARTMENT";
            this.DEPARTMENT.Name = "DEPARTMENT";
            this.DEPARTMENT.Width = 150;
            // 
            // SECTION
            // 
            this.SECTION.HeaderText = "SECTION";
            this.SECTION.Name = "SECTION";
            this.SECTION.Width = 150;
            // 
            // Info
            // 
            this.Info.HeaderText = "INFO";
            this.Info.Name = "Info";
            this.Info.Width = 50;
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(464, 14);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(210, 22);
            this.txtFilter.TabIndex = 26;
            this.txtFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(680, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(123, 25);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnMinPage
            // 
            this.btnMinPage.Location = new System.Drawing.Point(12, 14);
            this.btnMinPage.Name = "btnMinPage";
            this.btnMinPage.Size = new System.Drawing.Size(35, 23);
            this.btnMinPage.TabIndex = 31;
            this.btnMinPage.Text = "<<";
            this.btnMinPage.UseVisualStyleBackColor = true;
            this.btnMinPage.Click += new System.EventHandler(this.btnMinPage_Click);
            // 
            // btnLessPage
            // 
            this.btnLessPage.Location = new System.Drawing.Point(49, 14);
            this.btnLessPage.Name = "btnLessPage";
            this.btnLessPage.Size = new System.Drawing.Size(27, 23);
            this.btnLessPage.TabIndex = 32;
            this.btnLessPage.Text = "<";
            this.btnLessPage.UseVisualStyleBackColor = true;
            this.btnLessPage.Click += new System.EventHandler(this.btnLessPage_Click);
            // 
            // btnAddPage
            // 
            this.btnAddPage.Location = new System.Drawing.Point(142, 14);
            this.btnAddPage.Name = "btnAddPage";
            this.btnAddPage.Size = new System.Drawing.Size(27, 23);
            this.btnAddPage.TabIndex = 34;
            this.btnAddPage.Text = ">";
            this.btnAddPage.UseVisualStyleBackColor = true;
            this.btnAddPage.Click += new System.EventHandler(this.btnAddPage_Click);
            // 
            // btnMaxPage
            // 
            this.btnMaxPage.Location = new System.Drawing.Point(171, 14);
            this.btnMaxPage.Name = "btnMaxPage";
            this.btnMaxPage.Size = new System.Drawing.Size(35, 23);
            this.btnMaxPage.TabIndex = 33;
            this.btnMaxPage.Text = ">>";
            this.btnMaxPage.UseVisualStyleBackColor = true;
            this.btnMaxPage.Click += new System.EventHandler(this.btnMaxPage_Click);
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(78, 16);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(24, 20);
            this.txtPage.TabIndex = 35;
            this.txtPage.Leave += new System.EventHandler(this.txtPage_Leave);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 408);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(136, 29);
            this.btnPrint.TabIndex = 36;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtMaxPage
            // 
            this.txtMaxPage.Enabled = false;
            this.txtMaxPage.Location = new System.Drawing.Point(116, 16);
            this.txtMaxPage.Name = "txtMaxPage";
            this.txtMaxPage.Size = new System.Drawing.Size(24, 20);
            this.txtMaxPage.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "/";
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 449);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaxPage);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.btnAddPage);
            this.Controls.Add(this.btnMaxPage);
            this.Controls.Add(this.btnLessPage);
            this.Controls.Add(this.btnMinPage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Employees";
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.Employees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECTION;
        private System.Windows.Forms.DataGridViewButtonColumn Info;
        internal System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMinPage;
        private System.Windows.Forms.Button btnLessPage;
        private System.Windows.Forms.Button btnAddPage;
        private System.Windows.Forms.Button btnMaxPage;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtMaxPage;
        private System.Windows.Forms.Label label1;
    }
}