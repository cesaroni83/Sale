using Sale.Shared.Modelo.Estatico;
using SolidWorks.Interop.sldworks;

namespace Sale.Api.SolidWorks
{
    public interface ISolidWorksFile
    {
        ModelDoc2 OpenAppFile(string path, int tipo);

       
    }
}
