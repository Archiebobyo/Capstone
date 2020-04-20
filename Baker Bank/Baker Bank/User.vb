Public Class User
    Private Shared _Name As String
    Private Shared _EmployeeID As Int64
    Private Shared _StoreID As Int64
    Private Shared _WarehouseID As Int64
    Private Shared _EmployeeType As Int16
    Private Shared _ManagerID As Int64
    Private Shared _Phone As Int32
    Private Shared _Email As String
    Private Shared _Password As String
    Private Shared _Address As String

    Public Shared Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            If (value.Trim <> "") Then
                _Name = value.Trim
            End If
        End Set
    End Property
    Public Shared Property EmployeeID As Int64
        Get
            Return _EmployeeID
        End Get
        Set(value As Int64)
            _EmployeeID = value
        End Set
    End Property
    Public Shared Property StoreID As Int64
        Get
            Return _StoreID
        End Get
        Set(value As Int64)
            _StoreID = value
        End Set
    End Property
    Public Shared Property WarehouseID As Int64
        Get
            Return _WarehouseID
        End Get
        Set(value As Int64)
            _WarehouseID = value
        End Set
    End Property
    Public Shared Property EmployeeType As Int16
        Get
            Return _EmployeeType
        End Get
        Set(value As Int16)
            _EmployeeType = value
        End Set
    End Property
    Public Shared Property ManagerID As Int64
        Get
            Return _ManagerID
        End Get
        Set(value As Int64)
            _ManagerID = value
        End Set
    End Property


    Public Shared Property Phone As Int32
        Get
            Return _Phone
        End Get
        Set(value As Int32)
            _Phone = value
        End Set
    End Property
    Public Shared Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            If (value.Trim <> "") Then
                _Email = value.Trim
            End If
        End Set
    End Property

    Public Shared Property Password As String
        Get
            Return _Password
        End Get
        Set(value As String)
            If (value.Trim <> "") Then
                _Password = value.Trim
            End If
        End Set
    End Property

    Public Shared Property Address As String
        Get
            Return _Address
        End Get
        Set(value As String)
            If (value.Trim <> "") Then
                _Address = value.Trim
            End If
        End Set
    End Property
End Class
