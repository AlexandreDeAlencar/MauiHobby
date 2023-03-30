namespace GA_Intergado.CR2.IntegrationService.Model
{
    public class IngredienteFabricacaoCR1VM
    {
        public long cr1w_detfab_codigo { get; set; }
        public long cr1w_detfab_codfab { get; set; }
        public long cr1w_detfab_codali { get; set; }
        public long cr1w_detfab_coduser { get; set; }
        public long cr1w_detfab_codope { get; set; }
        public decimal cr1w_detfab_mn_fabr { get; set; } // Total Matéria Prima Fabricada
        public decimal cr1w_detfab_mn_prev { get; set; } // Total Matéria Prima Prevista
        public DateTime? cr1w_detfab_hr_ini { get; set; }
        public DateTime? cr1w_detfab_hr_fim { get; set; }
        public int? cr1w_detfab_peso_inicial { get; set; }
        public int? cr1w_detfab_peso_final { get; set; }
    }
}