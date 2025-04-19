Module Orchestrator
    Sub Main(args As String())
        Console.WriteLine("Starting...")

        Try
            ' --- STEP 1: Load CSV ---
            Console.WriteLine("Loading CSV file...")

            Dim healthData = ParseCSV.ReadCSV()

            ' --- STEP 2: ETL Process ---
            Console.WriteLine($"ETL: Processes {healthData.Count} records.")
            ETLforJSON(healthData)

            ' --- STEP 3: Supabase Database ---
            Console.WriteLine("Initializing Supabase client...")
            SupabaseClient.Initialize().GetAwaiter().GetResult()

            Console.WriteLine("Pushing to Supabase DB...")
            Dim success = SupabaseClient.UpsertHealthData(healthData).GetAwaiter().GetResult()

            ' --- STEP 4: Visualize ---
            ' TODO

        Catch ex As Exception
            Console.WriteLine($"Fatal error: {ex.Message}")
        End Try
    End Sub
End Module