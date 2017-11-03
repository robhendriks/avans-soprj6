using GalaSoft.MvvmLight;
using System;
using System.Windows;

namespace GoInsp.Utility
{
    public static class ViewModelBaseExtensions
    {
        #region Methods

        public static void OpenWindow<T>(this ViewModelBase instance) where T : Window
        {
            foreach(Window target in Application.Current.Windows)
            {
                if(target is T)
                {
                    target.Focus();
                    return;
                }
            }

            Window newTarget = Activator.CreateInstance<T>();
            newTarget.Show();
        } 

        #endregion
    }
}
