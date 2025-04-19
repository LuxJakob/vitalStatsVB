Imports Supabase
Imports Supabase.Gotrue
Imports Postgrest

Public Module SupabaseClient
    Private ReadOnly SupabaseUrl As String = Environment.GetEnvironmentVariable("SUPABASE_URL")
    Private ReadOnly SupabaseKey As String = Environment.GetEnvironmentVariable("SUPABASE_KEY")
    Private Client As Supabase.Client

    Public Async Function Initialize() As Task
        If String.IsNullOrEmpty(SupabaseUrl) OrElse String.IsNullOrEmpty(SupabaseKey) Then
            Throw New Exception("Supabase credentials not configured!")
        End If

        Client = New Supabase.Client(SupabaseUrl, SupabaseKey)
        Await Client.InitializeAsync()
    End Function

    Public Async Function UpsertHealthData(records As List(Of HealthRecord)) As Task(Of Boolean)

        Return True

    End Function

End Module