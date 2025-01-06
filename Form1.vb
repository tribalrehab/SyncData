Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO



Module INIHandler
    ' Declare the functions from kernel32.dll
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Function WritePrivateProfileString(lpAppName As String, lpKeyName As String, lpString As String, lpFileName As String) As Boolean
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Function GetPrivateProfileString(lpAppName As String, lpKeyName As String, lpDefault As String, lpReturnedString As StringBuilder, nSize As Integer, lpFileName As String) As Integer
    End Function

    ' Write to INI File
    Public Sub WriteToINI(section As String, key As String, value As String, filePath As String)
        WritePrivateProfileString(section, key, value, filePath)
    End Sub

    ' Read from INI File
    Public Function ReadFromINI(section As String, key As String, filePath As String, Optional defaultValue As String = "") As String
        Dim returnValue As New StringBuilder(255)
        GetPrivateProfileString(section, key, defaultValue, returnValue, returnValue.Capacity, filePath)
        Return returnValue.ToString()
    End Function

    ' Save multiline text to INI
    Public Sub WriteMultilineToINI(section As String, key As String, value As String, filePath As String)
        ' Replace line breaks with a unique placeholder
        Dim singleLineValue As String = value.Replace(Environment.NewLine, "|")
        WritePrivateProfileString(section, key, singleLineValue, filePath)
    End Sub

    ' Read multiline text from INI
    Public Function ReadMultilineFromINI(section As String, key As String, filePath As String, Optional defaultValue As String = "") As String
        Dim singleLineValue As New StringBuilder(255)
        GetPrivateProfileString(section, key, defaultValue, singleLineValue, singleLineValue.Capacity, filePath)
        ' Replace placeholder with line breaks
        Return singleLineValue.ToString().Replace("|", Environment.NewLine)
    End Function

End Module
Public Class Form1
    Private iniFilePath As String = IO.Path.Combine(Application.StartupPath, "settings.ini")
    Public Function PathNumber(folderPath As String) As Integer
        ' Ensure the folder path is consistent (e.g., lowercase, trimmed)
        Dim normalizedPath As String = folderPath.Trim().ToLower()

        ' Compute a hash value using MD5 (or SHA256 for more complexity)
        Using md5 As MD5 = MD5.Create()
            Dim hashBytes As Byte() = md5.ComputeHash(Encoding.UTF8.GetBytes(normalizedPath))

            ' Convert the first 4 bytes of the hash to an integer
            ' This creates a unique, deterministic number for the path
            Dim uniqueNumber As Integer = BitConverter.ToInt32(hashBytes, 0)

            Return Math.Abs(uniqueNumber).ToString()
            ' Ensure it's non-negative
        End Using
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Hide()
        'Populate UI Elements
        populateUIElements()

        'Load UI elements from configuration file
        loadUIElements()

        'NotifyIcon Configuration

        NotifyIcon1.ContextMenuStrip = ContextMenuStrip1
        NotifyIcon1.Visible = True


    End Sub

    Sub populateUIElements()
        Label3.Text = ""
        ComboBox1.Items.Add("5 Minutes")
        ComboBox1.Items.Add("10 Minutes")
        ComboBox1.Items.Add("15 Minutes")
        ComboBox1.Items.Add("30 Minutes")
        ComboBox1.Items.Add("Every Hour")
        ComboBox1.Items.Add("Every 4 Hours")
        ComboBox1.Items.Add("Every 8 Hours")
        ComboBox1.Items.Add("Every 12 Hours")
    End Sub

    Sub loadUIElements()
        TextBox1.Text = ReadMultilineFromINI("BackupLocation", "Path", iniFilePath, "")
        UpdateIniFilePath()

        TextBox2.Text = ReadMultilineFromINI("FolderPaths", "Paths", iniFilePath, "")
        Dim intervalSetting As String = ReadFromINI("TimerSettings", "Interval", iniFilePath, "Every Hour")
        ComboBox1.SelectedItem = intervalSetting
        Timer1.Enabled = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Configure the timer for each selected interval
        Select Case ComboBox1.SelectedItem.ToString()
            Case "5 Minutes"
                Timer1.Interval = 5 * 60 * 1000 ' 5 minutes in milliseconds
            Case "10 Minutes"
                Timer1.Interval = 10 * 60 * 1000 ' 10 minutes in milliseconds
            Case "15 Minutes"
                Timer1.Interval = 15 * 60 * 1000 ' 15 minutes in milliseconds
            Case "30 Minutes"
                Timer1.Interval = 30 * 60 * 1000 ' 30 minutes in milliseconds
            Case "Every Hour"
                Timer1.Interval = 60 * 60 * 1000 ' 1 hour in milliseconds
            Case "Every 4 Hours"
                Timer1.Interval = 4 * 60 * 60 * 1000 ' 4 hours in milliseconds
            Case "Every 8 Hours"
                Timer1.Interval = 8 * 60 * 60 * 1000 ' 8 hours in milliseconds
            Case "Every 12 Hours"
                Timer1.Interval = 12 * 60 * 60 * 1000 ' 12 hours in milliseconds
        End Select

        ' Save settings to INI file
        SaveSettings()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub SaveSettings()
        If ComboBox1.SelectedItem = "" Then
            ComboBox1.SelectedItem = "Every Hour"
        End If
        WriteToINI("TimerSettings", "Interval", ComboBox1.SelectedItem.ToString(), iniFilePath)
        WriteToINI("BackupLocation", "Path", TextBox1.Text, iniFilePath)
        WriteMultilineToINI("FolderPaths", "Paths", TextBox2.Text, iniFilePath)
    End Sub



    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        ' Save configuration
        SaveSettings()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        ' Save configuration
        SaveSettings()

        'Reload settings from filepath

    End Sub
    Private Sub UpdateIniFilePath()
        Dim newPath As String = TextBox1.Text

        ' Validate if the path is valid and exists
        If IO.Directory.Exists(newPath) Then
            ' Combine the directory with a filename for the INI file
            iniFilePath = IO.Path.Combine(newPath, "settings.ini")
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveSettings()
        Me.Hide()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True ' Cancel the close event
        Me.Hide()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Sub SyncPaths()
        Label3.Text = "Synchronizing ... "
        Dim linesArray As String() = TextBox2.Lines
        For Each line As String In linesArray
            Dim source = line.Replace("%USERNAME%", Environment.UserName)
            Dim destination = TextBox1.Text
            destination = Path.Combine(destination, "Data", PathNumber(line))

            SynchronizeFolders(source, destination)
            SynchronizeFolders(destination, source)

        Next
        Label3.Text = "Sync Completed"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SyncPaths()
    End Sub

    Private Sub ManualSyncToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualSyncToolStripMenuItem.Click
        SyncPaths()
    End Sub
    Function GenerateUniqueString(input As String) As String
        ' Ensure the input is not null or empty.
        If String.IsNullOrEmpty(input) Then
            Throw New ArgumentException("Input string cannot be null or empty.")
        End If

        ' Use SHA256 to compute the hash of the input string.
        Using sha256 As SHA256 = SHA256.Create()
            ' Convert the input string to a byte array.
            Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input)

            ' Compute the hash.
            Dim hashBytes As Byte() = sha256.ComputeHash(inputBytes)

            ' Convert the hash bytes to a Base64 string for readability.
            Return Convert.ToBase64String(hashBytes)
        End Using
    End Function
    Public Sub SynchronizeFolders(sourceFolder As String, targetFolder As String)
        ' Ensure the target directory exists.
        If Not Directory.Exists(targetFolder) Then
            Directory.CreateDirectory(targetFolder)
        End If

        ' Get all files from the source folder.
        Dim sourceFiles = Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories)

        ' Configure the progress bar.
        ProgressBar1.Maximum = sourceFiles.Length
        ProgressBar1.Value = 0

        For Each sourceFile In sourceFiles
            ' Determine the relative path of the file.
            Dim relativePath = Path.GetRelativePath(sourceFolder, sourceFile)

            ' Map the relative path to the target folder.
            Dim targetFile = Path.Combine(targetFolder, relativePath)

            ' Ensure the target subdirectory exists.
            Dim targetDirectory = Path.GetDirectoryName(targetFile)
            If Not Directory.Exists(targetDirectory) Then
                Directory.CreateDirectory(targetDirectory)
            End If

            ' Copy the file if it is new or has been modified.
            If Not File.Exists(targetFile) OrElse File.GetLastWriteTime(sourceFile) > File.GetLastWriteTime(targetFile) Then
                File.Copy(sourceFile, targetFile, True)
                Debug.Print($"Copied: {sourceFile} -> {targetFile}")
            Else
                Debug.Print($"Skipping: {sourceFile} -> {targetFile}")
            End If

            ' Update the progress bar.
            ProgressBar1.Value += 1
            Label3.Invalidate()
            Label3.Update()
            Label3.Text = "Synchronizing"
        Next
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Environment.Exit(0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SyncPaths()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
