Public Class Form1
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'TODO:ついたちはその月の人

		Const COLUMNS As Integer = 7
		Const ROWS As Integer = 6

		Dim rate(ROWS - 1, COLUMNS - 1) As Double
		For m = 1 To 12
			For Each d In get_class_days(Now.Year, m)
				Dim row_used(ROWS - 1) As Boolean
				For i = 0 To row_used.Length - 1
					row_used(i) = False
				Next
				Dim temp_day As Integer = d.Day
				Dim x As Integer = temp_day \ ROWS
				Dim y As Integer = temp_day Mod ROWS
				For n = 1 To 25 '25人当てる
					If is_fin(row_used) Then

					Else
						row_used(y) = True
						If y > ROWS \ 2 Then
							y += 1
							If y = -1 Then
								y = ROWS - 1
							End If
						Else
							y -= 1
							If y = ROWS Then
								y = 0
							End If
						End If
					End If
				Next
			Next
		Next

		For y = 0 To ROWS - 1
			For x = 0 To COLUMNS - 1
				Debug.Write(rate(y, x) & " ")
			Next
			Debug.WriteLine("")
		Next
	End Sub

	Private Function is_fin(ByRef col() As Boolean) As Boolean
		For i = 0 To col.Length - 1
			If Not col(i) Then
				Return False
			End If
		Next
		Return True
	End Function

	Private Function get_class_days(now_year As Integer, now_month As Integer) As List(Of DateTime)
		Dim res As New List(Of DateTime)
		Dim day As New DateTime(now_year, now_month, 1)
		For i = 1 To DateTime.DaysInMonth(day.Year, day.Month)
			If day.DayOfWeek = DayOfWeek.Wednesday OrElse day.DayOfWeek = DayOfWeek.Friday Then
				res.Add(day)
			End If
			day = day.AddDays(1)
		Next
		Return res
	End Function
End Class
