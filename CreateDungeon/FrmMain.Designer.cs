namespace CreateDungeon
{
    partial class FrmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pbDungeon = new System.Windows.Forms.PictureBox();
            this.lblInfoMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudBigRoomProbability = new System.Windows.Forms.NumericUpDown();
            this.nudRoomCountMin = new System.Windows.Forms.NumericUpDown();
            this.nudRoomCountMax = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudRoomSizeMax = new System.Windows.Forms.NumericUpDown();
            this.nudRoomSizeMin = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.btnChangeProperty = new System.Windows.Forms.Button();
            this.lblDungeonSizeHeight = new System.Windows.Forms.Label();
            this.lblDungeonSizeWidth = new System.Windows.Forms.Label();
            this.lblBlockSize = new System.Windows.Forms.Label();
            this.lblPbDungeonHeight = new System.Windows.Forms.Label();
            this.lblPbDungeonWidth = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.nudDungeonSizeHeight = new System.Windows.Forms.NumericUpDown();
            this.nudDungeonSizeWidth = new System.Windows.Forms.NumericUpDown();
            this.nudBlockSize = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDungeon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBigRoomProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomCountMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomCountMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomSizeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomSizeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDungeonSizeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDungeonSizeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "生成されたダンジョン";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(1129, 341);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "生成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pbDungeon
            // 
            this.pbDungeon.BackColor = System.Drawing.SystemColors.Control;
            this.pbDungeon.Location = new System.Drawing.Point(15, 34);
            this.pbDungeon.Name = "pbDungeon";
            this.pbDungeon.Size = new System.Drawing.Size(600, 450);
            this.pbDungeon.TabIndex = 3;
            this.pbDungeon.TabStop = false;
            // 
            // lblInfoMessage
            // 
            this.lblInfoMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfoMessage.AutoSize = true;
            this.lblInfoMessage.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.lblInfoMessage.Location = new System.Drawing.Point(40, 656);
            this.lblInfoMessage.Name = "lblInfoMessage";
            this.lblInfoMessage.Size = new System.Drawing.Size(0, 16);
            this.lblInfoMessage.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(963, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "部屋サイズ(マス数)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(963, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "横";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label4.Location = new System.Drawing.Point(1045, 468);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "縦";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label5.Location = new System.Drawing.Point(963, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "設定値";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label6.Location = new System.Drawing.Point(963, 532);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "1ブロックのサイズ(px)";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label7.Location = new System.Drawing.Point(963, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "部屋生成数範囲";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label9.Location = new System.Drawing.Point(963, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "部屋幅範囲";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label11.Location = new System.Drawing.Point(963, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "大部屋生成確率";
            // 
            // nudBigRoomProbability
            // 
            this.nudBigRoomProbability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBigRoomProbability.Location = new System.Drawing.Point(966, 341);
            this.nudBigRoomProbability.Name = "nudBigRoomProbability";
            this.nudBigRoomProbability.Size = new System.Drawing.Size(53, 19);
            this.nudBigRoomProbability.TabIndex = 4;
            // 
            // nudRoomCountMin
            // 
            this.nudRoomCountMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRoomCountMin.Location = new System.Drawing.Point(966, 123);
            this.nudRoomCountMin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRoomCountMin.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRoomCountMin.Name = "nudRoomCountMin";
            this.nudRoomCountMin.ReadOnly = true;
            this.nudRoomCountMin.Size = new System.Drawing.Size(53, 19);
            this.nudRoomCountMin.TabIndex = 0;
            this.nudRoomCountMin.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudRoomCountMax
            // 
            this.nudRoomCountMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRoomCountMax.Location = new System.Drawing.Point(1064, 123);
            this.nudRoomCountMax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRoomCountMax.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRoomCountMax.Name = "nudRoomCountMax";
            this.nudRoomCountMax.ReadOnly = true;
            this.nudRoomCountMax.Size = new System.Drawing.Size(53, 19);
            this.nudRoomCountMax.TabIndex = 1;
            this.nudRoomCountMax.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label8.Location = new System.Drawing.Point(1027, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "～";
            // 
            // nudRoomSizeMax
            // 
            this.nudRoomSizeMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRoomSizeMax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRoomSizeMax.Location = new System.Drawing.Point(1064, 238);
            this.nudRoomSizeMax.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRoomSizeMax.Name = "nudRoomSizeMax";
            this.nudRoomSizeMax.ReadOnly = true;
            this.nudRoomSizeMax.Size = new System.Drawing.Size(53, 19);
            this.nudRoomSizeMax.TabIndex = 3;
            this.nudRoomSizeMax.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // nudRoomSizeMin
            // 
            this.nudRoomSizeMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRoomSizeMin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRoomSizeMin.Location = new System.Drawing.Point(966, 238);
            this.nudRoomSizeMin.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRoomSizeMin.Name = "nudRoomSizeMin";
            this.nudRoomSizeMin.ReadOnly = true;
            this.nudRoomSizeMin.Size = new System.Drawing.Size(53, 19);
            this.nudRoomSizeMin.TabIndex = 2;
            this.nudRoomSizeMin.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label10.Location = new System.Drawing.Point(963, 408);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(241, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "高度な設定(設定ボタン押下で反映)";
            // 
            // btnChangeProperty
            // 
            this.btnChangeProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeProperty.Location = new System.Drawing.Point(1129, 646);
            this.btnChangeProperty.Name = "btnChangeProperty";
            this.btnChangeProperty.Size = new System.Drawing.Size(75, 23);
            this.btnChangeProperty.TabIndex = 9;
            this.btnChangeProperty.Text = "設定";
            this.btnChangeProperty.UseVisualStyleBackColor = true;
            this.btnChangeProperty.Click += new System.EventHandler(this.btnChangeProperty_Click);
            // 
            // lblDungeonSizeHeight
            // 
            this.lblDungeonSizeHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDungeonSizeHeight.AutoSize = true;
            this.lblDungeonSizeHeight.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.lblDungeonSizeHeight.Location = new System.Drawing.Point(963, 484);
            this.lblDungeonSizeHeight.Name = "lblDungeonSizeHeight";
            this.lblDungeonSizeHeight.Size = new System.Drawing.Size(32, 16);
            this.lblDungeonSizeHeight.TabIndex = 24;
            this.lblDungeonSizeHeight.Text = "120";
            // 
            // lblDungeonSizeWidth
            // 
            this.lblDungeonSizeWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDungeonSizeWidth.AutoSize = true;
            this.lblDungeonSizeWidth.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.lblDungeonSizeWidth.Location = new System.Drawing.Point(1045, 484);
            this.lblDungeonSizeWidth.Name = "lblDungeonSizeWidth";
            this.lblDungeonSizeWidth.Size = new System.Drawing.Size(24, 16);
            this.lblDungeonSizeWidth.TabIndex = 25;
            this.lblDungeonSizeWidth.Text = "90";
            // 
            // lblBlockSize
            // 
            this.lblBlockSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBlockSize.AutoSize = true;
            this.lblBlockSize.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.lblBlockSize.Location = new System.Drawing.Point(963, 548);
            this.lblBlockSize.Name = "lblBlockSize";
            this.lblBlockSize.Size = new System.Drawing.Size(16, 16);
            this.lblBlockSize.TabIndex = 26;
            this.lblBlockSize.Text = "5";
            // 
            // lblPbDungeonHeight
            // 
            this.lblPbDungeonHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPbDungeonHeight.AutoSize = true;
            this.lblPbDungeonHeight.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.lblPbDungeonHeight.Location = new System.Drawing.Point(1045, 638);
            this.lblPbDungeonHeight.Name = "lblPbDungeonHeight";
            this.lblPbDungeonHeight.Size = new System.Drawing.Size(32, 16);
            this.lblPbDungeonHeight.TabIndex = 31;
            this.lblPbDungeonHeight.Text = "450";
            // 
            // lblPbDungeonWidth
            // 
            this.lblPbDungeonWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPbDungeonWidth.AutoSize = true;
            this.lblPbDungeonWidth.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.lblPbDungeonWidth.Location = new System.Drawing.Point(963, 638);
            this.lblPbDungeonWidth.Name = "lblPbDungeonWidth";
            this.lblPbDungeonWidth.Size = new System.Drawing.Size(32, 16);
            this.lblPbDungeonWidth.TabIndex = 30;
            this.lblPbDungeonWidth.Text = "600";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label17.Location = new System.Drawing.Point(1045, 622);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 16);
            this.label17.TabIndex = 29;
            this.label17.Text = "縦";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label18.Location = new System.Drawing.Point(963, 622);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 16);
            this.label18.TabIndex = 28;
            this.label18.Text = "横";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label19.Location = new System.Drawing.Point(963, 598);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(209, 16);
            this.label19.TabIndex = 27;
            this.label19.Text = "ダンジョン描画サイズ(自動計算)";
            // 
            // nudDungeonSizeHeight
            // 
            this.nudDungeonSizeHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDungeonSizeHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDungeonSizeHeight.Location = new System.Drawing.Point(966, 503);
            this.nudDungeonSizeHeight.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.nudDungeonSizeHeight.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudDungeonSizeHeight.Name = "nudDungeonSizeHeight";
            this.nudDungeonSizeHeight.ReadOnly = true;
            this.nudDungeonSizeHeight.Size = new System.Drawing.Size(53, 19);
            this.nudDungeonSizeHeight.TabIndex = 6;
            this.nudDungeonSizeHeight.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // nudDungeonSizeWidth
            // 
            this.nudDungeonSizeWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDungeonSizeWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDungeonSizeWidth.Location = new System.Drawing.Point(1046, 503);
            this.nudDungeonSizeWidth.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudDungeonSizeWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDungeonSizeWidth.Name = "nudDungeonSizeWidth";
            this.nudDungeonSizeWidth.ReadOnly = true;
            this.nudDungeonSizeWidth.Size = new System.Drawing.Size(53, 19);
            this.nudDungeonSizeWidth.TabIndex = 7;
            this.nudDungeonSizeWidth.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // nudBlockSize
            // 
            this.nudBlockSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBlockSize.Location = new System.Drawing.Point(966, 567);
            this.nudBlockSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBlockSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBlockSize.Name = "nudBlockSize";
            this.nudBlockSize.ReadOnly = true;
            this.nudBlockSize.Size = new System.Drawing.Size(53, 19);
            this.nudBlockSize.TabIndex = 8;
            this.nudBlockSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label12.Location = new System.Drawing.Point(1027, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 35;
            this.label12.Text = "～";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nudBlockSize);
            this.Controls.Add(this.nudDungeonSizeWidth);
            this.Controls.Add(this.nudDungeonSizeHeight);
            this.Controls.Add(this.lblPbDungeonHeight);
            this.Controls.Add(this.lblPbDungeonWidth);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblBlockSize);
            this.Controls.Add(this.lblDungeonSizeWidth);
            this.Controls.Add(this.lblDungeonSizeHeight);
            this.Controls.Add(this.btnChangeProperty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudRoomSizeMin);
            this.Controls.Add(this.nudRoomSizeMax);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudRoomCountMax);
            this.Controls.Add(this.nudRoomCountMin);
            this.Controls.Add(this.nudBigRoomProbability);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInfoMessage);
            this.Controls.Add(this.pbDungeon);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDungeon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBigRoomProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomCountMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomCountMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomSizeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoomSizeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDungeonSizeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDungeonSizeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlockSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox pbDungeon;
        private System.Windows.Forms.Label lblInfoMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudBigRoomProbability;
        private System.Windows.Forms.NumericUpDown nudRoomCountMin;
        private System.Windows.Forms.NumericUpDown nudRoomCountMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudRoomSizeMax;
        private System.Windows.Forms.NumericUpDown nudRoomSizeMin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnChangeProperty;
        private System.Windows.Forms.Label lblDungeonSizeHeight;
        private System.Windows.Forms.Label lblDungeonSizeWidth;
        private System.Windows.Forms.Label lblBlockSize;
        private System.Windows.Forms.Label lblPbDungeonHeight;
        private System.Windows.Forms.Label lblPbDungeonWidth;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown nudDungeonSizeHeight;
        private System.Windows.Forms.NumericUpDown nudDungeonSizeWidth;
        private System.Windows.Forms.NumericUpDown nudBlockSize;
        private System.Windows.Forms.Label label12;
    }
}

