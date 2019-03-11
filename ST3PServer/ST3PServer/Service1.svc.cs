using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ST3PServer
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        //TreeType info = new TreeType();
        public List<List<string>> Income(List<List<string>> body, List<string> head , int d)
        {
            ID3 azaz = new ID3();
            List<List<string>> info = azaz.TreeMap(body, head, d, 0);
            return info;
        }

        public bool SetTreeInfo (List<List<string>> body, List<string> head, int d)
        {
            try
            {
                
                TreeType.SetBody = body;
                TreeType.SetHead = head;
                TreeType.SetDecisionPosition = d;
                return true;
            } catch
            {
                return false;
            }
        }

        public void AddRecord (List<string> record)
        {
            TreeType.AddRecord(record);
        }

        public List<List<string>> GetTree ()
        {
            TreeType.CalculateTree();
            return TreeType.GetTree;
        }
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
