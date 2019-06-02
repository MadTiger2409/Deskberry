using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.UWP.Services.Interfaces
{
    public interface INoteNavigationService
    {
        void NavigateTo(Type viewType);
        void NavigateTo(string viewType);
    }
}
