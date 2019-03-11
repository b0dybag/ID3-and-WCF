using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ST3PServer
{

    //// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<List<string>> Income(List<List<string>> body, List<string> head, int d);

        [OperationContract]
        bool SetTreeInfo(List<List<string>> body, List<string> head, int d);

        [OperationContract]
        void AddRecord(List<string> record);

        [OperationContract]
        List<List<string>> GetTree();



        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        //    // TODO: Добавьте здесь операции служб
    }


        //// Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.


        [DataContract]
        public static class TreeType
    {
        static bool empty = true;
        static bool result = false;
        static List<List<string>> body = new List<List<string>>() { };
        static List<List<string>> tree = new List<List<string>>() { };
        static List<string> head = new List<string>();
        static int decisionPosition = 0;


        [DataMember]
        public static bool Empty { get; set; }

        [DataMember]
        static public List<List<string>> SetBody
        {
            //get { return body }
            set { body = value; empty = false; }
        }

        [DataMember]
        static public List<List<string>> GetTree
        {
            get { return tree; }
            //set { body = value; empty = false; }
        }

        [DataMember]
        static public List<string> SetHead
        {
            //get { return body }
            set { head = value; }
        }

        [DataMember]
        static public int SetDecisionPosition
        {
            //get { return body }
            set { decisionPosition = value; }
        }

        [OperationContract]
        static public void CalculateTree()
        {
                    ID3 id3 = new ID3();
                    tree = id3.TreeMap(body, head, decisionPosition, 0);
        }

        [OperationContract]
        static public void AddRecord(List<string> record)
        {
            body.Add(record);
        }

    }
        //[DataContract]
        //public class CompositeType
        //{
        //    bool boolValue = true;
        //    string stringValue = "Hello ";

        //    [DataMember]
        //    public bool BoolValue
        //    {
        //        get { return boolValue; }
        //        set { boolValue = value; }
        //    }

        //    [DataMember]
        //    public string StringValue
        //    {
        //        get { return stringValue; }
        //        set { stringValue = value; }
        //    }
        //}
    }
