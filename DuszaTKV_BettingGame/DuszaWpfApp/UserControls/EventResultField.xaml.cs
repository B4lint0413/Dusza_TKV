using System.Windows.Controls;
using DuszaTKVGameLib;

namespace DuszaWpfApp.UserControls;

public partial class EventResultField : UserControl
{
    private readonly Event _event;
    public EventResultField(Event e)
    {
        InitializeComponent();
        _event = e;
        Label.Content = $"{_event.Name} - {_event.Subject}";
    }
}