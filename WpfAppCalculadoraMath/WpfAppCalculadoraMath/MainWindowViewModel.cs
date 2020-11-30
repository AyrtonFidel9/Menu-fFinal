using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;

namespace WpfAppCalculadoraMath
{
    class MainWindowViewModel
    {
        private IDialogCoordinator dialogCoordinator;

        public MainWindowViewModel(IDialogCoordinator instance)
        {
            this.dialogCoordinator = instance;
        }

        // Simple method which can be used on a Button
        public async void FooMessage()
        {
            await this.dialogCoordinator.ShowMessageAsync(this, "Message Title", "Bar");
        }

        public async void FooProgress()
        {
            // Show...
            ProgressDialogController controller = await this.dialogCoordinator.ShowProgressAsync(this, "Wait", "Waiting for the Answer to the Ultimate Question of Life, The Universe, and Everything...");

            controller.SetIndeterminate();

            // Do your work... 
            /*var result = */await Task.Run(()=> {
                Console.WriteLine("CARGANDO...");
            });

            // Close...
            await controller.CloseAsync();
        }
    }
}
