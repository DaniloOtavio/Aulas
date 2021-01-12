using System;
using System.IO;
using System.Text;
using Aula.Lib.Aula08;

namespace Aula.Bedelho
{
    internal class DemoAula9
    {
        internal static void ExemploSerializacao()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new ProdutoCadastro()
            {
                GUID = Guid.NewGuid(),
                Nome = "Sblevers"
            });

            json = json;

            var produto = Newtonsoft.Json.JsonConvert.DeserializeObject<ProdutoCadastro>(json);
            produto = produto;

            using var ms = new MemoryStream();
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ProdutoCadastro));
            serializer.Serialize(ms, produto);
            var xml = Encoding.UTF8.GetString(ms.ToArray());

            var strReader = new StringReader(xml);
            var prod2 = (ProdutoCadastro)serializer.Deserialize(strReader);

        }
    }
}