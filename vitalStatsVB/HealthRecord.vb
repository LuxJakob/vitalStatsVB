Imports System.Text.Json.Serialization

Public Class HealthRecord

    <JsonPropertyName("date")>
    Public Property Timestamp As DateTime

    <JsonPropertyName("weight_kg")>
    Public Property Weight As Double

    <JsonPropertyName("amount_donated_ml")>
    Public Property AmountDonated As Integer

    <JsonIgnore>
    Public Property BloodPressure As String

    <JsonPropertyName("blood_pressure_upper")>
    Public ReadOnly Property BloodPressureUpper As Integer
        Get
            Return Integer.Parse(BloodPressure.Split("/"c)(0))
        End Get
    End Property

    <JsonPropertyName("blood_pressure_lower")>
    Public ReadOnly Property BloodPressureLower As Integer
        Get
            Return Integer.Parse(BloodPressure.Split("/"c)(1))
        End Get
    End Property

End Class