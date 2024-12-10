// Используемые библиотеки и пространства имен
using HandyControl.Controls;
using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using TestSchedule.Command;
using TestSchedule.Controller;
using TestSchedule.Core;
using TestSchedule.Model;

namespace TestSchedule.ViewModel
{
    // Класс MainWindowViewModel, наследующий от BaseViewModel
    public class MainWindowViewModel : BaseViewModel
    {

        // Член класса для генерации случайных чисел
        private readonly Random _random;

        // Член класса для взаимодействия с контроллером MainWindow
        private readonly MainWindowController _controller;

        // Член класса для хранения текущего выбранного факультета
        private string _selectedFaculty;

        // Свойство для доступа к выбранному факультету
        public string SelectedFaculty
        {
            get => _selectedFaculty;
            set
            {
                _selectedFaculty = value;
                OnPropertyChanged(nameof(SelectedFaculty));
            }
        }

        // Член класса для хранения текущей выбранной группы
        private string _selectedGroup;

        // Свойство для доступа к выбранной группе
        public string SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }

        // Член класса для хранения списка расписаний
        private ObservableCollection<Schedule> _listOfSchedule;

        // Свойство для доступа к списку расписаний
        public ObservableCollection<Schedule> ListOfSchedule
        {
            get => _listOfSchedule;
            set
            {
                _listOfSchedule = value;
                OnPropertyChanged(nameof(ListOfSchedule));
            }
        }

        // Член класса для хранения счетчика
        private int _counter = 1;

        // Конструктор класса MainWindowViewModel
        public MainWindowViewModel()
        {

            // Инициализация контроллера MainWindow
            _controller = new MainWindowController();

            // Инициализация генератора случайных чисел
            _random = new Random();

            // Инициализация списка расписаний
            ListOfSchedule = new ObservableCollection<Schedule>();

            // Создание таймера для периодической загрузки данных
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += (sender, e) =>
            {
                // Загрузка данных через диспетчер приложения
                App.Current.Dispatcher.Invoke(() =>
                {
                    LoadData();
                });
            };
            timer.Start();
        }


        // Метод для загрузки данных
        private async void LoadData()
        {
            // Очистка списка расписаний
            ListOfSchedule.Clear();

            try
            {
                // Получение текущего выбранного факультета
                var selectedFaculty = FacultySingleton.FacultyList.FirstOrDefault(faculty => faculty.Key == _counter);

                if (selectedFaculty.Equals(default(KeyValuePair<int, string>)))
                {
                    // Если факультет не найден, прерываем выполнение
                    return;
                }

                // Получение списка групп для выбранного факультета
                var groupList = await _controller.GetGroups(selectedFaculty.Value);

                if (groupList == null || groupList.Count == 0)
                {
                    // Если нет групп для факультета, прерываем выполнение
                    return;
                }

                // Выбор случайной группы из списка
                var groupNumber = _random.Next(0, groupList.Count);

                // Получение расписания для выбранной группы и факультета
                var schedule = await _controller.GetSchedule(groupList[groupNumber], selectedFaculty.Value);

                if (schedule == null || !schedule.Any())
                {
                    // Если расписание пустое или не найдено, прерываем выполнение
                    return;
                }

                // Установка выбранного факультета и группы
                SelectedFaculty = selectedFaculty.Value;
                SelectedGroup = groupList[groupNumber];

                // Перебор всех записей в расписании
                foreach (var scheduleItem in schedule)
                {
                    // Проверка, что хотя бы одно поле в записи расписания не пустое
                    if (scheduleItem.EntryList.Any(entry => entry.IsAnyFieldNotEmpty()))
                    {
                        // Добавление целого объекта Schedule в список, если есть непустые записи
                        ListOfSchedule.Add(scheduleItem);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            // Инкремент счетчика
            if (_counter != FacultySingleton.FacultyList.Count)
            {
                _counter++;
            }
            else
            {
                _counter = 1;
            }
        }


    }
}
