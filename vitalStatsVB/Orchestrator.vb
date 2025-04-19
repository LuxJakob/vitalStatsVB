Module Orchestrator
    Sub Main(args As String())
        Console.WriteLine("Starting...")

        Try
            ' --- STEP 1: Load CSV ---
            Console.WriteLine("Loading CSV file...")

            Dim healthData = ParseCSV.ReadCSV()
            For Each record In healthData
                Console.WriteLine($"{record.Timestamp:yyyy-MM-dd}: " &
                      $"Weight = {record.Weight} kg, " &
                      $"BP = {record.BloodPressure}")
            Next

            ' --- STEP 2: ETL Process ---
            Console.WriteLine($"ETL: Processes {healthData.Count} records.")
            ETLforJSON(healthData)

            ' --- STEP 3: Push to Display/Graph ---
            Console.WriteLine("Pushing to Supabase DB...")
            ' HELP ME HERE

        Catch ex As Exception
            Console.WriteLine($"Fatal error: {ex.Message}")
        End Try
    End Sub
End Module