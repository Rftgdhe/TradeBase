using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Shapes;
using StoloviePribori.Data;

namespace StoloviePribori
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        private Data.NaumovStoloviePriboriEntities1 Database;
        private static int CaptchaTextLength = 5;
        private String CaptchaText;
        public Authorization()
        {
            InitializeComponent();
            CapchaImage.Source = CreateCaptcha();

            try
            {
                Database = new Data.NaumovStoloviePriboriEntities1();
            }
            catch
            {
                // Вывод сообщения о неверно введенном пароле
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте настройки подключения приложения.",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            User user = SourceCore.DB.User.SingleOrDefault(U => U.UserLogin == LoginTextBox.Text && U.UserPassword == PasswordPasswordBox.Text);
            if ((user != null)&&(CaptchaText == CaptchaTextBox.Text))
            {
                MainWindow Window = new MainWindow();
                Window.Show();
                Close();
            }
            else
            {
                {
                    MessageBox.Show("Неверно указан текст капчи!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            
        }

       

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        public static BitmapImage BitmapToBitmapImage(Bitmap Bitmap)
        {
            // Создание потока
            MemoryStream MemoryStream = new MemoryStream();
            // Сохранение исходного изображения в поток
            Bitmap.Save(MemoryStream, ImageFormat.Png);
            // Установка курсора в начало потока в качестве указателя,
            // откуда начинать читать данные
            MemoryStream.Position = 0;
            // Создание "пустого" изображения класса BitmapImage
            BitmapImage BitmapImage = new BitmapImage();
            // Вход в режим инициализации экземпляра класса
            BitmapImage.BeginInit();
            // Непосредственно чтение содержимого изображения из потока
            BitmapImage.StreamSource = MemoryStream;
            // Задание режима кэширования всего изображения в памяти
            BitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            // Выход из режима инициализации экземпляра класса
            BitmapImage.EndInit();
            // Запрет на дальнейшие изменения изображения
            BitmapImage.Freeze();
            // Возврат результата
            return BitmapImage;
        }

        private BitmapImage CreateCaptcha()
        {
            // ВНИМАНИЕ! Чтобы воспользоваться методами работы с классом Bitmap 
            // и инструментами рисования на нем, требуется подключить модуль System.Drawing!

            // Создание генератора случайных значений
            Random Generator = new Random();
            // Генерация капчи
            CaptchaText = "";
            string Alphabet = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int I = 0; I < CaptchaTextLength; I++)
            {
                CaptchaText += Alphabet[Generator.Next(Alphabet.Length)];
            }

            // ВНИМАНИЕ! Размеры CaptchaImage назначаются с некоторым запаздыванием,
            // поэтому даже дри вызове данной подпрограммы из обработчика события
            // Window_Loaded даст нулевые размеры для CaptchaImage!

            // Задание размеров создаваемого изображения
            // (чтобы изображение не заставляло растягиваться CaptchaImage по вертикали,
            // в его соотношении сторон высота должна быть меньше, чем в соотношении
            // сторон CaptchaImage!)
            int BitmapWidth = 200;
            int BitmapHeight = 100;
            // Создание полотна заданных размеров
            Bitmap Bitmap = new Bitmap(BitmapWidth, BitmapHeight);
            // Создание интерфеса для инструментов рисования на полотне
            Graphics Graphics = Graphics.FromImage(Bitmap);
            // Задание словаря используемых цветов
            System.Drawing.Color[] Colors = {System.Drawing.Color.Black, System.Drawing.Color.Blue,
                System.Drawing.Color.Green, System.Drawing.Color.White,  System.Drawing.Color.Brown,
                System.Drawing.Color.Cornsilk, System.Drawing.Color.DeepPink};
            // Заливка фона изображения
            Graphics.Clear(System.Drawing.Color.Gray);
            // Задание позиции текста на изображении
            int X = Generator.Next(0, BitmapWidth / 5);
            int Y = Generator.Next(10, BitmapHeight / 3);
            // Рисование текста
            Graphics.DrawString(CaptchaText, new Font("Arial Black", 30),
                new SolidBrush(Colors[Generator.Next(Colors.Length)]), new PointF(X, Y));
            // Помехи в виде точек
            for (X = 0; X < BitmapWidth; X++)
            {
                for (Y = 0; Y < BitmapHeight; Y++)
                {
                    if (Generator.Next() % 10 == 0)
                    {
                        Bitmap.SetPixel(X, Y, Colors[Generator.Next(Colors.Length)]);
                    }
                }
            }
            // Помехи в виде линий
            for (int I = 0; I < 20; I++)
            {
                Graphics.DrawLine(new System.Drawing.Pen(Colors[Generator.Next(Colors.Length)], 1),
                    Generator.Next(BitmapWidth), Generator.Next(BitmapHeight),
                    Generator.Next(BitmapWidth), Generator.Next(BitmapHeight));
            }
            // Преобразование созданного изображения к типу BitmapImage для передачи в CaptchaImage
            return BitmapToBitmapImage(Bitmap);
        }

        private void ChangeCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            CapchaImage.Source = CreateCaptcha();
        }
    }
}
