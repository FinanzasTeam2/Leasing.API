namespace Leasing.API.App.Domain.Models;

public class LeasingResult
{
    public int Id { get; set; }
    public float Saldo_a_Financiar { get; set; }
    public float Monto_del_Prestamo { get; set; }
    public int Numero_de_Cuotas_por_Anio { get; set; }
    public int Numero_Total_de_Cuotas { get; set; }

    public float Porcentaje_de_Seguro_Desgravamen_Periodo { get; set; }
    public float Seguro_Riesgo { get; set; }
    
    public float Intereses { get; set; }
    public float Amortizacion_del_Capital { get; set; }
    public float Seguro_de_Desgravamen { get; set; }
    public float Seguro_Contra_Todo_Riesgo { get; set; }
    public float Comisiones_Periodicas_Riesgo { get; set; }
    public float Portes_Gastos_de_Administracion{ get; set; }
    
    public float Tasa_de_Descuento { get; set; }
    public float TIR_de_la_Operacion { get; set; }
    public float TCEA_de_la_Operacion { get; set; }
    public float VAN_Operacion { get; set; }
    
    //RelationShip
    public LeasingData LeasingData { get; set; }
    public int LeasingDataId { get; set; }
    public LeasingMethod LeasingMethod { get; set; }
    public int LeasingMethodId { get; set; }
}