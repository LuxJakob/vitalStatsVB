Imports Microsoft.VisualBasic.FileIO

Public Module ParseCSV
    Public Function ReadCSV(filePath As String) As List(Of HealthRecord)
        Dim records As New List(Of HealthRecord)()

        Try
            Using parser As New TextFieldParser(filePath)
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",")
                parser.HasFieldsEnclosedInQuotes = True

                If Not parser.EndOfData Then
                    parser.ReadFields()
                End If

                While Not parser.EndOfData
                    Dim fields = parser.ReadFields()

                    Dim record As New HealthRecord With {
                        .Timestamp = DateTime.Parse(fields(0)),
                        .Weight = Double.Parse(fields(1)),
                        .AmountDonated = Integer.Parse(fields(2)),
                        .BloodPressure = $"{fields(3)}/{fields(4)}"
                    }
                    records.Add(record)
                End While
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error parsing CSV: {ex.Message}")
            Throw
        End Try

        Return records
    End Function
End Module