using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Translator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> dict = new Dictionary<string, string>()
        {
            { "a","ф"},
{"b","и"},
{"c","с"},
{"d","в"},
{"e","у"},
{"f","а"},
{"g","п"},
{"h","р"},
{"i","ш"},
{"j","о"},
{"k","л"},
{"l","д"},
{"m","ь"},
{"n","т"},
{"o","щ"},
{"p","з"},
{"q","й"},
{"r","к"},
{"s","ы"},
{"t","е"},
{"u","г"},
{"v","м"},
{"w","ц"},
{"x","ч"},
{"y","н"},
{".","ю"},
{",","б"},
{"]","ъ"},
{"[","х"},
{"'","э"},
{";","ж"},
{"`","ё"},
{"z","я" }

        };
        bool canHandleMouseClick = false;
        bool isValidate = true;
        bool isEng = true;
        Dictionary<string, string> vocabulary;
        Dictionary<string, string> wrongAns = new Dictionary<string, string>();
        Random random = new Random();
        int count = 0;
        int steps = 30;
        public MainWindow()
        {
            InitializeComponent();
            vocabularyExercise();
        }
        private void isEnglish(string s)
        {
            if (dict.Keys.Contains(s)) isEng = true;
            else isEng = false;
        }
        private void translate(string text)
        {
            string ans = "", lang = "";
            List<string> l = new List<string>();
            foreach (var i in text.ToCharArray())
            {
                l.Add(i.ToString());
                if (dict.Keys.Contains(l[0])) isEng = true;
                else isEng = false;
            }
            //    if (dict.Keys.Contains(l[0])) lang = "en";
            //else lang = "ru";
            foreach (var k in l)
            {
                if (k == " " || k == "\r" || k == "\n") ans += k;
                else if (isEng == true) ans += dict[k];
                else ans += findItem(k);
            }
            textBlock.Text = "";
            textBox1.Text = ans;
        }
        private void validation(string text)
        {
            string i;
            var list_text = text.ToCharArray();
            foreach (var j in list_text)
            {
                i = j.ToString();
                if (!dict.Keys.Contains(i) && !dict.Values.Contains(i) && i != " " && i != "\n" && i != "\r")
                {
                    MessageBox.Show(i);
                    isValidate = false;
                    break;
                }
            }
            if (isValidate) translate(text);
            else { textBlock.Text = "Введены некорректные символы"; canHandleMouseClick = true; }
            
        }
        private string findItem(string item)
        {
            string ans = "";
            foreach (var p in dict) if (p.Value == item) ans = p.Key;
            return ans;
        }
        private void onClick(object sender, RoutedEventArgs e)
        {
            try {
                canHandleMouseClick = false;
                validation(textBox1.Text);
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void textBox1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (canHandleMouseClick)
            {
                textBlock.Text = "";
                textBox1.Text = "";
                canHandleMouseClick = false;
            }
        }
        private void onClick2(object sender, RoutedEventArgs e)
        {
            if (steps == 0)
            {
                string list = $"Неправильных ответов: {count}\n";
                foreach (var i in wrongAns)
                {
                    list += $"{i.Key}: {i.Value}\n";
                }
                MessageBox.Show(list);
                steps = 30;
                vocabularyExercise();
            } else
            {
                string ans = answer.Text;
                checkAnswer(ans, keyWord.Text);
                vocabulary.Remove(keyWord.Text);
                answer.Text = "";
                setWord();
                steps--;
            }
        }
        private void vocabularyExercise()
        {
            var wordString = "Hardware — аппаратное обеспечение\r\nSoftware — программное обеспечение\r\nSystem — система\r\nInterface — интерфейс\r\nSecurity — безопасность\r\nCloud — облако (облачное хранилище)\r\nNetwork — сеть\r\nServer — сервер\r\nApplication — приложение\r\nAlgorithm — алгоритм\r\nCode — код\r\nBug — ошибка в программе\r\nCompiler — компилятор\r\nInterpreter — интерпретатор\r\nDebugging — отладка\r\nFramework — фреймворк\r\nLibrary — библиотека\r\nAPI — интерфейс программирования приложений\r\nIDE — интегрированная среда разработки\r\nFrontend — фронтенд\r\nBackend — бэкенд\r\nFull-stack — фулстек\r\nUI — пользовательский интерфейс\r\nUX — пользовательский опыт\r\nWeb Developer — веб-разработчик\r\nAgile — гибкая методология\r\nScrum — скрам\r\nSprint — спринт\r\nDevOps — девопс\r\nTesting — тестирование\r\nCode review — код-ревью\r\nVersion control — контроль версий\r\nCPU (Central Processing Unit) — Центральный процессор (основной компонент компьютера, отвечающий за обработку команд)\r\nGPU (Graphics Processing Unit) — Графический процессор (специализированный процессор для обработки графики и визуальных вычислений)\r\nRAM (Random Access Memory) — Оперативная память (временное хранилище данных, к которому процессор может получить быстрый доступ)\r\nSSD (Solid-State Drive) — Твердотельный накопитель (устройство хранения данных на основе микросхем памяти)\r\nHDD (Hard Disk Drive) — Жесткий диск (механическое устройство хранения данных с магнитными дисками)\r\nMotherboard (Mainboard) — Материнская плата (основная системная плата, объединяющая все компоненты компьютера)\r\nFirewall — межсетевой экран\r\nEncryption — шифрование\r\nAuthentication — аутентификация\r\nMalware — вредоносное ПО\r\nPhishing — фишинг\r\nBackup — резервная копия\r\nPython — питон\r\nJava — джава\r\nC++ — си-плюс-плюс\r\nJavaScript — джаваскрипт\r\nDeveloper — разработчик\r\nQA Engineer — инженер по качеству\r\nProject Manager — менеджер проектов\r\nSystem Administrator — системный администратор\r\nData Scientist — специалист по данным\r\nDatabase — база данных\r\nDBMS (Database Management System) — система управления базами данных\r\nSQL (Structured Query Language) — язык структурированных запросов\r\nNoSQL — нереляционная база данных\r\nSchema — схема базы данных\r\nEntity — сущность\r\nRelationship — связь\r\nTable — таблица\r\nRecord — запись\r\nField — поле\r\nColumn — колонка\r\nRow — строка\r\nIndex — индекс\r\nKey — ключ\r\nPrimary Key — первичный ключ\r\nForeign Key — внешний ключ\r\nSelect — выборка\r\nInsert — вставка\r\nUpdate — обновление\r\nDelete — удаление\r\nQuery — запрос\r\nJoin — объединение\r\nFilter — фильтрация\r\nSort — сортировка\r\nRelational Database — реляционная база данных\r\nHierarchical Database — иерархическая база данных\r\nDocument-oriented Database — документоориентированная база данных\r\nGraph Database — графовая база данных\r\nServer — сервер базы данных\r\nClient — клиент\r\nConnection — подключение\r\nTransaction — транзакция\r\nBackup — резервное копирование\r\nRestore — восстановление\r\nAdmin — администратор\r\nPermissions — разрешения\r\nSecurity — безопасность\r\nPerformance — производительность\r\nOptimization — оптимизация\r\nMonitoring — мониторинг\r\nKeyboard — клавиатура\r\nMouse — мышь\r\nScanner — сканер\r\nWebcam — веб-камера\r\nMicrophone — микрофон\r\nTouchpad — тачпад\r\nTrackball — трекбол\r\nBarcode Reader — считыватель штрих-кодов\r\nMonitor — монитор\r\nPrinter — принтер\r\nPlotter — плоттер\r\nSpeaker — колонки\r\nHeadphones — наушники\r\nProjector — проектор\r\nUSB Flash Drive — USB-накопитель\r\nExternal Hard Drive — внешний жёсткий диск\r\nMemory Card — карта памяти\r\nCD/DVD Drive — оптический привод\r\nModem — модем\r\nRouter — роутер\r\nSwitch — коммутатор\r\nHub — концентратор\r\nNetwork Card — сетевая карта\r\nGraphics Tablet — графический планшет\r\nGame Controller — игровой контроллер\r\nBiometric Scanner — биометрический сканер\r\nTouchscreen — сенсорный экран\r\nJoypad — джойстик\r\nPort — порт подключения\r\nConnector — разъём\r\nInterface — интерфейс подключения\r\nDriver — драйвер устройства\r\nPlug and Play — технология Plug and Play\r\nUSB — универсальный последовательный порт\r\nHDMI — интерфейс для передачи видео и аудио\r\nBluetooth — технология беспроводной связи\r\nWi-Fi — беспроводная сеть\r\nResolution — разрешение\r\nSpeed — скорость работы\r\nCapacity — ёмкость\r\nCompatibility — совместимость\r\nConnectivity — возможности подключения";
            string[] list = wordString.Split(new[] { "\r\n" }, StringSplitOptions.None);
            Dictionary<string, string> vocab = new Dictionary<string, string>();
            foreach (var i in list)
            {
                vocab[i.Substring(i.IndexOf('—') + 2)] = i.Substring(0, i.IndexOf('—') - 1);
            }
            vocabulary = vocab;
            setWord();
            //while (vocab.Count > 0)
            //{
            //    //int x = random.Next(0, vocab.Count);
            //    //var key = vocab.Keys.ElementAt(x);
            //    //keyWord.Text = key;
            //    ////Console.WriteLine(key);
            //    //string ans = answer.Text;
            //    ////string ans = Console.ReadLine();
            //    //if (vocab[key].ToLower().Contains(ans))
            //    //{
            //    //    rightAnswer.Text = "Right! " + vocab[key];
            //    //}
            //    //else
            //    //{
            //    //    rightAnswer.Text = "Wrong. Answer: " + vocab[key];
            //    //}
            //    //vocab.Remove(key);
            //    ////Console.WriteLine();
            //    setWord(vocab, random);
            //}
        

        }
        private void setWord()
        {
            int x = random.Next(0, vocabulary.Count);
            var key = vocabulary.Keys.ElementAt(x);
            keyWord.Text = key;
        }
        private void checkAnswer(string answer, string key)
        {
            if (vocabulary[key].ToLower().Contains(answer))
            {
                rightAnswer.Text = "Right! " + vocabulary[key];
                bgItem.Background = System.Windows.Media.Brushes.LightGreen;
            }
            else
            {
                count++;
                wrongAns[key] = vocabulary[key] + " " + answer;
                rightAnswer.Text = "Wrong. Answer: " + vocabulary[key];
                bgItem.Background = System.Windows.Media.Brushes.PaleVioletRed;
            }
        }

    }
}