using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IExport
    {
        [OperationContract]
        void ExportToExcel(List<Kvar> kvarovi);

        [OperationContract]
        void ExportToWord(Kvar kvar);

    }
}
