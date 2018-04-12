Public Class CMySqlCustomersBillPrsn
    Public Sub New()
    End Sub
    Public Function CustomersBillPrsn() As String
        CustomersBillPrsn = " (CustID,PrsnID,PrsnName,PrsnCode,PhNo,PhCode,AuthBuyer,email,DateCreated,DateModified,UpLoad,UserName,Password) "
    End Function
End Class
