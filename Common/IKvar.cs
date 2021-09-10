﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IKvar
    {
        [OperationContract]
        void unesiKvar(string kratakOpis, string uzrok, string detaljanOpis, DateTime vreme, string akcija, string elektricniElement);

        [OperationContract]
        void azurirajKvar(string id, string kratakOpis, string uzrok, string detaljanOpis, Status status, DateTime vreme, string akcija, string elektricniElement);

        [OperationContract]
        List<Kvar> GetKvarovi(DateTime date1, DateTime date2);

        [OperationContract]
        List<ElektricniElement> GetElektricniElementi();
    }
}
