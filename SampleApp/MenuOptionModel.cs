using System.Windows.Input;

namespace SampleApp
{
    public class MenuOptionModel
    {
        public string Nombre { get; set; } 
        public ICommand Accion { get; set; }
    }
}