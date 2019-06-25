using App.Interfaces;

namespace App.Controllers
{
    public class AppController
    {
        private readonly ISignController _signController;

        private readonly INoteController _noteController;

        public AppController(ISignController signController, INoteController noteController)
        {
            _signController = signController;
            _noteController = noteController;
        }

        public void Run()
        {
            _signController.Run();
            _noteController.User = _signController.User;
            _noteController.Run();
        }
    }
}