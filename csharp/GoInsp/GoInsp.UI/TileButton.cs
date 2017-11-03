using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GoInsp.UI
{
    public class TileButton : Button
    {
        #region Constructors

        static TileButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TileButton)
                , new FrameworkPropertyMetadata(typeof(TileButton)));
        }

        #endregion


        #region Properties

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image"
            , typeof(ImageSource), typeof(TileButton), new PropertyMetadata());

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        #endregion
    }
}
