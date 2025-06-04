namespace TicTacToe.API;

class Program
{
    static void Main(string[] args)
    {
        Webserver webserver = new Webserver();
        webserver.InitializeApp();
    }
}