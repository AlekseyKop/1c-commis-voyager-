namespace commis_voyageur
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.butAddOneCity = new System.Windows.Forms.Button();
            this.textCity = new System.Windows.Forms.TextBox();
            this.butAddCities = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.butGeneration = new System.Windows.Forms.Button();
            this.butFullPerebor = new System.Windows.Forms.Button();
            this.butMurovei = new System.Windows.Forms.Button();
            this.butUslovie = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Cities = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // butAddOneCity
            // 
            this.butAddOneCity.Location = new System.Drawing.Point(12, 10);
            this.butAddOneCity.Name = "butAddOneCity";
            this.butAddOneCity.Size = new System.Drawing.Size(123, 23);
            this.butAddOneCity.TabIndex = 0;
            this.butAddOneCity.Text = "Bвести город";
            this.butAddOneCity.UseVisualStyleBackColor = true;
            this.butAddOneCity.Click += new System.EventHandler(this.butAddOneCity_Click);
            // 
            // textCity
            // 
            this.textCity.Location = new System.Drawing.Point(141, 12);
            this.textCity.Name = "textCity";
            this.textCity.Size = new System.Drawing.Size(212, 20);
            this.textCity.TabIndex = 1;
            // 
            // butAddCities
            // 
            this.butAddCities.Location = new System.Drawing.Point(359, 10);
            this.butAddCities.Name = "butAddCities";
            this.butAddCities.Size = new System.Drawing.Size(168, 23);
            this.butAddCities.TabIndex = 2;
            this.butAddCities.Text = "Добавить города из файла";
            this.butAddCities.UseVisualStyleBackColor = true;
            this.butAddCities.Click += new System.EventHandler(this.butAddCities_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cities});
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 100;
            this.dataGridView1.Size = new System.Drawing.Size(341, 297);
            this.dataGridView1.TabIndex = 3;
            // 
            // butGeneration
            // 
            this.butGeneration.Location = new System.Drawing.Point(141, 38);
            this.butGeneration.Name = "butGeneration";
            this.butGeneration.Size = new System.Drawing.Size(212, 23);
            this.butGeneration.TabIndex = 4;
            this.butGeneration.Text = "Заполнить случайными расстояниями";
            this.butGeneration.UseVisualStyleBackColor = true;
            this.butGeneration.Click += new System.EventHandler(this.butGeneration_Click);
            // 
            // butFullPerebor
            // 
            this.butFullPerebor.Location = new System.Drawing.Point(359, 111);
            this.butFullPerebor.Name = "butFullPerebor";
            this.butFullPerebor.Size = new System.Drawing.Size(168, 23);
            this.butFullPerebor.TabIndex = 5;
            this.butFullPerebor.Text = "Полный Перебор";
            this.butFullPerebor.UseVisualStyleBackColor = true;
            this.butFullPerebor.Click += new System.EventHandler(this.butFullPerebor_Click);
            // 
            // butMurovei
            // 
            this.butMurovei.Location = new System.Drawing.Point(359, 82);
            this.butMurovei.Name = "butMurovei";
            this.butMurovei.Size = new System.Drawing.Size(168, 23);
            this.butMurovei.TabIndex = 6;
            this.butMurovei.Text = "Муравьиный Алгоритм";
            this.butMurovei.UseVisualStyleBackColor = true;
            this.butMurovei.Click += new System.EventHandler(this.butMurovei_Click);
            // 
            // butUslovie
            // 
            this.butUslovie.Location = new System.Drawing.Point(12, 38);
            this.butUslovie.Name = "butUslovie";
            this.butUslovie.Size = new System.Drawing.Size(123, 23);
            this.butUslovie.TabIndex = 7;
            this.butUslovie.Text = "Условие";
            this.butUslovie.UseVisualStyleBackColor = true;
            this.butUslovie.Click += new System.EventHandler(this.butUslovie_Click);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(359, 38);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(168, 23);
            this.butClear.TabIndex = 8;
            this.butClear.Text = "Очистить данные";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Способ решения:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(359, 140);
            this.textBox1.MaximumSize = new System.Drawing.Size(180, 200);
            this.textBox1.MinimumSize = new System.Drawing.Size(130, 224);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 224);
            this.textBox1.TabIndex = 10;
            // 
            // Cities
            // 
            this.Cities.HeaderText = "";
            this.Cities.Name = "Cities";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 375);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.butUslovie);
            this.Controls.Add(this.butMurovei);
            this.Controls.Add(this.butFullPerebor);
            this.Controls.Add(this.butGeneration);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.butAddCities);
            this.Controls.Add(this.textCity);
            this.Controls.Add(this.butAddOneCity);
            this.Name = "MainForm";
            this.Text = "Задача коммивояжера(муравьиный алгоритм)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butAddOneCity;
        private System.Windows.Forms.TextBox textCity;
        private System.Windows.Forms.Button butAddCities;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butGeneration;
        private System.Windows.Forms.Button butFullPerebor;
        private System.Windows.Forms.Button butMurovei;
        private System.Windows.Forms.Button butUslovie;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cities;
    }
}

