Imports System
Imports System.Data
Imports MySql.Data.MySqlClient

Module Module1

    Sub Main()
        Dim connstring As String = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"

        Dim conn As MySqlConnection = Nothing

        Try
            conn = New MySqlConnection(connstring)
            conn.Open()

            Dim query As String = "SELECT * FROM Employee;"
            Dim da As New MySqlDataAdapter(query, conn)
            Dim ds As New DataSet()
            da.Fill(ds, "Employee")
            Dim dt As DataTable = ds.Tables("Employee")

            For Each row As DataRow In dt.Rows
                For Each col As DataColumn In dt.Columns
                    Console.Write(row(col).ToString() + vbTab)
                Next

                Console.Write(vbNewLine)
            Next

        Catch e As Exception
            Console.WriteLine("Error: {0}", e.ToString())
        Finally
            If conn IsNot Nothing Then
                conn.Close()
            End If
        End Try
    End Sub

End Module