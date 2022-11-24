namespace Leasing.API.App.Resources;

public class SaveLeasingDataResource
{
    public float Porcentaje_Primera_Tasa_Efectiva { get; set; }
    public int Duracion_Primera_Tasa_Efectiva { get; set; }
    public float Porcentaje_Segunda_Tasa_Efectiva { get; set; }
    
    public float Precio_de_Venta_del_Activo { get; set; }
    public float Porcentaje_Cuota_Inicial { get; set; }
    public int Numero_de_Anios_a_Pagar { get; set; }
    public int Frecuencia_de_Pago_en_Dias { get; set; }
    public int Numero_de_Dias_por_Anio { get; set; }

    public int Primer_Plazo_de_Gracia_Meses { get; set; }
    public string Primer_Tipo_de_Gracia { get; set; }
    public int Segundo_Plazo_de_Gracia_Meses { get; set; }
    public string Segundo_Tipo_de_Gracia { get; set; }

    public float Costes_Notariales { get; set; }
    public float Costes_Registrales { get; set; }
    public float Tasacion { get; set; }
    public float Comision_de_Estudio { get; set; }
    public float Comision_de_Activacion { get; set; }

    public float Comision_Periodica { get; set; }
    public float Portes { get; set; }
    public float Gastos_de_Administracion { get; set; }
    public float Porcentaje_de_Seguro_de_Desgravamen { get; set; }
    public float Porcentaje_de_Seguro_de_Riesgo { get; set; }

    public float Costo_de_Oportunidad { get; set; }
    
    //RelationShip
    public int CurrencyTypeId { get; set; }
    public int UserId { get; set; }
}