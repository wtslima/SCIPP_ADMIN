using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INMETRO.REGOIAS.WEB.Models
{
    public class Organismo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDT_ORGANISMO")]
        public int Id { get; set; }

        [Required]
        [Column("NOM_ORGANISMO")]
        public string Nome { get; set; }

        [Required]
        [Column("CDA_CODIGO_OIA")]
        public string CodigoOIA { get; set; }

        [Column("CDA_ATIVO")]
        public bool EhAtivo { get; set; }

        public virtual IntegracaoOrganismo IntegracaoInfo { get; set; }
        
        public Organismo()
        {

        }

        public Organismo( string nome, string codigoOia, IntegracaoOrganismo integracaoInfo)
        {
            Nome = nome;
            CodigoOIA = codigoOia;
            IntegracaoInfo = new IntegracaoOrganismo
            {
                HostURI = integracaoInfo.HostURI + ":" + integracaoInfo.Porta + "//" + integracaoInfo.DiretorioInspecao,
                DiretorioInspecaoLocal = integracaoInfo.DiretorioInspecaoLocal,
                TipoIntegracao = integracaoInfo.TipoIntegracao,
                Usuario = integracaoInfo.Usuario,
                Senha = integracaoInfo.Senha,
                PrivateKey = integracaoInfo.PrivateKey

            };
        }
    }
}
