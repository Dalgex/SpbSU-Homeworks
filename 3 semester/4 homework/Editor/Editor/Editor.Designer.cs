namespace Editor
{
    partial class Editor
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonForColor = new System.Windows.Forms.Button();
            this.buttonForClearing = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonForRemoving = new System.Windows.Forms.Button();
            this.buttonForUndo = new System.Windows.Forms.Button();
            this.buttonForRedo = new System.Windows.Forms.Button();
            this.buttonForMoving = new System.Windows.Forms.Button();
            this.buttonForWidth = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(485, 273);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxPaint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseUp);
            // 
            // buttonForColor
            // 
            this.buttonForColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonForColor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForColor.Location = new System.Drawing.Point(363, 3);
            this.buttonForColor.Name = "buttonForColor";
            this.buttonForColor.Size = new System.Drawing.Size(114, 35);
            this.buttonForColor.TabIndex = 1;
            this.buttonForColor.Text = "Цвет";
            this.toolTip1.SetToolTip(this.buttonForColor, "Щелкните здесь и выберите цвет в диалоговом окне");
            this.buttonForColor.UseVisualStyleBackColor = true;
            this.buttonForColor.Click += new System.EventHandler(this.OnColorClick);
            // 
            // buttonForClearing
            // 
            this.buttonForClearing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonForClearing.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForClearing.Location = new System.Drawing.Point(243, 3);
            this.buttonForClearing.Name = "buttonForClearing";
            this.buttonForClearing.Size = new System.Drawing.Size(114, 35);
            this.buttonForClearing.TabIndex = 2;
            this.buttonForClearing.Text = "Очистить";
            this.toolTip1.SetToolTip(this.buttonForClearing, "Очистить всю поверхность рисования");
            this.buttonForClearing.UseVisualStyleBackColor = true;
            this.buttonForClearing.Click += new System.EventHandler(this.OnClearClick);
            // 
            // buttonForRemoving
            // 
            this.buttonForRemoving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonForRemoving.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForRemoving.Location = new System.Drawing.Point(123, 44);
            this.buttonForRemoving.Name = "buttonForRemoving";
            this.buttonForRemoving.Size = new System.Drawing.Size(114, 36);
            this.buttonForRemoving.TabIndex = 3;
            this.buttonForRemoving.Text = "Удалить";
            this.toolTip1.SetToolTip(this.buttonForRemoving, "Удалить линию");
            this.buttonForRemoving.UseVisualStyleBackColor = true;
            this.buttonForRemoving.Click += new System.EventHandler(this.OnRemoveClick);
            // 
            // buttonForUndo
            // 
            this.buttonForUndo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonForUndo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForUndo.Location = new System.Drawing.Point(3, 3);
            this.buttonForUndo.Name = "buttonForUndo";
            this.buttonForUndo.Size = new System.Drawing.Size(114, 35);
            this.buttonForUndo.TabIndex = 4;
            this.buttonForUndo.Text = "Undo";
            this.toolTip1.SetToolTip(this.buttonForUndo, "Отменить (CTRL+Z)\r\nОтмена последнего действия");
            this.buttonForUndo.UseVisualStyleBackColor = true;
            this.buttonForUndo.Click += new System.EventHandler(this.OnUndoClick);
            // 
            // buttonForRedo
            // 
            this.buttonForRedo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonForRedo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForRedo.Location = new System.Drawing.Point(3, 44);
            this.buttonForRedo.Name = "buttonForRedo";
            this.buttonForRedo.Size = new System.Drawing.Size(114, 36);
            this.buttonForRedo.TabIndex = 5;
            this.buttonForRedo.Text = "Redo";
            this.toolTip1.SetToolTip(this.buttonForRedo, "Вернуть (CTRL+Y)\r\nПовтор последнего действия");
            this.buttonForRedo.UseVisualStyleBackColor = true;
            this.buttonForRedo.Click += new System.EventHandler(this.OnRedoClick);
            // 
            // buttonForMoving
            // 
            this.buttonForMoving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonForMoving.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForMoving.Location = new System.Drawing.Point(123, 3);
            this.buttonForMoving.Name = "buttonForMoving";
            this.buttonForMoving.Size = new System.Drawing.Size(114, 35);
            this.buttonForMoving.TabIndex = 6;
            this.buttonForMoving.Text = "Переместить";
            this.toolTip1.SetToolTip(this.buttonForMoving, "Переместить любой из концов соответствующей линии");
            this.buttonForMoving.UseVisualStyleBackColor = true;
            this.buttonForMoving.Click += new System.EventHandler(this.OnMoveClick);
            // 
            // buttonForWidth
            // 
            this.buttonForWidth.ContextMenuStrip = this.contextMenuStrip1;
            this.buttonForWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonForWidth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForWidth.Location = new System.Drawing.Point(363, 44);
            this.buttonForWidth.Name = "buttonForWidth";
            this.buttonForWidth.Size = new System.Drawing.Size(114, 36);
            this.buttonForWidth.TabIndex = 7;
            this.buttonForWidth.Text = "Толщина";
            this.toolTip1.SetToolTip(this.buttonForWidth, "Выбор ширины для рисования линий");
            this.buttonForWidth.UseVisualStyleBackColor = true;
            this.buttonForWidth.Click += new System.EventHandler(this.OnWidthClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(81, 114);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItemClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItemClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem4.Text = "4";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItemClick);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem5.Text = "6";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.ToolStripMenuItemClick);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem6.Text = "8";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.ToolStripMenuItemClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonForUndo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonForRedo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonForWidth, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonForClearing, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonForColor, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonForRemoving, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonForMoving, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(483, 83);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 273);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(501, 311);
            this.Name = "Editor";
            this.Text = "Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditorKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonForColor;
        private System.Windows.Forms.Button buttonForClearing;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonForRemoving;
        private System.Windows.Forms.Button buttonForUndo;
        private System.Windows.Forms.Button buttonForRedo;
        private System.Windows.Forms.Button buttonForMoving;
        private System.Windows.Forms.Button buttonForWidth;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

