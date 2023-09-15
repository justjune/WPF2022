using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Petzold.ComputerDatingWizard
{
    public partial class WizardPage0
    {
        public WizardPage0()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки "Начать".
        void BeginButtonOnClick(object sender, RoutedEventArgs args)
        {
            if (NavigationService.CanGoForward)
                NavigationService.GoForward();
            else
            {
                Vitals vitals = new Vitals(); // Создание нового экземпляра класса Vitals
                WizardPage1 page = new WizardPage1(vitals); // Создание нового экземпляра класса WizardPage1 с передачей vitals в качестве аргумента
                NavigationService.Navigate(page); // Переход на страницу WizardPage1
            }
        }
    }
}


namespace Petzold.ComputerDatingWizard
{
    public partial class WizardPage1 : Page
    {
        Vitals vitals; // Поле для хранения экземпляра класса Vitals

        // Конструкторы.
        public WizardPage1(Vitals vitals)
        {
            InitializeComponent();
            this.vitals = vitals;
        }

        // Обработчики событий для кнопок "Назад" и "Далее".
        void PreviousButtonOnClick(object sender, RoutedEventArgs args)
        {
            NavigationService.GoBack();
        }

        void NextButtonOnClick(object sender, RoutedEventArgs args)
        {
            vitals.Name = txtboxName.Text; // Присваивание полю Name объекта vitals значения из текстового поля txtboxName
            vitals.Home = Vitals.GetCheckedRadioButton(grpboxHome).Content as string; // Присваивание полю Home объекта vitals значения выбранной радиокнопки из группы grpboxHome
            vitals.Gender = Vitals.GetCheckedRadioButton(grpboxGender).Content as string; // Присваивание полю Gender объекта vitals значения выбранной радиокнопки из группы grpboxGender

            if (NavigationService.CanGoForward)
                NavigationService.GoForward();
            else
            {
                WizardPage2 page = new WizardPage2(vitals); // Создание нового экземпляра класса WizardPage2 с передачей vitals в качестве аргумента
                NavigationService.Navigate(page); // Переход на страницу WizardPage2
            }
        }
    }
}


namespace Petzold.ComputerDatingWizard
{
    public partial class WizardPage3 : Page
    {
        Vitals vitals; // Поле для хранения экземпляра класса Vitals

        // Конструктор.
        public WizardPage3(Vitals vitals)
        {
            InitializeComponent();
            this.vitals = vitals;
        }

        // Обработчики событий для кнопок "Назад" и "Завершить".
        void PreviousButtonOnClick(object sender, RoutedEventArgs args)
        {
            NavigationService.GoBack();
        }

        void FinishButtonOnClick(object sender, RoutedEventArgs args)
        {
            // Сохранение информации с текущей страницы.
            vitals.MomsMaidenName = txtboxMom.Text; // Присваивание полю MomsMaidenName объекта vitals значения из текстового поля txtboxMom
            vitals.Pet = Vitals.GetCheckedRadioButton(grpboxPet).Content as string; // Присваивание полю Pet объекта vitals значения из выбранной радиокнопки в grpboxPet
            vitals.Income = Vitals.GetCheckedRadioButton(grpboxIncome).Content as string; // Присваивание полю Income объекта vitals значения из выбранной радиокнопки в grpboxIncome

            // Всегда создавайте новую конечную страницу.
            WizardPage4 page = new WizardPage4(vitals); // Создание нового экземпляра класса WizardPage4 с передачей vitals в качестве аргумента
            NavigationService.Navigate(page); // Переход на страницу WizardPage4
        }
    }
}


namespace Petzold.ComputerDatingWizard
{
    public partial class WizardPage2
    {
        Vitals vitals; // Поле для хранения экземпляра класса Vitals

        // Конструктор.
        public WizardPage2(Vitals vitals)
        {
            InitializeComponent();
            this.vitals = vitals;
        }

        // Обработчики событий для необязательной кнопки "Обзор".
        void BrowseButtonOnClick(object sender, RoutedEventArgs args)
        {
            DirectoryPage page = new DirectoryPage();
            page.Return += DirPageOnReturn;
            NavigationService.Navigate(page);
        }

        void DirPageOnReturn(object sender, ReturnEventArgs<DirectoryInfo> args)
        {
            if (args.Result != null)
                txtboxFavoriteDir.Text = args.Result.FullName;
        }

        // Обработчики событий для кнопок "Назад" и "Далее".
        void PreviousButtonOnClick(object sender, RoutedEventArgs args)
        {
            NavigationService.GoBack();
        }

        void NextButtonOnClick(object sender, RoutedEventArgs args)
        {
            vitals.FavoriteOS = txtboxFavoriteOS.Text; // Присваивание полю FavoriteOS объекта vitals значения из текстового поля txtboxFavoriteOS
            vitals.Directory = txtboxFavoriteDir.Text; // Присваивание полю Directory объекта vitals значения из текстового поля txtboxFavoriteDir

            if (NavigationService.CanGoForward)
                NavigationService.GoForward();
            else
            {
                WizardPage3 page = new WizardPage3(vitals); // Создание нового экземпляра класса WizardPage3 с передачей vitals в качестве аргумента
                NavigationService.Navigate(page); // Переход на страницу WizardPage3
            }
        }
    }
}


namespace Petzold.ComputerDatingWizard
{
    public class Vitals
    {
        public string Name; // Имя
        public string Home; // Место жительства
        public string Gender; // Пол
        public string FavoriteOS; // Любимая операционная система
        public string Directory; // Каталог
        public string MomsMaidenName; // Девичья фамилия матери
        public string Pet; // Животное
        public string Income; // Доход

        public static RadioButton GetCheckedRadioButton(GroupBox grpbox)
        {
            Panel pnl = grpbox.Content as Panel;
            if (pnl != null)
            {
                foreach (UIElement el in pnl.Children)
                {
                    RadioButton radio = el as RadioButton;
                    if (radio != null && (bool)radio.IsChecked)
                        return radio;
                }
            }
            return null;
        }
    }
}


namespace Petzold.ComputerDatingWizard
{
    public partial class ComputerDatingWizard: Window
    {
        [STAThread]
        public static void Main()//является точкой входа в приложение и создает экземпляр класса Application, после чего запускает основное окно ComputerDatingWizard
        {
            Application app = new Application();
            app.Run(new ComputerDatingWizard());
        }

        public ComputerDatingWizard()//В конструкторе ComputerDatingWizard происходит инициализация компонентов окна (предположительно, это метод InitializeComponent()).
        {
            InitializeComponent();

            // Навигация на страницу приветствия.
            frame.Navigate(new WizardPage0());
        }
    }
}
