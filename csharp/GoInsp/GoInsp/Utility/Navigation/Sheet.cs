using System;
using System.Windows;

namespace GoInsp.Utility.Navigation
{
    public sealed class Sheet : ISheet
    {
        #region Fields

        private Sheets _parent;
        private Uri _uri;

        #endregion


        #region Constructors

        public Sheet(Sheets parent, Uri uri)
        {
            if (parent == null)
                throw new ArgumentNullException("parent");
            else if (uri == null)
                throw new ArgumentNullException("uri");

            _parent = parent;
            _uri = uri;
        }

        #endregion


        #region Properties

        public Uri Uri
        {
            get { return _uri; }
        }

        #endregion
    }
}
