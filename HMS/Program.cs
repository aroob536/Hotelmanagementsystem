using HMS.Database;
using HMS.Forms;

namespace HMS;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        DbInitializer.Initialize();
        Application.Run(new LoginForm());
    }
}
