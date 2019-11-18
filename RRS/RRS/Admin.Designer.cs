namespace RRS
{
    partial class Admin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewAvailableTripsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAvailableTripsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelTripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookReservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelReservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(0, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "*********";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Administrator page";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAvailableTripsToolStripMenuItem,
            this.bookReservationsToolStripMenuItem,
            this.cancelReservationsToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(4, 75);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(50);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(15, 4, 0, 4);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(179, 375);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewAvailableTripsToolStripMenuItem
            // 
            this.viewAvailableTripsToolStripMenuItem.AutoToolTip = true;
            this.viewAvailableTripsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAvailableTripsToolStripMenuItem1,
            this.addNewTripToolStripMenuItem,
            this.cancelTripToolStripMenuItem});
            this.viewAvailableTripsToolStripMenuItem.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAvailableTripsToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.viewAvailableTripsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.viewAvailableTripsToolStripMenuItem.Name = "viewAvailableTripsToolStripMenuItem";
            this.viewAvailableTripsToolStripMenuItem.Size = new System.Drawing.Size(163, 33);
            this.viewAvailableTripsToolStripMenuItem.Text = "Trips";
            // 
            // viewAvailableTripsToolStripMenuItem1
            // 
            this.viewAvailableTripsToolStripMenuItem1.ForeColor = System.Drawing.Color.Navy;
            this.viewAvailableTripsToolStripMenuItem1.Name = "viewAvailableTripsToolStripMenuItem1";
            this.viewAvailableTripsToolStripMenuItem1.Size = new System.Drawing.Size(324, 34);
            this.viewAvailableTripsToolStripMenuItem1.Text = "View Available Trips";
            this.viewAvailableTripsToolStripMenuItem1.Click += new System.EventHandler(this.viewAvailableTripsToolStripMenuItem1_Click);
            // 
            // addNewTripToolStripMenuItem
            // 
            this.addNewTripToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.addNewTripToolStripMenuItem.Name = "addNewTripToolStripMenuItem";
            this.addNewTripToolStripMenuItem.Size = new System.Drawing.Size(324, 34);
            this.addNewTripToolStripMenuItem.Text = "Add New Trip";
            this.addNewTripToolStripMenuItem.Click += new System.EventHandler(this.addNewTripToolStripMenuItem_Click);
            // 
            // cancelTripToolStripMenuItem
            // 
            this.cancelTripToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.cancelTripToolStripMenuItem.Name = "cancelTripToolStripMenuItem";
            this.cancelTripToolStripMenuItem.Size = new System.Drawing.Size(324, 34);
            this.cancelTripToolStripMenuItem.Text = "Cancel Trip";
            this.cancelTripToolStripMenuItem.Click += new System.EventHandler(this.cancelTripToolStripMenuItem_Click);
            // 
            // bookReservationsToolStripMenuItem
            // 
            this.bookReservationsToolStripMenuItem.AutoToolTip = true;
            this.bookReservationsToolStripMenuItem.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookReservationsToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.bookReservationsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.bookReservationsToolStripMenuItem.Name = "bookReservationsToolStripMenuItem";
            this.bookReservationsToolStripMenuItem.Size = new System.Drawing.Size(163, 33);
            this.bookReservationsToolStripMenuItem.Text = "Reservations";
            this.bookReservationsToolStripMenuItem.Click += new System.EventHandler(this.bookReservationsToolStripMenuItem_Click);
            // 
            // cancelReservationsToolStripMenuItem
            // 
            this.cancelReservationsToolStripMenuItem.AutoToolTip = true;
            this.cancelReservationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTrainToolStripMenuItem,
            this.deleteTrainToolStripMenuItem});
            this.cancelReservationsToolStripMenuItem.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelReservationsToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.cancelReservationsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.cancelReservationsToolStripMenuItem.Name = "cancelReservationsToolStripMenuItem";
            this.cancelReservationsToolStripMenuItem.Size = new System.Drawing.Size(163, 33);
            this.cancelReservationsToolStripMenuItem.Text = "Trains";
            // 
            // addNewTrainToolStripMenuItem
            // 
            this.addNewTrainToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.addNewTrainToolStripMenuItem.Name = "addNewTrainToolStripMenuItem";
            this.addNewTrainToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.addNewTrainToolStripMenuItem.Text = "Add New Train";
            this.addNewTrainToolStripMenuItem.Click += new System.EventHandler(this.addNewTrainToolStripMenuItem_Click);
            // 
            // deleteTrainToolStripMenuItem
            // 
            this.deleteTrainToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.deleteTrainToolStripMenuItem.Name = "deleteTrainToolStripMenuItem";
            this.deleteTrainToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.deleteTrainToolStripMenuItem.Text = "Delete Train";
            this.deleteTrainToolStripMenuItem.Click += new System.EventHandler(this.deleteTrainToolStripMenuItem_Click);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEmployeeToolStripMenuItem,
            this.deleteEmployeeToolStripMenuItem});
            this.employeesToolStripMenuItem.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeesToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.employeesToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(163, 33);
            this.employeesToolStripMenuItem.Text = "Employees";
            // 
            // addNewEmployeeToolStripMenuItem
            // 
            this.addNewEmployeeToolStripMenuItem.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewEmployeeToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.addNewEmployeeToolStripMenuItem.Name = "addNewEmployeeToolStripMenuItem";
            this.addNewEmployeeToolStripMenuItem.Size = new System.Drawing.Size(303, 34);
            this.addNewEmployeeToolStripMenuItem.Text = "Add New Employee";
            this.addNewEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addNewEmployeeToolStripMenuItem_Click);
            // 
            // deleteEmployeeToolStripMenuItem
            // 
            this.deleteEmployeeToolStripMenuItem.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteEmployeeToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.deleteEmployeeToolStripMenuItem.Name = "deleteEmployeeToolStripMenuItem";
            this.deleteEmployeeToolStripMenuItem.Size = new System.Drawing.Size(303, 34);
            this.deleteEmployeeToolStripMenuItem.Text = "Delete Employee";
            this.deleteEmployeeToolStripMenuItem.Click += new System.EventHandler(this.deleteEmployeeToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.AutoToolTip = true;
            this.signOutToolStripMenuItem.Font = new System.Drawing.Font("Modern No. 20", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.signOutToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(163, 33);
            this.signOutToolStripMenuItem.Text = "Sign out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(236, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 518);
            this.panel1.TabIndex = 31;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1378, 534);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewAvailableTripsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookReservationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelReservationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAvailableTripsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewTripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelTripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTrainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTrainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEmployeeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}