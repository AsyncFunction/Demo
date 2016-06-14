Imports System.IO
Imports Syncfusion.XlsIO

Public Class Import
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim path As String = Server.MapPath("~/2016data.xlsx")
        Dim list = ImportCSV(New System.IO.FileInfo(path))

        If list IsNot Nothing AndAlso list.Count > 0 Then
            For Each obj In list
                If Not Member.Raw(obj) Then
                    Dim str = ""
                End If

            Next
        End If

    End Sub

    Public Function ImportCSV(ByVal filePath As FileInfo) As List(Of Member)

        Using s As FileStream = New FileStream(filePath.FullName, FileMode.Open)
            Return ImportCSV(s)
        End Using

    End Function

    Public Function ImportCSV(ByVal s As Stream) As List(Of Member)

        Dim list As New List(Of Member)
        Dim excelEngine As ExcelEngine = New ExcelEngine
        Dim application As IApplication = excelEngine.Excel
        Dim workbook As IWorkbook = application.Workbooks.Open(s, ExcelOpenType.Automatic)
        Dim sheet As IWorksheet = workbook.Worksheets(0)
        Dim dt As DateTime = DateTime.Now

        If (sheet IsNot Nothing AndAlso sheet.Rows.Count > 0) Then

            For i As Integer = 1 To sheet.Rows.Count

                If i > 1 Then

                    Try
                        Dim x As Member = New Member
                        x.MemberID = Guid.NewGuid
                        x.SEOID = i

                        Dim MemberTypeID As Int32 = 0
                        Int32.TryParse(sheet.Range(("A" & i)).Value, MemberTypeID)
                        x.MemberTypeID = MemberTypeID

                        Dim Featured As Boolean = False
                        If sheet.Range(("B" & i)).Value = 1 Then
                            Featured = True
                        End If


                        x.Company = sheet.Range(("C" & i)).Value
                        x.CompanyUrl = sheet.Range(("D" & i)).Value
                        x.CompanyLogo = sheet.Range(("E" & i)).Value
                        x.Specialties = sheet.Range(("F" & i)).Value
                        x.Address = sheet.Range(("G" & i)).Value
                        x.City = sheet.Range(("H" & i)).Value
                        x.State = sheet.Range(("I" & i)).Value
                        x.Zip = sheet.Range(("J" & i)).Value
                        x.Title = sheet.Range(("K" & i)).Value
                        x.FirstName = sheet.Range(("L" & i)).Value
                        x.LastName = sheet.Range(("M" & i)).Value
                        x.Email = sheet.Range(("N" & i)).Value
                        x.DirectLine = sheet.Range(("O" & i)).Value
                        x.Fax = sheet.Range(("P" & i)).Value

                        Dim Active As Boolean = False
                        If sheet.Range(("Q" & i)).Value = 1 Then
                            Active = True
                        End If
                        x.Active = Active

                        x.DateCreated = dt
                        x.DateModified = dt

                        list.Add(x)

                    Catch ex As Exception
                    End Try
                End If
            Next
        End If

        Return list
    End Function

End Class