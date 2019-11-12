Imports System.IO
Imports System.Reflection
Imports System.Xml.Serialization

Public Class Form1
    Dim p As New Producto With {.id = 1, .nombre = "Manzana", .precio = 200}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a As Assembly = Assembly.GetExecutingAssembly()
        Dim t() As Type = a.GetTypes()
        'For Each item In t
        '    MsgBox(item.Name)
        'Next
        Dim type As Type = p.GetType()
        MsgBox(type.Name)
        Dim methodInfo() As MethodInfo = type.GetMethods()
        'For Each item In methodInfo
        '    MsgBox(item.Name)
        'Next
        Dim fieldInfo() As FieldInfo = type.GetFields()
        'For Each item In fieldInfo
        '    MsgBox(item.Name)
        'Next
        Dim propertyInfo() As PropertyInfo = type.GetProperties()
        'For Each item In propertyInfo
        '    MsgBox(item.Name)
        'Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fs As Stream = File.Create("D:\producto.xml")
        Dim serializador As XmlSerializer = New XmlSerializer(GetType(Producto))
        Dim ns As New XmlSerializerNamespaces()
        ns.Add("Área", "Administración")
        serializador.Serialize(fs, p, ns)
        fs.Close()
    End Sub
End Class
