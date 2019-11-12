using System;
using System.Collections.Generic;


namespace EditorTexto.Memento
{
    [Serializable]
    public class CompoundMemento<T> : IMemento<T>
    {
        private List<IMemento<T>> mementos = new List<IMemento<T>>();

        /// <summary>
        /// Adds memento to this complex memento. Note that the order of adding mementos is critical.
        /// </summary>
        /// <param name="m"></param>
        public void Add(IMemento<T> m)
        {
            mementos.Add(m);
        }

        /// <summary>
        /// Gets number of sub-memento contained in this complex memento.
        /// </summary>
        public int Size
        {
            get { return mementos.Count; }
        }

        #region IMemento Members

        /// <summary>
        /// Implicity implememntation of <see cref="IMemento&lt;T&gt;.Restore(T)"/>, which returns <see cref="CompoundMemento&lt;T&gt;"/>
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public CompoundMemento<T> Restore(T target)
        {
            CompoundMemento<T> inverse = new CompoundMemento<T>();
            //starts from the last action
            for (int i = mementos.Count - 1; i >= 0; i--)
                inverse.Add(mementos[i].Restore(target));
            return inverse;
        }

        /// <summary>
        /// Explicity implememntation of <see cref="IMemento&lt;T&gt;.Restore(T)"/>
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        IMemento<T> IMemento<T>.Restore(T target)
        {
            return Restore(target);
        }

        #endregion
    }
}
