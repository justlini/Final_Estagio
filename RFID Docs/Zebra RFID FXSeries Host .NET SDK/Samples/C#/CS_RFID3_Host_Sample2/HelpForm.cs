using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;


namespace CS_RFID3_Host_Sample2
{
    public partial class HelpForm : Form
    {
        private AppForm m_AppForm;

        public HelpForm(AppForm appForm)
        {
            m_AppForm = appForm;
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            if (null != m_AppForm.m_ReaderAPI)
            {
                this.dllVersionLabel.Text += ("DLL Version: " + m_AppForm.m_ReaderAPI.VersionInfo.Version);
            }
        }

        private string GetSymbolDotNetDllVersion()
        {
            //This handler is called only when the common language runtime tries to bind to the assembly and fails.

            //Retrieve the list of referenced assemblies in an array of AssemblyName.
            Assembly objExecutingAssemblies;
            
            objExecutingAssemblies = Assembly.GetExecutingAssembly();
            AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

            //Loop through the array of referenced assembly names.
            foreach (AssemblyName strAssmbName in arrReferencedAssmbNames)
            {
                //Check for the assembly names that have raised the "AssemblyResolve" event.
                if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == "Symbol.RFID3.Host")
                {

                    return strAssmbName.Version.ToString();
                }
            }
            return null;
        }
    }
}