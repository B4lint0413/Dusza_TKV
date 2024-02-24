using System.Windows.Controls;
using DuszaTKVGameLib;

namespace DuszaWpfApp.UserControls;

public partial class LeaderBoardCard : UserControl
{
    public LeaderBoardCard(User user, int placement)
    {
        InitializeComponent();
        Header.Text = $"{placement}. - {user.Name}";
        Points.Text = $"{user.Points} points";
    }
}