Imports System.Text.Json.Serialization
Imports Supabase.Postgrest.Models

Public Class HealthRecord
    Inherits BaseModel

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
            If String.IsNullOrEmpty(BloodPressure) Then Return 0
            Return Integer.Parse(BloodPressure.Split("/"c)(0))
        End Get
    End Property

    <JsonPropertyName("blood_pressure_lower")>
    Public ReadOnly Property BloodPressureLower As Integer
        Get
            If String.IsNullOrEmpty(BloodPressure) Then Return 0
            Return Integer.Parse(BloodPressure.Split("/"c)(1))
        End Get
    End Property
    Public Sub New()
        ' BaseModel initialization happens automatically
    End Sub
End Class