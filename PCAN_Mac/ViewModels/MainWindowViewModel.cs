using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PCAN_Mac.Enums;
using PCAN_Mac.Models;

namespace PCAN_Mac.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly CanReader _model = new();
    private readonly Dictionary<uint, MessageItem> _map   = new();
    public IEnumerable<TPCANBaudrate> BaudRates => Enum.GetValues<TPCANBaudrate>();

    public ObservableCollection<MessageItem> Messages { get; } = new();

    [ObservableProperty]
    private string _canButtonText = "Start CAN";
    [ObservableProperty]
    private TPCANBaudrate _baudrate = TPCANBaudrate.PCAN_BAUD_1M;
    
    private bool _isRunning;

    public MainWindowViewModel()
    {
        _model.MessageReceived += OnMessageReceived;
    }
    
    [RelayCommand]
    private Task ToggleAsync()
    {
        if (_isRunning)
        {
            _model.Stop();
            CanButtonText = "Start CAN";
        }
        else
        {
            var status = _model.Initialize(pcanBaudrate:Baudrate);
            if (status != TPCANStatus.PCAN_ERROR_OK)
            {
                //Console.WriteLine("something went wrong");
                return Task.CompletedTask;
            }
            
            _model.Start();
            CanButtonText = "Stop CAN";
        }
        _isRunning = !_isRunning;
        
        return Task.CompletedTask;
    }

    private void OnMessageReceived(object? sender, CanMessageEventArgs e)
    {
        Dispatcher.UIThread.Post(() =>
        {
            var hexes = e.Data
                .Select(b => b.ToString("X2"))
                .ToList();
            var hexString = string.Join(" ", hexes);

            if (_map.TryGetValue(e.Id, out var existing))
            {
                existing.Timestamp = e.Timestamp;
                existing.DataHex   = hexString;
            }
            else
            {
                var item = new MessageItem(e.Id, e.Timestamp, e.Len, hexString);
                _map[e.Id] = item;

                int idx = 0;
                while (idx < Messages.Count && Messages[idx].RawID < e.Id)
                    idx++;
                Messages.Insert(idx, item);
            }
        });
    }
    [RelayCommand]
    private void Clear()
    {
        Messages.Clear();
        _map.Clear();
    }
}