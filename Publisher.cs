using System;
namespace learncsharp
{
    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(string data)
        {
            this.data = data;
        }
        // Lưu dữ liệu gửi đi từ publisher
        private string data;

        public string Data
        {
            get { return data; }
        }
    }
    public class UserInput
    {
        public event EventHandler send;
        public UserInput()
        {
            do
            {
                string value = Console.ReadLine() ?? "0";
                send?.Invoke(this, new MyEventArgs(value));
            } while (true);
        }
    }

    public class SubscriberA
    {
        public void Sub(UserInput p)
        {
            p.send += ReceiverFromPublisher;
        }

        private void ReceiverFromPublisher(object sender, EventArgs e)
        {
            MyEventArgs x = (MyEventArgs)e;
            Console.WriteLine("ClassC: " + x.Data);
        }
    }

}