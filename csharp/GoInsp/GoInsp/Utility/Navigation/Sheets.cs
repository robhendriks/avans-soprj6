using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace GoInsp.Utility.Navigation
{
    public sealed class Sheets : DependencyObject
    {
        #region Constants

        private const string UriProtocol = "pack";
        private const string UriHost = "application";
        private const string UriFormat = "{0}://{1}:,,,/{2}/";
        private const string UriExtension = ".xaml";

        #endregion


        #region Fields

        private string _uriBase;
        private string _default;
        private Dictionary<string, ISheet> _sheets;

        #endregion


        #region Constructors

        public Sheets()
        {
            _sheets = new Dictionary<string, ISheet>();
            Command = new RelayCommand<string>(OnCommand);
        }

        #endregion


        #region Properties

        public string UriBase
        {
            get { return _uriBase; }
            set
            {
                _uriBase = string.Format(UriFormat, UriProtocol
                    , UriHost, FormatUri(value) ?? "");
            }
        }

        public string Default
        { 
            get { return _default; }
            set
            {
                _default = FormatUri(value)?.ToLower();
            }
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source"
            , typeof(Uri), typeof(Sheets), new FrameworkPropertyMetadata(null));

        public Uri Source
        {
            get { return (Uri)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command"
            , typeof(ICommand), typeof(Sheets), new FrameworkPropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #endregion


        #region Operators

        public string this[string name]
        {
            set
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
                    return;

                _sheets.Add(name.Trim().ToLower()
                    , new Sheet(this, BuildUri(value)));
            }
        }

        #endregion


        #region Methods

        public void GoToDefault()
        {
            GoTo(Default);
        }

        public void GoTo(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;

            ISheet result;
            _sheets.TryGetValue(name.Trim().ToLower(), out result);
            GoTo(result);
        }

        private void GoTo(ISheet sheet)
        {
            if (sheet == null || sheet.Uri == null)
                return;

            Source = sheet.Uri;
        }

        private void OnCommand(string param)
        {
            GoTo(param);
        }

        private string FormatUri(string uri)
        {
            if (string.IsNullOrEmpty(uri))
                return uri;

            return uri.Trim('/','\\');
        }

        private Uri BuildUri(string uri)
        {
            if (uri == null)
                return null;

            try
            {
                return new Uri((UriBase ?? "") + FormatUri(uri) + (UriBase != null ? UriExtension : ""));
            }
            catch(UriFormatException ex)
            {
                return null;
            }
        }

        #endregion
    }
}
