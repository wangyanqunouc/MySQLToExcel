namespace MySqlToExcel
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_DataBase = new System.Windows.Forms.Button();
            this.txt_DBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DBUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_DBPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_DBUrl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_TagID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Go = new System.Windows.Forms.Button();
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.str_Time1 = new System.Windows.Forms.DateTimePicker();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.str_Time2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeCopy = new System.Windows.Forms.DateTimePicker();
            this.test_excel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_DataBase
            // 
            this.btn_DataBase.Location = new System.Drawing.Point(326, 61);
            this.btn_DataBase.Name = "btn_DataBase";
            this.btn_DataBase.Size = new System.Drawing.Size(75, 23);
            this.btn_DataBase.TabIndex = 0;
            this.btn_DataBase.Text = "连接DB";
            this.btn_DataBase.UseVisualStyleBackColor = true;
            this.btn_DataBase.Click += new System.EventHandler(this.btn_DataBase_Click);
            // 
            // txt_DBName
            // 
            this.txt_DBName.Location = new System.Drawing.Point(353, 26);
            this.txt_DBName.Name = "txt_DBName";
            this.txt_DBName.Size = new System.Drawing.Size(132, 21);
            this.txt_DBName.TabIndex = 1;
            this.txt_DBName.Text = "wantongbao1206";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "数据库";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(215, 63);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(85, 21);
            this.txt_Password.TabIndex = 3;
            this.txt_Password.Text = "123456";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "用户名";
            // 
            // txt_DBUser
            // 
            this.txt_DBUser.Location = new System.Drawing.Point(50, 60);
            this.txt_DBUser.Name = "txt_DBUser";
            this.txt_DBUser.Size = new System.Drawing.Size(85, 21);
            this.txt_DBUser.TabIndex = 5;
            this.txt_DBUser.Text = "root";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "端口号";
            // 
            // txt_DBPort
            // 
            this.txt_DBPort.Location = new System.Drawing.Point(215, 23);
            this.txt_DBPort.Name = "txt_DBPort";
            this.txt_DBPort.Size = new System.Drawing.Size(85, 21);
            this.txt_DBPort.TabIndex = 7;
            this.txt_DBPort.Text = "3306";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "地址";
            // 
            // txt_DBUrl
            // 
            this.txt_DBUrl.Location = new System.Drawing.Point(50, 20);
            this.txt_DBUrl.Name = "txt_DBUrl";
            this.txt_DBUrl.Size = new System.Drawing.Size(85, 21);
            this.txt_DBUrl.TabIndex = 9;
            this.txt_DBUrl.Text = "localhost";
            this.txt_DBUrl.TextChanged += new System.EventHandler(this.txt_DBUrlName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "编号";
            // 
            // txt_TagID
            // 
            this.txt_TagID.Location = new System.Drawing.Point(50, 119);
            this.txt_TagID.Name = "txt_TagID";
            this.txt_TagID.Size = new System.Drawing.Size(85, 21);
            this.txt_TagID.TabIndex = 11;
            this.txt_TagID.Text = "1047";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "日期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "时间";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(440, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 12);
            this.label9.TabIndex = 18;
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(12, 162);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(75, 23);
            this.btn_Go.TabIndex = 20;
            this.btn_Go.Text = "查询与分析";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // txt_Log
            // 
            this.txt_Log.Location = new System.Drawing.Point(25, 215);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Log.Size = new System.Drawing.Size(506, 162);
            this.txt_Log.TabIndex = 21;
            // 
            // str_Time1
            // 
            this.str_Time1.CustomFormat = "HH:mm:ss";
            this.str_Time1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.str_Time1.Location = new System.Drawing.Point(326, 122);
            this.str_Time1.Name = "str_Time1";
            this.str_Time1.Size = new System.Drawing.Size(200, 21);
            this.str_Time1.TabIndex = 22;
            this.str_Time1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTime
            // 
            this.dateTime.CustomFormat = "yymmdd";
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime.Location = new System.Drawing.Point(182, 122);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(104, 21);
            this.dateTime.TabIndex = 23;
            // 
            // str_Time2
            // 
            this.str_Time2.CustomFormat = "HH:mm:ss";
            this.str_Time2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.str_Time2.Location = new System.Drawing.Point(326, 149);
            this.str_Time2.Name = "str_Time2";
            this.str_Time2.Size = new System.Drawing.Size(200, 21);
            this.str_Time2.TabIndex = 24;
            // 
            // dateTimeCopy
            // 
            this.dateTimeCopy.CustomFormat = "yyyy-mm-dd";
            this.dateTimeCopy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeCopy.Location = new System.Drawing.Point(182, 149);
            this.dateTimeCopy.Name = "dateTimeCopy";
            this.dateTimeCopy.Size = new System.Drawing.Size(104, 21);
            this.dateTimeCopy.TabIndex = 25;
            // 
            // test_excel
            // 
            this.test_excel.Location = new System.Drawing.Point(615, 127);
            this.test_excel.Name = "test_excel";
            this.test_excel.Size = new System.Drawing.Size(75, 23);
            this.test_excel.TabIndex = 26;
            this.test_excel.Text = "test_excel";
            this.test_excel.UseVisualStyleBackColor = true;
            this.test_excel.Click += new System.EventHandler(this.test_excel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 418);
            this.Controls.Add(this.test_excel);
            this.Controls.Add(this.dateTimeCopy);
            this.Controls.Add(this.str_Time2);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.str_Time1);
            this.Controls.Add(this.txt_Log);
            this.Controls.Add(this.btn_Go);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_TagID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_DBUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_DBPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_DBUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_DBName);
            this.Controls.Add(this.btn_DataBase);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_DataBase;
        private System.Windows.Forms.TextBox txt_DBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_DBUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_DBPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_DBUrl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_TagID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.DateTimePicker str_Time1;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.DateTimePicker str_Time2;
        private System.Windows.Forms.DateTimePicker dateTimeCopy;
        private System.Windows.Forms.Button test_excel;
    }
}

