﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INMETRO.REGOIAS.WEB.Models
{
    public class IntegracaoOrganismo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDT_INTEGRACAO")]
        public int Id { get; set; }

        [ForeignKey("Organismo")]
        [Required]
        [Column("IDT_ORGANISMO")]
        public int OrganismoId { get; set; }

        [Required]
        [Column("DES_DIRETORIO_REMOTO")]  //Inspecao
        public string DiretorioInspecao { get; set; }

        [Required]
        [Column("CDN_TIPO_INTEGRACAO")]
        public int TipoIntegracao { get; set; }

        [Required]
        [Column("DES_DIRETORIO_LOCAL")]  //c:\Inspecao\NomeOraganismo
        public string DiretorioInspecaoLocal { get; set; }

        [Required]
        [Column("DES_HOST_URI")]  //ftp:///siteftp
        public string HostURI { get; set; }

        [Column("CDN_PORTA")]
        public string Porta { get; set; }

        [Required]
        [Column("CDA_LOGIN_FTP")]
        public string Usuario { get; set; }

        [Required]
        [Column("DES_SENHA_FTP")]
        public string Senha { get; set; }

        [Column("CDA_PRIVATE_KEY")]
        public string PrivateKey { get; set; }

        public virtual Organismo Organismo { get; set; }

        public IntegracaoOrganismo()
        {

        }
        public IntegracaoOrganismo(int id, string diretorioInspecao, int tipoIntegracao, string diretorioInspecaoLocal, string host, string usuario, string senha, string chave, string porta)
        {
            Id = id;
            DiretorioInspecao = diretorioInspecao;
            TipoIntegracao = tipoIntegracao;
            DiretorioInspecaoLocal = diretorioInspecaoLocal;
            HostURI = host;
            Usuario = usuario;
            Senha = senha;
            PrivateKey = chave;
            Porta = porta;

        }
    }
}