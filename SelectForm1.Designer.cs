
namespace MyCreate {
    partial class SelectForm1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.TBListMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新規テーブル追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DBListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新規データベース追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.panel_list = new System.Windows.Forms.Panel();
            this.CANCEL_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel_inBtn = new System.Windows.Forms.Panel();
            this.テーブル削除toolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.TBListMenuStrip1.SuspendLayout();
            this.DBListMenuStrip.SuspendLayout();
            this.panel.SuspendLayout();
            this.panel_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_inBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.TBListMenuStrip1;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 27;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(215, 131);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // TBListMenuStrip1
            // 
            this.TBListMenuStrip1.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TBListMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TBListMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規テーブル追加ToolStripMenuItem,
            this.テーブル削除toolStrip});
            this.TBListMenuStrip1.Name = "DBListMenuStrip";
            this.TBListMenuStrip1.Size = new System.Drawing.Size(255, 104);
            // 
            // 新規テーブル追加ToolStripMenuItem
            // 
            this.新規テーブル追加ToolStripMenuItem.Name = "新規テーブル追加ToolStripMenuItem";
            this.新規テーブル追加ToolStripMenuItem.Size = new System.Drawing.Size(254, 36);
            this.新規テーブル追加ToolStripMenuItem.Text = "新規テーブル追加";
            this.新規テーブル追加ToolStripMenuItem.Click += new System.EventHandler(this.新規テーブル追加ToolStripMenuItem_Click);
            // 
            // DBListMenuStrip
            // 
            this.DBListMenuStrip.Font = new System.Drawing.Font("Yu Gothic UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DBListMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DBListMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規データベース追加ToolStripMenuItem});
            this.DBListMenuStrip.Name = "DBListMenuStrip";
            this.DBListMenuStrip.Size = new System.Drawing.Size(292, 40);
            // 
            // 新規データベース追加ToolStripMenuItem
            // 
            this.新規データベース追加ToolStripMenuItem.Name = "新規データベース追加ToolStripMenuItem";
            this.新規データベース追加ToolStripMenuItem.Size = new System.Drawing.Size(291, 36);
            this.新規データベース追加ToolStripMenuItem.Text = "新規データベース追加";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel.Controls.Add(this.panel_list);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(215, 131);
            this.panel.TabIndex = 2;
            // 
            // panel_list
            // 
            this.panel_list.BackColor = System.Drawing.Color.Ivory;
            this.panel_list.Controls.Add(this.listBox1);
            this.panel_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_list.Location = new System.Drawing.Point(0, 0);
            this.panel_list.Name = "panel_list";
            this.panel_list.Size = new System.Drawing.Size(215, 131);
            this.panel_list.TabIndex = 2;
            // 
            // CANCEL_btn
            // 
            this.CANCEL_btn.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CANCEL_btn.Location = new System.Drawing.Point(11, 8);
            this.CANCEL_btn.Name = "CANCEL_btn";
            this.CANCEL_btn.Size = new System.Drawing.Size(83, 51);
            this.CANCEL_btn.TabIndex = 3;
            this.CANCEL_btn.Text = "キャンセル";
            this.CANCEL_btn.UseVisualStyleBackColor = true;
            this.CANCEL_btn.Click += new System.EventHandler(this.CANCEL_btn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(122, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 51);
            this.button1.TabIndex = 4;
            this.button1.Text = "決定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer.Panel2.Controls.Add(this.panel_inBtn);
            this.splitContainer.Size = new System.Drawing.Size(215, 212);
            this.splitContainer.SplitterDistance = 131;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(215, 7);
            this.dataGridView1.TabIndex = 6;
            // 
            // panel_inBtn
            // 
            this.panel_inBtn.BackColor = System.Drawing.Color.Snow;
            this.panel_inBtn.Controls.Add(this.CANCEL_btn);
            this.panel_inBtn.Controls.Add(this.button1);
            this.panel_inBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_inBtn.Location = new System.Drawing.Point(0, 7);
            this.panel_inBtn.Name = "panel_inBtn";
            this.panel_inBtn.Size = new System.Drawing.Size(215, 66);
            this.panel_inBtn.TabIndex = 5;
            // 
            // テーブル削除toolStrip
            // 
            this.テーブル削除toolStrip.Name = "テーブル削除toolStrip";
            this.テーブル削除toolStrip.Size = new System.Drawing.Size(254, 36);
            this.テーブル削除toolStrip.Text = "テーブル削除";
            this.テーブル削除toolStrip.Click += new System.EventHandler(this.テーブル削除toolStrip_Click);
            // 
            // SelectForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 212);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer);
            this.Name = "SelectForm1";
            this.Text = "SelectForm1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectForm1_FormClosing);
            this.Load += new System.EventHandler(this.SelectForm1_Load);
            this.TBListMenuStrip1.ResumeLayout(false);
            this.DBListMenuStrip.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel_list.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_inBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button CANCEL_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel_inBtn;
        private System.Windows.Forms.Panel panel_list;
        private System.Windows.Forms.ContextMenuStrip TBListMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新規テーブル追加ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip DBListMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 新規データベース追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem テーブル削除toolStrip;
    }
}