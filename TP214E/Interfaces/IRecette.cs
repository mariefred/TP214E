using System.Collections.Generic;
using MongoDB.Bson;

namespace TP214E.Data
{
    public interface IRecette
    {
        string NomRecette { get; set; }
        ObjectId Id { get; set; }
        List<(double, Aliment)> ListeIngredients { get; set; }
        decimal Vendant { get; set; }
        string ToString();
    }
}