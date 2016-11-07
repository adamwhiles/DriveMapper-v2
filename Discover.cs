using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;

namespace DriveMapper_v2
{
    public partial class Discover : Form
    {
        public Discover()
        {
            InitializeComponent();

            List<String> lstGroups = new List<String>();
            UserPrincipal user = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain, "afni.net", "OU=Corporate,DC=afni,DC=net"), Environment.UserName);
            PrincipalSearchResult<Principal> groups = user.GetGroups();
            foreach (var name in groups.Select(x => new {x.SamAccountName, x.Description}))
            {
                if (name.SamAccountName.StartsWith("FG-")) {
                    //lstGroups.Add(name.Description);
                    lstGroups.Add(name.SamAccountName);
                }
            }            
            dataGroups.DataSource = lstGroups.Select(x => new { Path = x}).ToList();
            dataGroups.Columns[0].Width = 535;
        }
    }
}
