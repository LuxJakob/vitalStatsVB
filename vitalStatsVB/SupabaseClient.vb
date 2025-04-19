Imports Supabase
Imports Supabase.Gotrue
Imports Postgrest

Public Module SupabaseClient
    Private ReadOnly SupabaseUrl As String = "YOUR_SUPABASE_URL"
    Private ReadOnly SupabaseKey As String = "YOUR_SUPABASE_KEY"
    Private Client As Supabase.Client

    Public Async Function Initialize() As Task
        Client = New Supabase.Client(SupabaseUrl, SupabaseKey)
        Await Client.InitializeAsync()
    End Function


End Module