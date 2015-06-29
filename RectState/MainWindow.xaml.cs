using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace RectState {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// </summary>
    /// 
    public partial class MainWindow : Window {
        public static int count = 6;
        DispatcherTimer timer;
        TimeSpan time;
        int colorC = 2;
        int size = 60;
        Random rand;
        RectSet rectSet;
        bool timerStart;
        public MainWindow() {
            rand = new Random();
            rectSet = new RectSet();
            for(int i = 0; i < count; i++) {
                for(int j = 0; j < count; j++) {
                    rectSet.rectArray[i, j] = new Rect(size, new SolidColorBrush(Colors.Green), new SolidColorBrush(Colors.Red), size * i, size * j, rand.Next(colorC));
                }
            }
            InitializeComponent();
            for(int i = 0; i < count; i++)
                for(int j = 0; j < count; j++)
                    rectField.Children.Add(rectSet.rectArray[i, j].rect);
            timer = new DispatcherTimer();
            time = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = time;
            timerStart = true;

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if(timerStart) {
                timer.Start();
                timerStart = false;
            }
            else {
                timer.Stop();
                timerStart = true;
            }
        }
        void timer_Tick(object sender, EventArgs e) {
            for(int i = 0; i < count; ++i)
                for(int j = 0; j < count; ++j) {
                    int tempi = i, tempj = j;
                    Task.Run(() => {
                        lock(this) {
                            rectSet.changeState(tempi, tempj);
                        }
                    });
                }
        }
    }
}
