using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PCAN_Mac.ViewModels
{
    public class MessageItem : INotifyPropertyChanged
    {
        public uint RawID { get; }
        public string ID => $"0x{RawID:X3}";
        public int DataLen { get; }
        private string _timestamp = "";
        public string Timestamp
        {
            get => _timestamp;
            set { _timestamp = value; OnPropertyChanged(); }
        }

        private string _dataHex = "";
        public string DataHex
        {
            get => _dataHex;
            set { _dataHex = value; OnPropertyChanged(); }
        }

        public MessageItem(uint id, string ts, int len, string data)
        {
            RawID = id;
            Timestamp = ts;
            DataLen = len;
            DataHex = data;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}