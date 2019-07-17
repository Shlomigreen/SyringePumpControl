using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace PumpControl
{
    class Port
    {
        public string COM { get; }
        public int Baudrate { get; }
        Parity parity { get; }
        int Databits { get; }
        StopBits stopbits { get; }

        public SerialPort port { get; set; }
        public bool IsOpen { get; private set; } = false;

        public Port(String com, int baudrate = 19200, Parity _parity = Parity.None, int databits = 8, StopBits _stopbits = StopBits.One)
        {
            COM = com;
            Baudrate = baudrate;
            parity = _parity;
            Databits = databits;
            stopbits = _stopbits;
        }

        public void Connect()
        {
            port = new SerialPort(COM, Baudrate, parity, Databits, stopbits);
            port.Open();
            IsOpen = true;
        }
        public void Disconnect()
        {
            port.Close();
            IsOpen = false;
        }

        public void Send(string str)
        {
            port.WriteLine(str);
        }
        
    }
}
