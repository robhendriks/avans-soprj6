using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GoInsp.ViewModel
{
    public class BaseViewModel : ViewModelBase, IDataErrorInfo
    {
        #region Properties

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                return OnValidate(columnName);
            }
        }

        #endregion


        #region Methods

        protected virtual string OnValidate(string columnName)
        {
            var validationResults = new List<ValidationResult>();

            if (Validator.TryValidateProperty(GetType().GetProperty(columnName).GetValue(this)
                , new ValidationContext(this)
                {
                    MemberName = columnName
                }, 
                validationResults))
            {
                return null;
            }

            return validationResults.First().ErrorMessage;
        }

        #endregion
    }
}