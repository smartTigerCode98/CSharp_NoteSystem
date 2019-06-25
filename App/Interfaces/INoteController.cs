using App.Entities;

namespace App.Interfaces
{
    public interface INoteController
    {
        User User { get; set; }
        void Run();
        void ShowAll();
        void Create();
        void Update();
        void Delete();
    }
}