Imports Supabase
Imports Supabase.Gotrue
Imports Postgrest
Imports System.Text.Json

Public Module SupabaseClient
    Private ReadOnly SupabaseUrl As String = Environment.GetEnvironmentVariable("SUPABASE_URL")
    Private ReadOnly SupabaseKey As String = Environment.GetEnvironmentVariable("SUPABASE_KEY")
    Private Client As Supabase.Client

    Public Async Function Initialize() As Task
        If Client IsNot Nothing Then Return

        If String.IsNullOrEmpty(SupabaseUrl) OrElse String.IsNullOrEmpty(SupabaseKey) Then
            Throw New Exception("Supabase credentials not configured!")
        End If

        Dim options = New SupabaseOptions With {
            .AutoConnectRealtime = True
        }

        Client = New Supabase.Client(SupabaseUrl, SupabaseKey, options)
        Await Client.InitializeAsync()
    End Function

    Public Async Function UpsertHealthData(records As List(Of HealthRecord)) As Task(Of Boolean)
        Try
            Dim jsonOptions As New JsonSerializerOptions With {
                .PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }

            Dim response = Await Client.From(Of HealthRecord)().Upsert(records)

            Return response.Models?.Count >= records.Count
        Catch ex As Exception
            Console.WriteLine($"Database error: {ex.Message}")
            Return False
        End Try
    End Function
End Module