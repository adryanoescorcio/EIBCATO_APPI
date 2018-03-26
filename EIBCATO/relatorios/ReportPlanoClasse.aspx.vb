
Imports Microsoft.Reporting.WebForms
Imports PIBICAS.Models
Imports PIBICAS.Models.Context

Public Class ReportPlanoClasse
    Inherits System.Web.UI.Page

    Private Obj_Seguranca As Cls_Seguranca
    Public db As IBCAContext = New IBCAContext()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Session("Obj_Seguranca") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If

        Me.Obj_Seguranca = Session("Obj_Seguranca")

        If Not IsPostBack Then

            Dim dt As IBCADS.DSPlanoClasseDataTable = New IBCADS.DSPlanoClasseDataTable()

            Dim sql = "SELECT        
                        dbo.plano.planoid, 
                        dbo.plano.planoclasseid, 
                        dbo.plano.planodescricao,
                        CASE WHEN dbo.plano.planoprofessor = '' THEN 'ND' ELSE dbo.plano.planoprofessor END as planoprofessor,
                        dbo.plano.planodataprevista,
                        dbo.plano.planohoraaula,       
                        dbo.classeplanoaula.classeid,
                        dbo.classe.classecodigo, 
                        dbo.classe.classedatainicio, 
                        dbo.classe.classedatafim, 
                        dbo.classe.classecargahoraria, 
                        dbo.classe.classestatus
                        FROM            dbo.classe, dbo.classeplanoaula, dbo.plano
                        WHERE        dbo.classe.classeid = dbo.classeplanoaula.classeid
        AND dbo.classeplanoaula.planoaulaid = dbo.plano.planoid 
        AND planoclasseid = " & Me.Obj_Seguranca.idClasse

            Dim qr = db.Database.SqlQuery(Of PlanoClasseDTO)(sql).ToList()


            For Each cl In qr
                dt.Rows.Add(cl.Planoid,
                            cl.Planoclasseid,
                            cl.Planodescricao,
                            cl.Planoprofessor,
                            cl.Planodataprevista.ToString("dd/MM/yy"),
                            cl.Planohoraaula,
                            cl.Classeid,
                            cl.Classecodigo,
                            cl.Classedatainicio.ToString("dd/MM/yy"),
                            cl.Classedatafim.ToString("dd/MM/yy"),
                            cl.Classecargahoraria,
                            cl.Classestatus
                            )
            Next

            ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", dt.CopyToDataTable()))
            ReportViewer1.LocalReport.Refresh()

        Else
            Dim _Obj As Object = ViewState.Values
        End If
    End Sub

End Class