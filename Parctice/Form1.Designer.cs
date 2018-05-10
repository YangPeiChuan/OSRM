namespace Parctice
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSplitCoordinates = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSplitLonLat = new System.Windows.Forms.TextBox();
            this.btnLoadCoordinates = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.lbxNoMatchs = new System.Windows.Forms.ListBox();
            this.lbNoMatch = new System.Windows.Forms.Label();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.cbService = new System.Windows.Forms.ComboBox();
            this.gvParameter = new System.Windows.Forms.DataGridView();
            this.colParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOSRM_Server = new System.Windows.Forms.TextBox();
            this.tbCoordinates = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUrlSelector = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.gvCoordinates = new System.Windows.Forms.DataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLongitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsMatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJson = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvParameter)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCoordinates)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbSplitCoordinates, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbSplitLonLat, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadCoordinates, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnMap, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbxNoMatchs, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.lbNoMatch, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnAnalysis, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbService, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.gvParameter, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(763, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 659);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "SplitCoordinates";
            // 
            // tbSplitCoordinates
            // 
            this.tbSplitCoordinates.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSplitCoordinates.Location = new System.Drawing.Point(125, 6);
            this.tbSplitCoordinates.MaxLength = 1;
            this.tbSplitCoordinates.Name = "tbSplitCoordinates";
            this.tbSplitCoordinates.Size = new System.Drawing.Size(100, 25);
            this.tbSplitCoordinates.TabIndex = 1;
            this.tbSplitCoordinates.Text = ",";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Split Lon/Lat";
            // 
            // tbSplitLonLat
            // 
            this.tbSplitLonLat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSplitLonLat.Location = new System.Drawing.Point(125, 37);
            this.tbSplitLonLat.Name = "tbSplitLonLat";
            this.tbSplitLonLat.Size = new System.Drawing.Size(100, 25);
            this.tbSplitLonLat.TabIndex = 1;
            this.tbSplitLonLat.Text = " ";
            // 
            // btnLoadCoordinates
            // 
            this.btnLoadCoordinates.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadCoordinates.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.btnLoadCoordinates, 2);
            this.btnLoadCoordinates.Location = new System.Drawing.Point(63, 68);
            this.btnLoadCoordinates.Name = "btnLoadCoordinates";
            this.btnLoadCoordinates.Size = new System.Drawing.Size(117, 25);
            this.btnLoadCoordinates.TabIndex = 2;
            this.btnLoadCoordinates.Text = "Load Coordinates";
            this.btnLoadCoordinates.UseVisualStyleBackColor = true;
            this.btnLoadCoordinates.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnMap
            // 
            this.btnMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMap.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.btnMap, 2);
            this.btnMap.Enabled = false;
            this.btnMap.Location = new System.Drawing.Point(84, 280);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(75, 25);
            this.btnMap.TabIndex = 4;
            this.btnMap.Text = "Map";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // lbxNoMatchs
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbxNoMatchs, 2);
            this.lbxNoMatchs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxNoMatchs.FormattingEnabled = true;
            this.lbxNoMatchs.ItemHeight = 15;
            this.lbxNoMatchs.Location = new System.Drawing.Point(6, 366);
            this.lbxNoMatchs.Name = "lbxNoMatchs";
            this.lbxNoMatchs.Size = new System.Drawing.Size(231, 194);
            this.lbxNoMatchs.TabIndex = 5;
            this.lbxNoMatchs.Visible = false;
            this.lbxNoMatchs.SelectedIndexChanged += new System.EventHandler(this.lbxNoMatchs_SelectedIndexChanged);
            // 
            // lbNoMatch
            // 
            this.lbNoMatch.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbNoMatch, 2);
            this.lbNoMatch.Location = new System.Drawing.Point(6, 348);
            this.lbNoMatch.Name = "lbNoMatch";
            this.lbNoMatch.Size = new System.Drawing.Size(130, 15);
            this.lbNoMatch.TabIndex = 6;
            this.lbNoMatch.Text = "No match coordinates";
            this.lbNoMatch.Visible = false;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnalysis.AutoSize = true;
            this.btnAnalysis.Enabled = false;
            this.btnAnalysis.Location = new System.Drawing.Point(137, 99);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(75, 25);
            this.btnAnalysis.TabIndex = 3;
            this.btnAnalysis.Text = "Analysis";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click_1);
            // 
            // cbService
            // 
            this.cbService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbService.FormattingEnabled = true;
            this.cbService.Items.AddRange(new object[] {
            "Match",
            "Nearest",
            "Route",
            "Table",
            "Trip",
            "Tile"});
            this.cbService.Location = new System.Drawing.Point(6, 99);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(101, 23);
            this.cbService.TabIndex = 8;
            this.cbService.Text = "Match";
            this.cbService.SelectedIndexChanged += new System.EventHandler(this.cbService_SelectedIndexChanged);
            // 
            // gvParameter
            // 
            this.gvParameter.AllowUserToAddRows = false;
            this.gvParameter.AllowUserToDeleteRows = false;
            this.gvParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvParameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colParameter,
            this.colValue});
            this.tableLayoutPanel1.SetColumnSpan(this.gvParameter, 2);
            this.gvParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvParameter.Location = new System.Drawing.Point(6, 130);
            this.gvParameter.Name = "gvParameter";
            this.gvParameter.RowTemplate.Height = 27;
            this.gvParameter.Size = new System.Drawing.Size(231, 144);
            this.gvParameter.TabIndex = 9;
            this.gvParameter.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvParameter_CellEndEdit);
            this.gvParameter.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvParameter_CellMouseClick);
            // 
            // colParameter
            // 
            this.colParameter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colParameter.HeaderText = "parameter";
            this.colParameter.Name = "colParameter";
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "OSRM Server";
            // 
            // tbOSRM_Server
            // 
            this.tbOSRM_Server.AutoCompleteCustomSource.AddRange(new string[] {
            "192.168.99.220:5000",
            "router.project-osrm.org",
            "210.59.250.220:5000"});
            this.tbOSRM_Server.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbOSRM_Server.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tableLayoutPanel3.SetColumnSpan(this.tbOSRM_Server, 2);
            this.tbOSRM_Server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOSRM_Server.Location = new System.Drawing.Point(97, 3);
            this.tbOSRM_Server.Name = "tbOSRM_Server";
            this.tbOSRM_Server.Size = new System.Drawing.Size(906, 25);
            this.tbOSRM_Server.TabIndex = 1;
            this.tbOSRM_Server.Text = "210.59.250.220:5000";
            // 
            // tbCoordinates
            // 
            this.tbCoordinates.Location = new System.Drawing.Point(97, 34);
            this.tbCoordinates.Name = "tbCoordinates";
            this.tbCoordinates.Size = new System.Drawing.Size(818, 25);
            this.tbCoordinates.TabIndex = 1;
            this.tbCoordinates.Text = "http://ptx.transportdata.tw/MOTC/v2/Bus/Shape/City/Taipei?$filter=RouteUID%20%20e" +
    "q%20%27TPE11206%27&$top=30&$format=JSON";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1006, 721);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.tbCoordinates, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tbOSRM_Server, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnUrlSelector, 2, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1006, 62);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Url(WKT)";
            // 
            // btnUrlSelector
            // 
            this.btnUrlSelector.AutoSize = true;
            this.btnUrlSelector.Location = new System.Drawing.Point(921, 34);
            this.btnUrlSelector.Name = "btnUrlSelector";
            this.btnUrlSelector.Size = new System.Drawing.Size(82, 25);
            this.btnUrlSelector.TabIndex = 2;
            this.btnUrlSelector.Text = "UrlSelector";
            this.btnUrlSelector.UseVisualStyleBackColor = true;
            this.btnUrlSelector.Click += new System.EventHandler(this.btnUrlSelector_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.gvCoordinates, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 62);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1006, 659);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // gvCoordinates
            // 
            this.gvCoordinates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCoordinates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colLongitude,
            this.colLatitude,
            this.colIsMatch,
            this.colJson});
            this.gvCoordinates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCoordinates.Location = new System.Drawing.Point(3, 3);
            this.gvCoordinates.Name = "gvCoordinates";
            this.gvCoordinates.RowTemplate.Height = 27;
            this.gvCoordinates.Size = new System.Drawing.Size(757, 653);
            this.gvCoordinates.TabIndex = 1;
            this.gvCoordinates.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCoordinates_CellEndEdit);
            this.gvCoordinates.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvCoordinates_CellMouseClick);
            // 
            // colIndex
            // 
            this.colIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colIndex.DataPropertyName = "Index";
            this.colIndex.HeaderText = "Index";
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            this.colIndex.Width = 68;
            // 
            // colLongitude
            // 
            this.colLongitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLongitude.DataPropertyName = "Longitude";
            this.colLongitude.HeaderText = "Longitude";
            this.colLongitude.Name = "colLongitude";
            this.colLongitude.Width = 94;
            // 
            // colLatitude
            // 
            this.colLatitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLatitude.DataPropertyName = "Latitude";
            this.colLatitude.HeaderText = "Latitude";
            this.colLatitude.Name = "colLatitude";
            this.colLatitude.Width = 83;
            // 
            // colIsMatch
            // 
            this.colIsMatch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colIsMatch.DataPropertyName = "IsMatch";
            this.colIsMatch.HeaderText = "IsMatch";
            this.colIsMatch.Name = "colIsMatch";
            this.colIsMatch.ReadOnly = true;
            this.colIsMatch.Width = 82;
            // 
            // colJson
            // 
            this.colJson.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colJson.HeaderText = "MatchJson";
            this.colJson.Name = "colJson";
            this.colJson.Text = "Show";
            this.colJson.UseColumnTextForButtonValue = true;
            this.colJson.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvParameter)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCoordinates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOSRM_Server;
        private System.Windows.Forms.TextBox tbCoordinates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSplitCoordinates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSplitLonLat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnLoadCoordinates;
        private System.Windows.Forms.DataGridView gvCoordinates;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLongitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsMatch;
        private System.Windows.Forms.DataGridViewButtonColumn colJson;
        private System.Windows.Forms.ListBox lbxNoMatchs;
        private System.Windows.Forms.Label lbNoMatch;
        private System.Windows.Forms.Button btnUrlSelector;
        private System.Windows.Forms.ComboBox cbService;
        private System.Windows.Forms.DataGridView gvParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParameter;
        private System.Windows.Forms.DataGridViewComboBoxColumn colValue;
    }
}

