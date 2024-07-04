Imports Microsoft.Win32
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

Public Class Form1
    Private CurrentWebBrowserControl As Control

    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim searchText As String = TextBox1.Text.Trim()

        If String.IsNullOrWhiteSpace(searchText) Then
            MessageBox.Show("Please enter a search term.")
            Return
        End If

        ' Update history buttons based on availability
        UpdateHistoryButton(searchText)

        ' Initialize WebView2 for displaying search results
        Dim webView As New WebView2
        Dim tabPage As New TabPage

        tabPage.Text = "Google - " & searchText
        searchform.TabControl1.TabPages.Add(tabPage)
        tabPage.Controls.Add(webView)
        webView.Dock = DockStyle.Fill

        ' Initialize WebView2 and navigate to the URL
        AddHandler webView.CoreWebView2InitializationCompleted, Async Sub(sender2, e2)
                                                                    If e2.IsSuccess Then
                                                                        Await webView.EnsureCoreWebView2Async(Nothing)
                                                                        webView.CoreWebView2.Navigate("http://www.google.com/search?q=" & searchText)
                                                                        AddHandler webView.NavigationCompleted, AddressOf Run_Me_On_Load
                                                                        CurrentWebBrowserControl = webView
                                                                        ' CurrentWebBrowserControl.ScriptErrorsSuppressed = True
                                                                    Else
                                                                        MessageBox.Show("WebView2 initialization failed.")
                                                                    End If
                                                                End Sub

        webView.EnsureCoreWebView2Async(Nothing)
        searchform.Show()
        Me.Visible = False
    End Sub

    Private Sub UpdateHistoryButton(searchText As String)
        If String.IsNullOrWhiteSpace(Button8.Text) Then
            Button8.Text = searchText
            My.Settings.H1 = searchText
            Button8.Visible = True
        ElseIf String.IsNullOrWhiteSpace(Button10.Tsext) Then
            Button10.Text = searchText
            My.Settings.H2 = searchText
            Button10.Visible = True
        ElseIf String.IsNullOrWhiteSpace(Button11.Text) Then
            Button11.Text = searchText
            My.Settings.H3 = searchText
            Button11.Visible = True
        ElseIf String.IsNullOrWhiteSpace(Button12.Text) Then
            Button12.Text = searchText
            My.Settings.H4 = searchText
            Button12.Visible = True
        Else
            ' All history buttons are filled, replace the oldest one (Button8)
            Button8.Text = Button10.Text
            Button10.Text = Button11.Text
            Button11.Text = Button12.Text
            Button12.Text = searchText

            My.Settings.H1 = Button8.Text
            My.Settings.H2 = Button10.Text
            My.Settings.H3 = Button11.Text
            My.Settings.H4 = Button12.Text
        End If



        ' Update the Run_Me_On_Load method to handle WebView2 navigation completed

        'ElseIf Button11.Text IsNot "" Then 'And Button10.Text IsNot "" And Button8.Text IsNot "" Then
        '    Button12.Text = TextBox1.Text
        '    My.Settings.H4 = TextBox1.Text
        '    Button12.Visible = True

        'End If
        'End If
        'If Button8.Text = "" Then
        '    Button8.Text = history.Text
        '    My.Settings.H1 = TextBox1.Text
        '    Button8.Visible = True
        'Else Button10.Text = history.Text
        '    My.Settings.H2 = TextBox1.Text
        '    Button8.Visible = True
        'End If
        'If Button10.Text IsNot "" Then
        '    Button11.Text = history.Text
        '    My.Settings.H3 = TextBox1.
        '        Text
        '    Button8.Visible = True
        'ElseIf Button12.Text = TextBox1.Text Then
        '    My.Settings.H3 = TextBox1.Text
        '    Button8.Visible = True
        'End If

        'If Me.Visible = True Then
        '    searchform.WebBrowser1.Navigate("http://www.google.com/search?q=" + TextBox1.Text)
        '    searchform.TextBox1.Text = TextBox1.Text
        'Else
        '    searchform.TextBox1.Text = TextBox1.Text
        'End If


    End Sub
    Private Sub UpdateButton(button As Button, currentText As String, newText As String)
        If currentText = "" Then
            button.Text = newText
            My.Settings.H1 = newText
            button.Visible = True
        ElseIf button IsNot Nothing AndAlso button.Text <> "" Then
            button.Text = newText
            My.Settings.H2 = newText
            button.Visible = True
        End If
    End Sub
    Private Sub Run_Me_On_Load(sender As Object, e As CoreWebView2NavigationCompletedEventArgs)
        ' Your code to run when the document is completed loading
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'searchform.TextBox1.Text = TextBox1.Text
        'If Me.Visible = True Then
        '    searchform.WebBrowser1.Navigate("http://www.google.com/search?q=" + TextBox1.Text)
        'Else
        '    searchform.TextBox1.Text = TextBox1.Text
        'End If
        ' Set the FeatureControlKey property to use the modern version of the WebBrowser control.
        'Registry.SetValue(
        '    "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION",
        '    Application.ExecutablePath,
        '    11001,
        '    RegistryValueKind.DWord
        ')


        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        p.AddLine(20, 0, Me.Width - 20, 0)
        p.AddArc(New Rectangle(Me.Width - 20, 0, 20, 20), -90, 90)
        p.AddLine(Me.Width, 20, Me.Width, Me.Height - 20)
        p.AddArc(New Rectangle(Me.Width - 20, Me.Height - 20, 20, 20), 0, 90)
        p.AddLine(Me.Width - 20, Me.Height, 20, Me.Height)
        p.AddArc(New Rectangle(0, Me.Height - 20, 20, 20), 90, 90)
        p.CloseFigure()
        Me.Region = New Region(p)


        TextBox1.Text = "Hi, " + Environment.UserName + "..Ask me something."
        If TextBox1.Text = "Hi, " + Environment.UserName + "..Ask me something." Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If

        If My.Settings.Label4 Then
            Label4.Text = "Welcome, " + Environment.UserName
            ' Update and save the value of the setting.
            My.Settings.Label4 = False
            My.Settings.Save()
        Else
            Label4.Text = ""
        End If

        Try
            If My.Computer.Network.Ping("www.google.com") Then
                Label2.Text = "Online"
                Label2.ForeColor = Color.Green
            End If
        Catch ex As Exception
            Label2.Text = "Offline"
            Label2.ForeColor = Color.Red
        End Try

        IW = Me.Width
        IH = Me.Height

        If Not browser.IsBrowserEmulationSet() Then
            browser.SetBrowserEmulationVersion()
        End If
    End Sub

    Dim Pos As Point
    Private Sub Panel1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Location += Control.MousePosition - Pos
        End If
        Pos = Control.MousePosition
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        WindowState = FormWindowState.Maximized
    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        If TextBox1.Text = "Hi, " + Environment.UserName + "..Ask me something." Then
            Panel4.Visible = True
            TextBox1.ForeColor = Color.Black
            TextBox1.Text = ""
            Button1.Enabled = True
        End If

    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            Panel4.Visible = True
            Button1.Enabled = False
            TextBox1.Text = "Hi, " + Environment.UserName + "..Ask me something."
            TextBox1.ForeColor = Color.Gainsboro
        End If
    End Sub

    'Private Sub TextBox1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

    '    If e.KeyCode = Keys.Enter Then
    '        searchform.TextBox1.Text = TextBox1.Text
    '        If TextBox1.TextLength > 0 Then
    '            'searchform.WebBrowser1.Navigate("http://www.google.com/search?q=" + TextBox1.Text)
    '            searchform.Show()
    '            Me.Visible = False
    '        Else

    '        End If


    '    End If   
    'End Sub



    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim webBrowser As New WebBrowser
        Dim b1 As New TabPage

        If Button8.Text.Length > 1 Then
                CurrentWebBrowserControl = webBrowser
            'CurrentWebBrowserControl.ScriptErrorsSuppressed = True
            TextBox1.Text = Button8.Text
                Button10.BackgroundImage = Nothing
                Button11.BackgroundImage = Nothing
                Button12.BackgroundImage = Nothing
                ' Button8.BackgroundImage = My.Resources.Rectangle_7
                searchform.TextBox1.Text = Button8.Text
                TextBox1.ForeColor = Color.Black
                Button1.Enabled = True
                'searchform.WebBrowser1.Navigate("http://www.google.com/search?q=" + TextBox1.Text)
                b1.Text = "Google - ".ToString + Me.TextBox1.Text
                searchform.TabControl1.TabPages.Add(b1)
                b1.Controls.Add(webBrowser)
                webBrowser.Dock = DockStyle.Fill
                webBrowser.Navigate("http://www.google.com/search?q=" + Button8.Text)
                searchform.Show()
                Me.Visible = False
            Else

            End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim webBrowser As New WebBrowser
        Dim b2 As New TabPage
        Try
            If Button10.Text.Length > 1 Then
                CurrentWebBrowserControl = webBrowser
                'CurrentWebBrowserControl.ScriptErrorsSuppressed = True
                Button8.BackgroundImage = Nothing
                Button11.BackgroundImage = Nothing
                Button12.BackgroundImage = Nothing
                'Button10.BackgroundImage = My.Resources.Rectangle_7
                TextBox1.Text = Button10.Text
                searchform.TextBox1.Text = Button10.Text
                TextBox1.ForeColor = Color.Black
                Button1.Enabled = True
                Button1.Enabled = True
                'searchform.WebBrowser1.Navigate("http://www.google.com/search?q=" + TextBox1.Text)
                b2.Text = "Google - ".ToString + Me.TextBox1.Text
                searchform.TabControl1.TabPages.Add(b2)
                b2.Controls.Add(webBrowser)
                webBrowser.Dock = DockStyle.Fill
                webBrowser.Navigate("http://www.google.com/search?q=" + Button10.Text)
                searchform.Show()
                Me.Visible = False
            Else
            End If
        Catch
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            If Button8.Text.Length > 1 Then
                Button8.BackgroundImage = Nothing
                Button10.BackgroundImage = Nothing
                Button12.BackgroundImage = Nothing
                'Button11.BackgroundImage = My.Resources.Rectangle_7
                TextBox1.Text = Button11.Text
                TextBox1.ForeColor = Color.Black
                Button1.Enabled = True
            Else

            End If
        Catch
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            If Button12.Text.Length > 1 Then
                Button8.BackgroundImage = Nothing
                Button11.BackgroundImage = Nothing
                Button10.BackgroundImage = Nothing
                'Button12.BackgroundImage = My.Resources.Rectangle_7
                TextBox1.Text = Button12.Text
                TextBox1.ForeColor = Color.Black
                Button1.Enabled = True
            Else
            End If
        Catch

        End Try
    End Sub

    Private Sub Button10_KeyDown(sender As Object, e As KeyEventArgs) Handles Button10.KeyDown
        ''If e.KeyCode = Keys.Enter Then
        ''    searchform.TextBox1.Text = TextBox1.Text
        ''    If Me.Visible = True Then
        ''        searchform.WebBrowser1.Navigate("http://www.google.com/search?q=" + TextBox1.Text)
        ''    Else
        ''        searchform.TextBox1.Text = TextBox1.Text
        ''    End If

        'searchform.Show()
        '    Me.Visible = False
        'End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button8.Click
        My.Settings.Reset()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class