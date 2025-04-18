Public Class HealthRecord
    Public Property Timestamp As DateTime
    Public Property Weight As Double
    Public Property AmountDonated As Integer
    Public Property BloodPressure As String

    Public ReadOnly Property BloodPressureUpper As Integer
        Get
            Return Integer.Parse(BloodPressure.Split("/"c)(0))
        End Get
    End Property

    Public ReadOnly Property BloodPressureLower As Integer
        Get
            Return Integer.Parse(BloodPressure.Split("/"c)(1))
        End Get
    End Property
End Class