using System;

namespace Common
{
    public interface IKvar
    {
        Akcija Akcija { get; set; }
        DateTime DatumKvara { get; set; }
        DateTime DatumZatvaranjaKvara { get; set; }
        string DetaljanOpis { get; set; }
        string ElektricniElement { get; set; }
        string FullInfo { get; }
        string Id { get; set; }
        int IdElement { get; set; }
        string KratakOpis { get; set; }
        Status Status { get; set; }
        string Uzrok { get; set; }

        string ToWord();
    }
}