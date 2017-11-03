using FlexAuth.Security;
using FlexAuth.Security.Generic;
using System;

namespace GoInsp.Security
{
    public class GoInspUser : UserBase
    {
        public GoInspUser()
        {
            SignedIn += GoInspUser_SignedIn;
        }

        protected void GoInspUser_SignedIn(object sender, EventArgs e)
        {
            Nodes = new DummyNodeRepository();
        }
    }
}
