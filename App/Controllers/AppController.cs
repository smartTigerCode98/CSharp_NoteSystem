
namespace App.Controllers
{
    public class AppController
    {
        private readonly SignController _signController;

        private readonly NoteController _noteController;

        public AppController(SignController signController, NoteController noteController)
        {
            _signController = signController;
            _noteController = noteController;
        }

        public void Run()
        {
            _signController.Run();
            _noteController.Run();
        }
    }
}