using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OldCrypt_GUI.GUI.Modules.CipherControls
{
    /// <summary>
    /// Interaction logic for CipherControl_Asymmetrical.xaml
    /// </summary>
    public abstract partial class CipherControl_Asymmetrical : CipherControl
    {
        public CipherControl_Asymmetrical()
        {
            InitializeComponent();
        }
    }
}
