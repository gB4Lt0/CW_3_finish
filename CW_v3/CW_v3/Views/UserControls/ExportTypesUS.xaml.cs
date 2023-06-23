using System.Windows.Controls;
using CW_v3.ViewModels.Base;

namespace CW_v3.Views.UserControls
{
    public partial class ExportTypesUS : UserControl
    {
        public ExportTypesUS(ViewModel dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}