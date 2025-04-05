//Садрисламов Реваль ПМ-201 , ввод и вывод в окно

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Настройки окна
            this.Text = "Reval App";
            this.ClientSize = new Size(800,700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Создаем надпись
            Label label = new Label
            {
                Text = "reval",
                Font = new Font("Arial", 140, FontStyle.Bold),
                ForeColor = Color.Blue,
                AutoSize = true
            };

            // Создаем кнопки
            Button button1 = new Button
            {
                Text = "Кнопка 1",
                Size = new Size(200, 150),
                BackColor = Color.LightGray
            };

            Button button2 = new Button
            {
                Text = "Кнопка 2",
                Size = new Size(200, 150),
                BackColor = Color.LightGray
            };

            // Располагаем элементы с помощью TableLayoutPanel для лучшего управления
            TableLayoutPanel tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(10)
            };

            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30));

            // Добавляем элементы в таблицу
            tableLayout.Controls.Add(label, 0, 0);
            tableLayout.Controls.Add(button1, 0, 1);
            tableLayout.Controls.Add(button2, 0, 2);

            // Центрируем элементы в ячейках
            label.Anchor = AnchorStyles.None;
            button1.Anchor = AnchorStyles.None;
            button2.Anchor = AnchorStyles.None;

            // Добавляем таблицу на форму
            this.Controls.Add(tableLayout);

            // Обработчики событий для кнопок (пример)
            button1.Click += (sender, e) => MessageBox.Show("Нажата Кнопка 1");
            button2.Click += (sender, e) => MessageBox.Show("Нажата Кнопка 2");
        }
    }
}   