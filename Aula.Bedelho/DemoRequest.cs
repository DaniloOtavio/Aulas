using System;
using System.Net.Http;
using System.Xml.Serialization;

namespace Aula.Bedelho
{
    public class DemoRequest
    {
        public static void run()
        {
            Uri endereco = new Uri("https://webserv.rafaelestevam.net/CEPs.php?cep=13140729");
            HttpClient client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, endereco);
            request.Headers.TryAddWithoutValidation("ApiKey", "0115e1c1cc5825e4b5c35a1959ab0c8acae6f1a4");

            var response = client.Send(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("deu bom !");
                
                var retorno = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(retorno);

                XmlSerializer ser = new XmlSerializer(typeof(DadosCEP));

                var ender = (DadosCEP)ser.Deserialize(response.Content.ReadAsStreamAsync().Result);

                //XmlSerializer ser = new XmlSerializer(typeof(EmpresaCNPJ));
                //var empresa = (EmpresaCNPJ)ser.Deserialize(response.Content.ReadAsStreamAsync().Result);
                //empresa = empresa;
            }
            else
            {
                Console.WriteLine($"Deu não bom: {response.StatusCode}");
                var retorno = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(retorno);
            }
        }
    }

    public class DadosCEP
    {
        public string End { get; set; }
        public string Cid { get; set; }
        public string Bai { get; set; }
        public string UF { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        [XmlAttribute()]
        public uint Id { get; set; }
    }



    public partial class EmpresaCNPJ
    {
        public byte TipoRegistro { get; set; }
      
        public string IndicadorFull { get; set; }
      
        public object TipoAtualizacao { get; set; }

      
        public string CNPJ { get; set; }

      
        public byte TipoEmpresa { get; set; }

      
        public string NomeEmpresa { get; set; }

      
        public string NomeFantasia { get; set; }

      
        public string SituacaoCadastral { get; set; }

      
        public DateTime DataSituacaoCadastral { get; set; }

      
        public byte MotivoSituacaoCadastral { get; set; }

      
        public string NM_PaisExterior { get; set; }


      
        public string CO_Pais { get; set; }

      
        public string NM_Pais { get; set; }

      
        public int CodigoNaturezaJuridica { get; set; }

      
        public System.DateTime DataInicioAtividade { get; set; }

      
        public int CNAE_Fiscal { get; set; }

      
        public string DescricaoTipoLogradouro { get; set; }

      
        public string Logradouro { get; set; }

      
        public byte Numero { get; set; }

      
        public string Complemento { get; set; }

      
        public string Bairro { get; set; }

      
        public string CEP { get; set; }


      
        public string UF { get; set; }

      
        public string CodigoMunicipio { get; set; }

      
        public string Municipio { get; set; }

      
        public string Telefone1 { get; set; }

      
        public string Telefone2 { get; set; }

      
        public string TelefoneFax { get; set; }


      
        public string CorreioEletronico { get; set; }

      
        public byte QualificacaoResponsavel { get; set; }

      
        public decimal CapitalSocialEmpresa { get; set; }


      
        public byte PorteEmpresa { get; set; }
        public byte OpcaoSimples { get; set; }
        public System.DateTime DataOpcaoSimples { get; set; }
        public System.DateTime DataExclusaoSimples { get; set; }
        public string OpcaoMEI { get; set; }

      
        public object SituacaoEspecial { get; set; }

      
        public System.DateTime DataSituacaoEspecial { get; set; }
    }
}