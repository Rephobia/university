namespace WindowsFormsApp1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьГрафикСортировкиВставкамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьГрафикСортировкиВыборомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьГрафикСортировкиПузырькомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВсёГрафикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выборСортировкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рекурсивнымиФункциямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цикламиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.выборСортировкиToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьВсёГрафикиToolStripMenuItem,
            this.сохранитьГрафикСортировкиВставкамиToolStripMenuItem,
            this.сохранитьГрафикСортировкиВыборомToolStripMenuItem,
            this.сохранитьГрафикСортировкиПузырькомToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьГрафикСортировкиВставкамиToolStripMenuItem
            // 
            this.сохранитьГрафикСортировкиВставкамиToolStripMenuItem.Name = "сохранитьГрафикСортировкиВставкамиToolStripMenuItem";
            this.сохранитьГрафикСортировкиВставкамиToolStripMenuItem.Size = new System.Drawing.Size(387, 26);
            this.сохранитьГрафикСортировкиВставкамиToolStripMenuItem.Text = "Сохранить график сортировки вставками";
            // 
            // сохранитьГрафикСортировкиВыборомToolStripMenuItem
            // 
            this.сохранитьГрафикСортировкиВыборомToolStripMenuItem.Name = "сохранитьГрафикСортировкиВыборомToolStripMenuItem";
            this.сохранитьГрафикСортировкиВыборомToolStripMenuItem.Size = new System.Drawing.Size(387, 26);
            this.сохранитьГрафикСортировкиВыборомToolStripMenuItem.Text = "Сохранить график сортировки выбором";
            // 
            // сохранитьГрафикСортировкиПузырькомToolStripMenuItem
            // 
            this.сохранитьГрафикСортировкиПузырькомToolStripMenuItem.Name = "сохранитьГрафикСортировкиПузырькомToolStripMenuItem";
            this.сохранитьГрафикСортировкиПузырькомToolStripMenuItem.Size = new System.Drawing.Size(387, 26);
            this.сохранитьГрафикСортировкиПузырькомToolStripMenuItem.Text = "Сохранить график сортировки пузырьком";
            // 
            // сохранитьВсёГрафикиToolStripMenuItem
            // 
            this.сохранитьВсёГрафикиToolStripMenuItem.Name = "сохранитьВсёГрафикиToolStripMenuItem";
            this.сохранитьВсёГрафикиToolStripMenuItem.Size = new System.Drawing.Size(387, 26);
            this.сохранитьВсёГрафикиToolStripMenuItem.Text = "Сохранить всё графики";
            // 
            // выборСортировкиToolStripMenuItem
            // 
            this.выборСортировкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рекурсивнымиФункциямиToolStripMenuItem,
            this.цикламиToolStripMenuItem});
            this.выборСортировкиToolStripMenuItem.Name = "выборСортировкиToolStripMenuItem";
            this.выборСортировкиToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.выборСортировкиToolStripMenuItem.Text = "Выбор сортировки";
            // 
            // рекурсивнымиФункциямиToolStripMenuItem
            // 
            this.рекурсивнымиФункциямиToolStripMenuItem.Name = "рекурсивнымиФункциямиToolStripMenuItem";
            this.рекурсивнымиФункциямиToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.рекурсивнымиФункциямиToolStripMenuItem.Text = "Рекурсивными функциями";
            // 
            // цикламиToolStripMenuItem
            // 
            this.цикламиToolStripMenuItem.Name = "цикламиToolStripMenuItem";
            this.цикламиToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.цикламиToolStripMenuItem.Text = "Циклами";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьГрафикСортировкиВставкамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьГрафикСортировкиВыборомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьГрафикСортировкиПузырькомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВсёГрафикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выборСортировкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рекурсивнымиФункциямиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цикламиToolStripMenuItem;
    }
}

