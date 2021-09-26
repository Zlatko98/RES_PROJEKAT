using BazaPodataka;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    public class Factory
    {
        public static Baza CreateBaza()
        {
            return new Baza();
        }

        public static IKvarServis CreateKvarServis()
        {
            return new KvarServis(CreateBaza());
        }

        public static IExport CreateExportServis()
        {
            return new ExportServis();
        }
    }
}
