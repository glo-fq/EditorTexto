using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorTexto.Model
{
    class Caretaker
    {
        private Memento mementoActual;
        private List<Memento> mementoList = new List<Memento>();

        public void add(Memento state)
        {
            mementoList.Add(state);
            MementoActual();
            
        }

        public Memento undo()
        {
            if (mementoActual == null)
            {
                MementoActual();

            }

            int index = indiceMementoActual(); 
            mementoActual = mementoList.ElementAt(index - 1);
            return mementoList.ElementAt(index - 1);

        }
        public int indiceMementoActual() {
            if (mementoActual == null) {
                MementoActual();
            }
            return mementoList.IndexOf(mementoActual);
        }
        public Memento redo() {
            if (mementoActual == null)
            {
                MementoActual();

            }
            int index = indiceMementoActual();
            mementoActual = mementoList.ElementAt(index + 1);
            return mementoList.ElementAt(index + 1);
        }
        public void MementoActual() {
            mementoActual = mementoList.ElementAt(size()-1);
        }
        public int size() {
            return mementoList.Count;
        }
    }
}
