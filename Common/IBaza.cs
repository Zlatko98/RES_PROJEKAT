using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IBaza
    {
        [OperationContract]
        void Konektovanje();

        [OperationContract]
        void Diskonektovanje();
        [OperationContract]
        void DodajKvar(IKvar kvar);
        [OperationContract]
        void AzurirajKvar(IKvar kvar);
        [OperationContract]
        List<Kvar> GetKvarovi(DateTime date1, DateTime date2);
        [OperationContract]
        string GetLatestID();
        [OperationContract]
        string CreateID(string kvarID);

        [OperationContract]
        List<ElektricniElement> GetElektricniElementi();
    }
}
