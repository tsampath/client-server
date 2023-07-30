using Microsoft.AspNetCore.SignalR.Client;

namespace Netzsch.ClientServer.Windows
{
    public partial class Input : Form
    {
        private readonly HubConnection hubConnection;
        private const string SERVER_HUB_URL_KEY = "ServerHubUrl";
        private const string SERVER_SEND_MESSAGE = "SendMessage";

        public Input()
        {
            InitializeComponent();

            hubConnection = new HubConnectionBuilder()
               .WithUrl(System.Configuration.ConfigurationManager.AppSettings[SERVER_HUB_URL_KEY]) 
               .Build();

            // Start the connection
            StartConnectionAsync();
        }

        private async void txtInput_TextChanged(object sender, EventArgs e)
        {
            long.TryParse(this.txtInput.Text, out long intInput);
            this.txtOutput.Text = this.GetSquare(intInput).ToString();
            await hubConnection.SendAsync(SERVER_SEND_MESSAGE, this.txtInput.Text, this.txtOutput.Text);

        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private long GetSquare(long input)
        {
            return input * input;
        }

        private async void StartConnectionAsync()
        {
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}");
            }
        }
    }
}