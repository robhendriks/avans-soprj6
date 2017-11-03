using Beans;
using FlexAuth.Security;
using GoInsp.Core.Model;
using System;

namespace GoInsp.Security
{
    [Bean]
    public class GoInspCredentials : ICredentials
    {
        #region Properties
    
        [BeanProperty]
        public string Email { get; set; }
        [BeanProperty]
        public string Password { get; set; }
        public object MetaData { get; set; }

        #endregion


        #region Methods

        public bool Check()
        {
            //var user = User.GetByEmailAndPassword(Email, Password);

            //if (user == null)
            //    return false;

            //MetaData = user;
            return true;
        }

        #endregion
    }
}
