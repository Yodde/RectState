using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace RectState {
    public class Rect : UIElement {
        int size;
        const int colorC = 2;
        public Rectangle rect;
        SolidColorBrush[] fillColor;
        bool state;
        public bool State {
            get {return state;}
        }
        
        //double placementX, placementY;
        public Rect(int size, SolidColorBrush fillColor, SolidColorBrush secondFillColor, double x, double y, int whichColor) {
            this.size = size;
            this.fillColor = new SolidColorBrush[colorC];
            this.fillColor[0] = fillColor;
            this.fillColor[1] = secondFillColor;
            rect = new Rectangle();
            rect.Width = size;
            rect.Height = size;
            Canvas.SetTop(rect, x);
            Canvas.SetLeft(rect, y);
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.Fill = this.fillColor[whichColor];
            if(whichColor == 0)
                state = false;
            else
                state = true;

        }
        public Rect() { }
        public void changeState() {
            if(!state) {
                rect.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                        new Action(() =>rect.Fill = fillColor[1]));
                state = true;
            }
            else {
                rect.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                         new Action(() => rect.Fill = fillColor[0]));
                state = false;
            }
        }
    }
}
