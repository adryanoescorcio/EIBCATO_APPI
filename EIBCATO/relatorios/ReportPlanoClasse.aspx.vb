
Public Class ReportPlanoClasse
    Inherits System.Web.UI.Page

    Private Obj_Seguranca As Cls_Seguranca

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Session("Obj_Seguranca") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If

        Me.Obj_Seguranca = Session("Obj_Seguranca")

        If Not IsPostBack Then


            SqlDataSource1.SelectCommand = "SELECT        
                        dbo.plano.planoid, 
                        dbo.plano.planoclasseid, 
                        dbo.plano.planodescricao, 
                        dbo.plano.planoprofessor,
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

            ReportViewer1.LocalReport.Refresh()

        Else
            Dim _Obj As Object = ViewState.Values
        End If
    End Sub

End Class