﻿
Public Class ReportFrequenciaAluno
    Inherits System.Web.UI.Page

    Private Obj_Seguranca As Cls_Seguranca

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Session("Obj_Seguranca") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If

        Me.Obj_Seguranca = Session("Obj_Seguranca")

        If Not IsPostBack Then


            SqlDataSource1.SelectCommand = "SELECT        
            dbo.classe.classecodigo, 
            dbo.classe.classedatainicio, 
            dbo.classe.classedatafim, 
            dbo.classe.classecargahoraria, 
            dbo.classe.classestatus, 
            dbo.aluno.alunonome,               
            dbo.aluno.alunocpf, 
            dbo.aluno.alunosituacao,
            CASE WHEN dbo.frequencia.frequenciasituacao = '1' THEN 'P' ELSE 'X' END AS frequenciasituacao, 
            dbo.frequencia.frequenciadata, 
            dbo.frequencia.frequencaunique,
                             (SELECT        COUNT(q.listaid)
                               FROM            dbo.frequencia q
                               WHERE        q.classeid = dbo.frequencia.classeid AND q.listaid = dbo.lista.listaid and q.frequenciasituacao = '1') as presenca, (SELECT        COUNT(q.listaid)
                               FROM            dbo.frequencia q
                               WHERE        q.classeid = dbo.frequencia.classeid AND q.listaid = dbo.lista.listaid and q.frequenciasituacao = '0') as ausencia
            FROM            dbo.frequencia, dbo.classe, dbo.lista, dbo.aluno
            WHERE        dbo.frequencia.classeid = dbo.classe.classeid 
            AND dbo.frequencia.listaid = dbo.lista.listaid 
            AND dbo.lista.listaalunoid = dbo.aluno.alunoid 
            AND dbo.classe.classeid = " & Me.Obj_Seguranca.idClasse

            ReportViewer1.LocalReport.Refresh()

        Else
            Dim _Obj As Object = ViewState.Values
        End If
    End Sub

End Class