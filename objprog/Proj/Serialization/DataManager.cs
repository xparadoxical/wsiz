using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Proj.Serialization;
internal static class DataManager
{
    private static readonly XmlSerializerNamespaces _emptyNamespaces = new([XmlQualifiedName.Empty]);
    private static readonly XmlWriterSettings _wSettings = new()
    {
        OmitXmlDeclaration = true,
        Encoding = new UTF8Encoding(false),
        Indent = true
    };
    private static readonly XmlReaderSettings _rSettings = new()
    {

    };

    internal static void SerializeXml(ParkingDto p, Stream destination)
    {
        using var writer = XmlWriter.Create(destination, _wSettings);
        var serializer = new XmlSerializer(typeof(ParkingDto));
        serializer.Serialize(writer, p, _emptyNamespaces);
    }

    internal static void SerializeToXmlFile(ParkingDto p, string path)
    {
        var fileMode = File.Exists(path) ? FileMode.Truncate : FileMode.Create;
        using var fs = new FileStream(path, fileMode, FileAccess.Write, FileShare.Read);
        SerializeXml(p, fs);
        fs.Close();
    }

    internal static ParkingDto DeserializeXml(Stream source)
    {
        using var writer = XmlReader.Create(source, _rSettings);
        var serializer = new XmlSerializer(typeof(ParkingDto));
        return (ParkingDto)serializer.Deserialize(writer)!;
    }

    internal static ParkingDto DeserializeFromXmlFile(string path)
    {
        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        var ret = DeserializeXml(fs);
        fs.Close();
        return ret;
    }
}
