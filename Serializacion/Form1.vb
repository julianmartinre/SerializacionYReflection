Imports System.IO
Imports System.Text
Imports System.Xml.Serialization

Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim p1 As New ProductoBE With {.id = 1, .nombre = "Pera", .precio = 200}
        Dim p2 As New ProductoBE With {.id = 2, .nombre = "Sandia", .precio = 600}
        Dim list As New List(Of ProductoBE)
        list.Add(p1)
        list.Add(p2)

        Dim xmlSerializer As New XmlSerializer(list.GetType())
        Dim ms As New MemoryStream
        xmlSerializer.Serialize(ms, list)
        Dim result As String = StreamACadena(ms)

        Dim escritor As StreamWriter
        escritor = File.AppendText("D:\Productos.xml")
        escritor.Write(result)
        escritor.Flush()
        escritor.Close()
    End Sub

    Public Shared Function StreamACadena(stream As Stream) As String

        Dim bytes(stream.Length) As Byte

        stream.Position = 0
        stream.Read(bytes, 0, stream.Length)

        Return BytesACadena(bytes)

    End Function

    Public Shared Function BytesACadena(bytes As Byte()) As String

        Return Encoding.ASCII.GetString(bytes)

    End Function

    Public Shared Function CadenaABytes(cadena As String) As Byte()

        Return Encoding.ASCII.GetBytes(cadena)

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim listaDeserealizada As New List(Of ProductoBE)
        Dim serializador As New XmlSerializer(listaDeserealizada.GetType())
        listaDeserealizada = serializador.Deserialize(New MemoryStream(CadenaABytes(IO.File.ReadAllText("D:\Productos.xml"))))

    End Sub
End Class

Public Class ProductoBE
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Private _precio As Decimal
    Public Property precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property
End Class
