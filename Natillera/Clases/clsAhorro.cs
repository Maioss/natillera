using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Natillera.Modelos;



public class clsAhorro
{
    NatilleraEntities dbNatillera = new NatilleraEntities();
    public Ahorro ahorro = new Ahorro();
    public List<Ahorro> LlenarGrid()
    {
        return dbNatillera.Ahorroes
               .OrderByDescending(p => p.Id)
               .ToList();
    }

    public string Insertar()
    {
        CalcularAhorro();

        dbNatillera.Ahorroes.Add(ahorro);
        dbNatillera.SaveChanges();
        return "Se insertó la ahorro del cliente con documento: " + ahorro.Ahorro_Parcial;


    }

    public string Eliminar()
    {
        Ahorro ahorro_Elim = dbNatillera.Ahorroes.FirstOrDefault(p => p.Id == ahorro.Id);
        dbNatillera.Ahorroes.Remove(ahorro_Elim);
        dbNatillera.SaveChanges();
        return "Se eliminó la ahorro del cliente: " + ahorro.Id;
    }





    public void CalcularAhorro()
    {
        double intereses;

        if (ahorro.Id_Tipo == 1)
        {
            intereses = 1.2;
        }
        else
        {
            intereses = 1.5;
        }

        ahorro.Ahorro_Total = ahorro.Ahorro_Parcial * intereses;
        ahorro.Total_Ganancias = ahorro.Ahorro_Total - ahorro.Ahorro_Parcial;
    }


}

