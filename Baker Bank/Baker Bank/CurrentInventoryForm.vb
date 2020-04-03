Imports MySql.Data.MySqlClient

Public Class currentInventoryForm


    Private Sub currentInventoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connectToDB() ' so we can connect to our DB without tying this to a button

    End Sub

    Private Sub connectToDB()
        Dim MysqlConn As MySqlConnection
        Dim COMMAND As MySqlCommand

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"

        Try
            MysqlConn.Open()
            MessageBox.Show("Connection Successful")
            MysqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim MysqlConn As MySqlConnection
        Dim COMMAND As MySqlCommand

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=bakerybank1.c0sydhyi1pnd.us-east-2.rds.amazonaws.com;userid=admin;password=TINtin343!;database=mydb"
        Dim READER As MySqlDataReader
        Try
            MysqlConn.Open()
            Dim Query As String
            Dim dbTable As New DataTable
            Dim da As New MySqlDataAdapter
            Dim dr As MySqlDataReader
            Dim ds, ds1 As New DataSet
            Query = "select * from mydb.Store"
            COMMAND = New MySqlCommand(Query, MysqlConn)

            da = New MySqlDataAdapter(COMMAND)
            da.Fill(ds, "Subject Detail")
            Label1.Text = ds.Tables(0).Rows(0).Item(0)
            Label2.Text = ds.Tables(0).Rows(1).Item(0)
            Label3.Text = ds.Tables(0).Rows(0).Item(1)
            Label4.Text = ds.Tables(0).Rows(1).Item(1)


            MysqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class