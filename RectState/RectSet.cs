using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace RectState {
    class RectSet {

        public Rect[,] rectArray;
        public RectSet() {
            rectArray = new Rect[MainWindow.count, MainWindow.count];

        }
        public int checkNeighbours(int i, int j) {
            int countN = 0;
            {
                int k = i, l = j;
                if(k == 0)
                    k = MainWindow.count - 1;
                else
                    --k;
                if(rectArray[k, l].State)
                    ++countN;

                k = i; l = j;
                if(k == MainWindow.count - 1)
                    k = 0;
                else
                    ++k;
                if(rectArray[k, l].State)
                    ++countN;

                k = i; l = j;
                if(l == 0)
                    l = MainWindow.count - 1;
                else
                    --l;
                if(rectArray[k, l].State)
                    ++countN;

                k = i; l = j;
                if(l == MainWindow.count - 1)
                    l = 0;
                else
                    ++l;
                if(rectArray[k, l].State)
                    ++countN;
            }
            return countN;
        }
        public void changeState(int i, int j) {
            if(checkNeighbours(i, j) % 2 == 0)
                rectArray[i, j].changeState();
        }
    }

}
