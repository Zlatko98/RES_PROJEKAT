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
        void DodajKvar(string kratakOpis, string uzrok, string detaljanOpis, DateTime vreme, string akcija, string elektricniElement);
        [OperationContract]
        void AzurirajKvar(string id, string kratakOpis, string uzrok, string detaljanOpis, Status status, DateTime vreme, string akcija, string elektricniElement);
        [OperationContract]
        List<Kvar> GetKvarovi(DateTime date1, DateTime date2);
        [OperationContract]
        string GetLatestID();
        [OperationContract]
        string CreateID(string kvarID);
        [OperationContract]
        Kvar GetKvar(string id);
        [OperationContract]
        List<ElektricniElement> GetElektricniElementi();
    }
}
