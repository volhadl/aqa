using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Task1
{
    public class ReadWriteDataManager
    {
        public static void SerializeBin(IEnumerable<Car> cars)
        {
            var ioManager = new IoManager();

            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, cars);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public static void DeserializeBin()
        {
            var binIoManager = new IoManager();

            IEnumerable<Car> cars = null;
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                cars = (List<Car>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            binIoManager.ShowTable(cars);
        }

        public static void SerializeXml(CarPark park)
        {
            string path = @"D:\\lol.xml";
            var serializer = new XmlSerializer(typeof(CarPark));
            var encoding = Encoding.GetEncoding("utf-8");
            var namespaceStr = "http://lol.by/catalog";

            XmlSerializerNamespaces defaultNamespace = new XmlSerializerNamespaces();
            defaultNamespace.Add(string.Empty, namespaceStr);

            using (StreamWriter writer = new StreamWriter(path, false, encoding))
            {
                serializer.Serialize(writer, park, defaultNamespace);
            }
        }

        public static CarPark DeserializeXml()
        {

            CarPark park = null;
            string path = @"D:\\lol.xml";
            var serializer = new XmlSerializer(typeof(CarPark));
            var encoding = Encoding.GetEncoding("utf-8");
            var namespaceStr = "http://lol.by/catalog";

            XmlSerializerNamespaces defaultNamespace = new XmlSerializerNamespaces();
            defaultNamespace.Add(string.Empty, namespaceStr);


            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                var loadedObject = serializer.Deserialize(stream);

                if (loadedObject is CarPark)
                {
                    park = (CarPark)loadedObject;
                }
            }
            return park;
        }

    }
}