using System.Windows.Controls;
using DuszaTKVGameLib;

namespace DuszaWpfApp.UserControls
{
    /// <summary>
    /// Interaction logic for UserHeader.xaml
    /// </summary>
    public partial class UserHeader : UserControl
    {
        public UserHeader(User player)
        {
            InitializeComponent();

            PlayerInfo.Text = $"{player.Name}\t{player.Points} Points";
        }
    }
}
