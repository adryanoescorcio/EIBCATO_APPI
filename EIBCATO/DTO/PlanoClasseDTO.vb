Public Class PlanoClasseDTO

    Private _planoid As Integer
    Private _planoclasseid As Integer
    Private _planodescricao As String
    Private _planoprofessor As String
    Private _planohoraaula As Integer
    Private _planodataprevista As Date
    Private _classeid As Integer
    Private _classecodigo As String
    Private _classedatainicio As Date
    Private _classedatafim As Date
    Private _classecargahoraria As String
    Private _classestatus As String

    Public Property Planoid As Integer
        Get
            Return _planoid
        End Get
        Set(value As Integer)
            _planoid = value
        End Set
    End Property

    Public Property Planoclasseid As Integer
        Get
            Return _planoclasseid
        End Get
        Set(value As Integer)
            _planoclasseid = value
        End Set
    End Property

    Public Property Planodescricao As String
        Get
            Return _planodescricao
        End Get
        Set(value As String)
            _planodescricao = value
        End Set
    End Property

    Public Property Planoprofessor As String
        Get
            Return _planoprofessor
        End Get
        Set(value As String)
            _planoprofessor = value
        End Set
    End Property

    Public Property Planohoraaula As Integer
        Get
            Return _planohoraaula
        End Get
        Set(value As Integer)
            _planohoraaula = value
        End Set
    End Property

    Public Property Planodataprevista As Date
        Get
            Return _planodataprevista
        End Get
        Set(value As Date)
            _planodataprevista = value
        End Set
    End Property

    Public Property Classeid As Integer
        Get
            Return _classeid
        End Get
        Set(value As Integer)
            _classeid = value
        End Set
    End Property

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
End Class
