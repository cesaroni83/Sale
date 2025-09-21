using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace Sale.Api.SolidWorks.Implementacion
{
    public class SolidworksFile:ISolidWorksFile
    {
        //C:\Users\cesar\Desktop\prueba\248735_001_LOU10X0AA\248735_001_LOU10X0AA.SLDASM
        public  SldWorks swApp ;
        public SolidworksFile()

        {
            try
            {
                 swApp = (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
                if (swApp == null)
                {
                    throw new Exception("No se pudo iniciar SolidWorks.");
                }
                swApp.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al inicializar SolidWorks: {ex.Message}");
                throw;
            }
        }

        public ModelDoc2 OpenAppFile(string path, int tipo)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("La ruta no puede ser vacía", nameof(path));

            ModelDoc2 model = null;
            int errors = 0;
            int warnings = 0;

            switch (tipo)
            {
                case 1: // Ensamblaje
                    model = swApp.OpenDoc6(path,(int)swDocumentTypes_e.swDocASSEMBLY, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "",errors,warnings);
                    break;

                case 2: // Pieza
                    model = swApp.OpenDoc6(
                        path,
                        (int)swDocumentTypes_e.swDocPART,
                        (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                        "",
                        ref errors,
                        ref warnings);
                    break;

                case 3: // Dibujo
                    model = swApp.OpenDoc6(
                        path,
                        (int)swDocumentTypes_e.swDocDRAWING,
                        (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                        "",
                        ref errors,
                        ref warnings);
                    break;

                default:
                    throw new ArgumentException("Tipo no válido. Debe ser 1 (ensamblaje), 2 (pieza) o 3 (dibujo).");
            }

            return model; // Devuelve null si no se abrió correctamente
        }


    }
}
