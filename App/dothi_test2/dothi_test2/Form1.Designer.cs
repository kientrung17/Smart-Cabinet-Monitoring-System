namespace dothi_test2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnconnect = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnimu = new System.Windows.Forms.Button();
            this.btnir = new System.Windows.Forms.Button();
            this.btnlaser = new System.Windows.Forms.Button();
            this.serCOM = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.txbsend = new System.Windows.Forms.TextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.Baudrate = new System.Windows.Forms.Label();
            this.comport = new System.Windows.Forms.Label();
            this.btnoview = new System.Windows.Forms.Button();
            this.txbrx = new System.Windows.Forms.TextBox();
            this.lbrx = new System.Windows.Forms.Label();
            this.btnclear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnback = new System.Windows.Forms.Button();
            this.btngraph = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnvantoc = new System.Windows.Forms.Button();
            this.btnquangduong = new System.Windows.Forms.Button();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnconnect
            // 
            this.btnconnect.AutoSize = true;
            this.btnconnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconnect.Location = new System.Drawing.Point(34, 168);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(131, 37);
            this.btnconnect.TabIndex = 0;
            this.btnconnect.Text = "CONNECT";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // btnexit
            // 
            this.btnexit.AutoSize = true;
            this.btnexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.Brown;
            this.btnexit.Location = new System.Drawing.Point(213, 168);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(113, 37);
            this.btnexit.TabIndex = 1;
            this.btnexit.Text = "EXIT";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnimu
            // 
            this.btnimu.AutoSize = true;
            this.btnimu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnimu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimu.Location = new System.Drawing.Point(244, 287);
            this.btnimu.Name = "btnimu";
            this.btnimu.Size = new System.Drawing.Size(140, 37);
            this.btnimu.TabIndex = 2;
            this.btnimu.Text = "IMU";
            this.btnimu.UseVisualStyleBackColor = true;
            this.btnimu.Click += new System.EventHandler(this.btnimu_Click);
            // 
            // btnir
            // 
            this.btnir.AutoSize = true;
            this.btnir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnir.Location = new System.Drawing.Point(244, 335);
            this.btnir.Name = "btnir";
            this.btnir.Size = new System.Drawing.Size(140, 37);
            this.btnir.TabIndex = 3;
            this.btnir.Text = "IR";
            this.btnir.UseVisualStyleBackColor = true;
            this.btnir.Click += new System.EventHandler(this.btnir_Click);
            // 
            // btnlaser
            // 
            this.btnlaser.AutoSize = true;
            this.btnlaser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnlaser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlaser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlaser.Location = new System.Drawing.Point(244, 393);
            this.btnlaser.Name = "btnlaser";
            this.btnlaser.Size = new System.Drawing.Size(140, 37);
            this.btnlaser.TabIndex = 4;
            this.btnlaser.Text = "LASER";
            this.btnlaser.UseVisualStyleBackColor = true;
            this.btnlaser.Click += new System.EventHandler(this.btnlaser_Click);
            // 
            // serCOM
            // 
            this.serCOM.BaudRate = 115200;
            this.serCOM.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serCOM_DataReceived);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Items.AddRange(new object[] {
            "COM tao1",
            "COM tao2"});
            this.comboBoxPort.Location = new System.Drawing.Point(185, 41);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(121, 33);
            this.comboBoxPort.TabIndex = 5;

            // 
            // txbsend
            // 
            this.txbsend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbsend.Location = new System.Drawing.Point(31, 335);
            this.txbsend.Multiline = true;
            this.txbsend.Name = "txbsend";
            this.txbsend.Size = new System.Drawing.Size(161, 149);
            this.txbsend.TabIndex = 6;
            this.txbsend.TextChanged += new System.EventHandler(this.txbsend_TextChanged);
            // 
            // btnsend
            // 
            this.btnsend.AutoSize = true;
            this.btnsend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsend.Location = new System.Drawing.Point(31, 289);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(80, 35);
            this.btnsend.TabIndex = 7;
            this.btnsend.Text = "Send:";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxBaud);
            this.groupBox1.Controls.Add(this.Baudrate);
            this.groupBox1.Controls.Add(this.comport);
            this.groupBox1.Controls.Add(this.comboBoxPort);
            this.groupBox1.Controls.Add(this.btnconnect);
            this.groupBox1.Controls.Add(this.btnexit);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(31, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 234);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication";
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Location = new System.Drawing.Point(185, 100);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(121, 33);
            this.comboBoxBaud.TabIndex = 8;
            // 
            // Baudrate
            // 
            this.Baudrate.AutoSize = true;
            this.Baudrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Baudrate.Location = new System.Drawing.Point(29, 108);
            this.Baudrate.Name = "Baudrate";
            this.Baudrate.Size = new System.Drawing.Size(105, 25);
            this.Baudrate.TabIndex = 7;
            this.Baudrate.Text = "Baudrate ";
            // 
            // comport
            // 
            this.comport.AutoSize = true;
            this.comport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comport.Location = new System.Drawing.Point(29, 41);
            this.comport.Name = "comport";
            this.comport.Size = new System.Drawing.Size(108, 25);
            this.comport.TabIndex = 6;
            this.comport.Text = "COM Port";
            // 
            // btnoview
            // 
            this.btnoview.AutoSize = true;
            this.btnoview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnoview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnoview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnoview.Location = new System.Drawing.Point(244, 447);
            this.btnoview.Name = "btnoview";
            this.btnoview.Size = new System.Drawing.Size(140, 37);
            this.btnoview.TabIndex = 9;
            this.btnoview.Text = "OVERVIEW";
            this.btnoview.UseVisualStyleBackColor = true;
            // 
            // txbrx
            // 
            this.txbrx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txbrx.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txbrx.Location = new System.Drawing.Point(31, 566);
            this.txbrx.Multiline = true;
            this.txbrx.Name = "txbrx";
            this.txbrx.ReadOnly = true;
            this.txbrx.Size = new System.Drawing.Size(353, 170);
            this.txbrx.TabIndex = 10;
            // 
            // lbrx
            // 
            this.lbrx.AutoSize = true;
            this.lbrx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbrx.Location = new System.Drawing.Point(26, 509);
            this.lbrx.Name = "lbrx";
            this.lbrx.Size = new System.Drawing.Size(152, 25);
            this.lbrx.TabIndex = 11;
            this.lbrx.Text = "Dữ liệu nhận : ";
            // 
            // btnclear
            // 
            this.btnclear.AutoSize = true;
            this.btnclear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(289, 509);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(95, 37);
            this.btnclear.TabIndex = 12;
            this.btnclear.Text = "CLEAR";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.Controls.Add(this.label14, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label15, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label16, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnback, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.btngraph, 4, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(430, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(979, 705);
            this.tableLayoutPanel1.TabIndex = 16;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.LightGreen;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(222, 532);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(213, 169);
            this.label14.TabIndex = 13;
            this.label14.Text = "label14";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.LightGreen;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 532);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(213, 169);
            this.label13.TabIndex = 12;
            this.label13.Text = "label13";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.LightGreen;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(660, 355);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(213, 169);
            this.label12.TabIndex = 11;
            this.label12.Text = "label12";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.LightGreen;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(441, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(213, 169);
            this.label11.TabIndex = 10;
            this.label11.Text = "label11";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.LightGreen;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(222, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 169);
            this.label10.TabIndex = 9;
            this.label10.Text = "label10";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.LightGreen;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 355);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(213, 169);
            this.label9.TabIndex = 8;
            this.label9.Text = "label9";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.LightGreen;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(660, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 169);
            this.label8.TabIndex = 7;
            this.label8.Text = "label8";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.LightGreen;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(441, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 169);
            this.label7.TabIndex = 6;
            this.label7.Text = "label7";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.LightGreen;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(222, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 169);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.LightGreen;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 169);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.LightGreen;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(660, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 169);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.LightGreen;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 169);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.LightGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 169);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.LightGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 169);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BackColor = System.Drawing.Color.LightGreen;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(660, 532);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(213, 169);
            this.label15.TabIndex = 14;
            this.label15.Text = "label15";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.LightGreen;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(441, 532);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(213, 169);
            this.label16.TabIndex = 15;
            this.label16.Text = "label16";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnback
            // 
            this.btnback.AutoSize = true;
            this.btnback.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.Location = new System.Drawing.Point(879, 531);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(97, 73);
            this.btnback.TabIndex = 16;
            this.btnback.Text = "BACK";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btngraph
            // 
            this.btngraph.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btngraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngraph.Location = new System.Drawing.Point(879, 355);
            this.btngraph.Name = "btngraph";
            this.btngraph.Size = new System.Drawing.Size(97, 69);
            this.btngraph.TabIndex = 17;
            this.btngraph.Text = "GRAPH";
            this.btngraph.UseVisualStyleBackColor = true;
            this.btngraph.Click += new System.EventHandler(this.btngraph_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(430, 42);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.LegendText = "Laser";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(979, 694);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lineAnnotation1.Name = "LineAnnotation1";
            this.chart2.Annotations.Add(lineAnnotation1);
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(430, 42);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.LegendText = "X";
            series2.Name = "Series1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Lime;
            series3.Legend = "Legend1";
            series3.LegendText = "Y";
            series3.Name = "Series2";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Aqua;
            series4.Legend = "Legend1";
            series4.LegendText = "Z";
            series4.Name = "Series3";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Navy;
            series5.Legend = "Legend1";
            series5.LegendText = "|a|";
            series5.Name = "Series4";
            this.chart2.Series.Add(series2);
            this.chart2.Series.Add(series3);
            this.chart2.Series.Add(series4);
            this.chart2.Series.Add(series5);
            this.chart2.Size = new System.Drawing.Size(960, 705);
            this.chart2.TabIndex = 17;
            this.chart2.Text = "chart2";
            this.chart2.Visible = false;
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::dothi_test2.Properties.Resources.Screenshot_2024_11_08_160909;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(1309, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 234);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // btnvantoc
            // 
            this.btnvantoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnvantoc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnvantoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvantoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvantoc.Location = new System.Drawing.Point(1415, 42);
            this.btnvantoc.Name = "btnvantoc";
            this.btnvantoc.Size = new System.Drawing.Size(117, 69);
            this.btnvantoc.TabIndex = 19;
            this.btnvantoc.Text = "SPEED";
            this.btnvantoc.UseVisualStyleBackColor = true;
            this.btnvantoc.Visible = false;
            this.btnvantoc.Click += new System.EventHandler(this.btnvantoc_Click);
            // 
            // btnquangduong
            // 
            this.btnquangduong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnquangduong.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnquangduong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnquangduong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnquangduong.Location = new System.Drawing.Point(1415, 145);
            this.btnquangduong.Name = "btnquangduong";
            this.btnquangduong.Size = new System.Drawing.Size(117, 69);
            this.btnquangduong.TabIndex = 20;
            this.btnquangduong.Text = "DISTANCE";
            this.btnquangduong.UseVisualStyleBackColor = true;
            this.btnquangduong.Visible = false;
            this.btnquangduong.Click += new System.EventHandler(this.btnquangduong_Click);
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(430, 42);
            this.chart3.Name = "chart3";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart3.Series.Add(series6);
            this.chart3.Size = new System.Drawing.Size(960, 705);
            this.chart3.TabIndex = 21;
            this.chart3.Text = "chart3";
            this.chart3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 803);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.btnquangduong);
            this.Controls.Add(this.btnvantoc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.lbrx);
            this.Controls.Add(this.txbrx);
            this.Controls.Add(this.btnoview);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.txbsend);
            this.Controls.Add(this.btnlaser);
            this.Controls.Add(this.btnir);
            this.Controls.Add(this.btnimu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnimu;
        private System.Windows.Forms.Button btnir;
        private System.Windows.Forms.Button btnlaser;
        private System.IO.Ports.SerialPort serCOM;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.TextBox txbsend;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Baudrate;
        private System.Windows.Forms.Label comport;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.Button btnoview;
        private System.Windows.Forms.TextBox txbrx;
        private System.Windows.Forms.Label lbrx;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btngraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnvantoc;
        private System.Windows.Forms.Button btnquangduong;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
    }
}

