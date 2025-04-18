Imports System

Module Orchestrator
    Sub Main(args As String())
        Console.WriteLine("Starting...")

        Try
            ' --- STEP 1: Load CSV ---
            Console.WriteLine("Loading CSV file...")


            Dim projectDir As String = AppDomain.CurrentDomain.BaseDirectory
            Dim healthFile As String = "plasma_donation_testdata.csv"

            If Not System.IO.File.Exists(healthFile) Then
                Console.WriteLine("ERROR: CSV file not found!")
                Return
            End If

            Dim healthData = ParseCSV.ReadCSV(healthFile)
            For Each record In healthData
                Console.WriteLine($"{record.Timestamp:yyyy-MM-dd}: " &
                      $"Weight = {record.Weight} kg, " &
                      $"BP = {record.BloodPressure}")
            Next

            ' --- STEP 2: ETL Process ---
            Console.WriteLine($"ETL: Processed {healthData.Count} records.")
            ' TODO: transformations (e.g., filter outliers, calculate averages).

            ' --- STEP 3: Push to Display/Graph ---
            Console.WriteLine("Pushing to Grafana...")
            ' TODO: Grafana/database logic

        Catch ex As Exception
            Console.WriteLine($"Fatal error: {ex.Message}")
        Finally
            Console.WriteLine("Press any key to exit...")
            Console.ReadKey()
        End Try
    End Sub
End Module