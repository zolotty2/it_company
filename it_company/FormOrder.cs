using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace it_company
{
    public partial class FormOrder : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormOrder(User user, bool isGuest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = isGuest;

            // Настройка DataGridView
            DgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvTasks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DgvTasks.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DgvTasks.AllowUserToAddRows = false;
            DgvTasks.AllowUserToDeleteRows = false;
            DgvTasks.ReadOnly = true;
            DgvTasks.RowHeadersVisible = false;
            DgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvTasks.MultiSelect = false;
            DgvTasks.BackgroundColor = Color.White;
            DgvTasks.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            DgvTasks.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Добавляем обработчик для форматирования ячеек
            DgvTasks.CellFormatting += DgvTasks_CellFormatting;
            DgvTasks.RowPrePaint += DgvTasks_RowPrePaint;

            // Добавляем колонку для информации о задаче
            var ColInfo = new DataGridViewTextBoxColumn
            {
                Name = "ColInfo",
                HeaderText = "Информация о задаче",
                FillWeight = 100,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            };
            DgvTasks.Columns.Add(ColInfo);

            // Добавляем колонку для дней до дедлайна
            var ColDaysToDeadline = new DataGridViewTextBoxColumn
            {
                Name = "ColDaysToDeadline",
                HeaderText = "Дней до дедлайна",
                FillWeight = 30,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };
            DgvTasks.Columns.Add(ColDaysToDeadline);

            // Добавляем скрытую колонку для хранения ID задачи
            var ColId = new DataGridViewTextBoxColumn
            {
                Name = "TaskId",
                HeaderText = "ID",
                Visible = false
            };
            DgvTasks.Columns.Add(ColId);

            // Отображаем имя пользователя
            lblUserName.Text = IsGuest ? "Гость" : $"{CurrentUser?.Fio ?? "Неизвестный"}";

            // Загружаем задачи
            LoadTasks();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadTasks()
        {
            try
            {
                using (var db = new ItComContext())
                {
                    // Загружаем задачи с навигационными свойствами
                    var tasks = db.Tasks
                        .Include(t => t.Status)
                        .Include(t => t.Priority)
                        .Include(t => t.Project)
                        .ToList();

                    DgvTasks.Rows.Clear();

                    foreach (var task in tasks)
                    {
                        int rowIndex = DgvTasks.Rows.Add();
                        var row = DgvTasks.Rows[rowIndex];

                        // Сохраняем ID задачи в скрытой колонке
                        row.Cells["TaskId"].Value = task.Id;

                        // Формируем информацию о задаче с расчётом плановой длительности
                        row.Cells["ColInfo"].Value = GetTaskInfo(task);

                        // Рассчитываем и отображаем дни до дедлайна
                        row.Cells["ColDaysToDeadline"].Value = CalculateDaysToDeadline(task.DateOfEnd);

                        // Сохраняем данные задачи в тегах строки для использования при форматировании
                        row.Tag = new TaskInfo
                        {
                            Priority = task.Priority?.PriorityName,
                            Status = task.Status?.StatusName,
                            DateOfEnd = task.DateOfEnd,
                            DateOfCreate = task.DateOfCreate
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки задач: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTaskInfo(Task task)
        {
            // Расчёт плановой длительности (разница между датой создания и плановой датой завершения)
            string durationInfo = CalculateDuration(task.DateOfCreate, task.DateOfEnd);

            return $"Задача: {task.TaskName}\n" +
                   $"Описание: {task.Description}\n" +
                   $"Статус: {task.Status?.StatusName ?? "Не указан"}\n" +
                   $"Приоритет: {task.Priority?.PriorityName ?? "Не указан"}\n" +
                   $"Проект: {task.Project?.Name ?? "Не указан"}\n" +
                   $"Исполнитель: {task.Executor}\n" +
                   $"Дата создания: {task.DateOfCreate:dd.MM.yyyy}\n" +
                   (task.DateOfEnd.HasValue ? $"Плановая дата завершения: {task.DateOfEnd:dd.MM.yyyy}" : "Плановая дата завершения: не указана") + "\n" +
                   $"Плановая длительность: {durationInfo}";
        }

        /// <summary>
        /// Вычисляет количество дней между датой создания и плановой датой завершения.
        /// </summary>
        private string CalculateDuration(DateOnly dateOfCreate, DateOnly? dateOfEnd)
        {
            if (!dateOfEnd.HasValue)
                return "не определена";

            int days = dateOfEnd.Value.DayNumber - dateOfCreate.DayNumber;
            return $"{days} дн.";
        }

        /// <summary>
        /// Вычисляет количество дней до дедлайна (отрицательное, если дедлайн прошел)
        /// </summary>
        private string CalculateDaysToDeadline(DateOnly? dateOfEnd)
        {
            if (!dateOfEnd.HasValue)
                return "-";

            var today = DateOnly.FromDateTime(DateTime.Today);
            int daysToDeadline = dateOfEnd.Value.DayNumber - today.DayNumber;

            return daysToDeadline.ToString();
        }

        private void DgvTasks_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= DgvTasks.Rows.Count)
                return;

            var row = DgvTasks.Rows[e.RowIndex];

            // Получаем сохраненные данные задачи из Tag
            if (row.Tag is TaskInfo taskInfo)
            {
                bool isHighPriority = taskInfo.Priority?.Equals("Высокий", StringComparison.OrdinalIgnoreCase) ?? false;
                bool isCompleted = taskInfo.Status?.Equals("Завершена", StringComparison.OrdinalIgnoreCase) ?? false;
                bool isOverdue = IsTaskOverdue(taskInfo.DateOfEnd);

                // Применяем цвета фона в зависимости от условий
                if (isCompleted)
                {
                    // Завершенные задачи - светло-серый фон
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (isHighPriority)
                {
                    // Высокий приоритет и не завершено - желтый #FFF3CD
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                    row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                }
                else if (isOverdue)
                {
                    // Просрочено и не завершено - красный #F8D7DA
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8D7DA");
                    row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#721C24");
                }
                else
                {
                    // Обычные задачи - белый фон
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void DgvTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Дополнительное форматирование для ячеек с днями до дедлайна
            if (e.ColumnIndex == DgvTasks.Columns["ColDaysToDeadline"].Index && e.RowIndex >= 0)
            {
                if (e.Value != null && e.Value.ToString() != "-")
                {
                    if (int.TryParse(e.Value.ToString(), out int days))
                    {
                        // Можно добавить префикс для отрицательных значений
                        if (days < 0)
                        {
                            e.Value = $"{days} (просрочено)";
                            e.CellStyle.ForeColor = ColorTranslator.FromHtml("#721C24");
                            e.CellStyle.Font = new Font(DgvTasks.Font, FontStyle.Bold);
                        }
                        else if (days == 0)
                        {
                            e.Value = $"{days} (сегодня)";
                            e.CellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                            e.CellStyle.Font = new Font(DgvTasks.Font, FontStyle.Bold);
                        }
                        else
                        {
                            e.Value = $"{days}";
                        }
                    }
                }
            }
        }

        private bool IsTaskOverdue(DateOnly? dateOfEnd)
        {
            if (!dateOfEnd.HasValue)
                return false;

            var today = DateOnly.FromDateTime(DateTime.Today);

            // Задача просрочена, если плановая дата завершения меньше сегодняшней даты
            return dateOfEnd.Value < today;
        }

        // Вспомогательный класс для хранения информации о задаче
        private class TaskInfo
        {
            public string? Priority { get; set; }
            public string? Status { get; set; }
            public DateOnly? DateOfEnd { get; set; }
            public DateOnly DateOfCreate { get; set; }
        }
    }
}