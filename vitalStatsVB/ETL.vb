Imports System.Text.Json

Public Module ETL
    Public Sub ETLforJSON(healthData As List(Of HealthRecord))

        Dim options As New JsonSerializerOptions With {
            .WriteIndented = True,
            .PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }
        Dim json As String = JsonSerializer.Serialize(healthData, options)

        Dim jsonPath As String = "health_data.json"
        System.IO.File.WriteAllText(jsonPath, json)
        Console.WriteLine($"Saved JSON to: {System.IO.Path.GetFullPath(jsonPath)}")

    End Sub

End Module
