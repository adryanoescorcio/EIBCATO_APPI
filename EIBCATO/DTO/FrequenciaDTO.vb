Public Class FrequenciaDTO

    Private _classecodigo As String
    Private _classedatainicio As Date
    Private _classedatafim As Date
    Private _classecargahoraria As Integer
    Private _classestatus As String
    Private _alunonome As String
    Private _alunocpf As String
    Private _alunosituacao As String
    Private _frequenciasituacao As String
    Private _frequenciadata As Date
    Private _frequencaunique As String
    Private _presenca As String
    Private _ausencia As String

    Public Property Classecodigo As String
        Get
            Return _classecodigo
        End Get
        Set(value As String)
            _classecodigo = value
        End Set
    End Property

    Public Property Classedatainicio As Date
        Get
            Return _classedatainicio
        End Get
        Set(value As Date)
            _classedatainicio = value
        End Set
    End Property

    Public Property Classedatafim As Date
        Get
            Return _classedatafim
        End Get
        Set(value As Date)
            _classedatafim = value
        End Set
    End Property

    Public Property Classecargahoraria As String
        Get
            Return _classecargahoraria
        End Get
        Set(value As String)
            _classecargahoraria = value
        End Set
    End Property

    Public Property Classestatus As String
        Get
            Return _classestatus
        End Get
        Set(value As String)
            _classestatus = value
        End Set
    End Property

    Public Property Alunonome As String
        Get
            Return _alunonome
        End Get
        Set(value As String)
            _alunonome = value
        End Set
    End Property

    Public Property Alunocpf As String
        Get
            Return _alunocpf
        End Get
        Set(value As String)
            _alunocpf = value
        End Set
    End Property

    Public Property Alunosituacao As String
        Get
            Return _alunosituacao
        End Get
        Set(value As String)
            _alunosituacao = value
        End Set
    End Property

    Public Property Frequenciasituacao As String
        Get
            Return _frequenciasituacao
        End Get
        Set(value As String)
            _frequenciasituacao = value
        End Set
    End Property

    Public Property Frequenciadata As Date
        Get
            Return _frequenciadata
        End Get
        Set(value As Date)
            _frequenciadata = value
        End Set
    End Property

    Public Property Frequencaunique As String
        Get
            Return _frequencaunique
        End Get
        Set(value As String)
            _frequencaunique = value
        End Set
    End Property

    Public Property Presenca As String
        Get
            Return _presenca
        End Get
        Set(value As String)
            _presenca = value
        End Set
    End Property

    Public Property Ausencia As String
        Get
            Return _ausencia
        End Get
        Set(value As String)
            _ausencia = value
        End Set
    End Property
End Class
