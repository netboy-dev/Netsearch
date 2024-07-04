Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms


Public Class searchform
    Private CurrentWebBrowserControl As Control

    'Dim webBrowser As New WebBrowser
    Dim ival As Integer = 0
    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height
    Public Sub Run_Me_On_Load(sender As Object, e As EventArgs)
        'Timer1.Stop()
        'Timer1.Enabled = False
        'Label1.Show()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim bing As New TabPage
    '    If Form1.TextBox1.Visible = True Then
    '        'WebBrowser1.Navigate("https://www.bing.com/search?q=" + Form1.TextBox1.Text)
    '        bing.Text = "Bing - ".ToString + TextBox1.Text
    '        TabControl1.TabPages.Add(bing)
    '        Dim webBrowser As New WebBrowser
    '        TabControl1.SelectedTab = bing
    '        bing.Controls.Add(webBrowser)
    '        webBrowser.Dock = DockStyle.Fill
    '        webBrowser.ScriptErrorsSuppressed = True
    '        webBrowser.Navigate("https://www.bing.com/search?q=" + TextBox1.Text)
    '        AddHandler webBrowser.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf Run_Me_On_Load)
    '        CurrentWebBrowserControl = webBrowser
    '        Label1.Text = "Bing"

    '        Timer1.Enabled = True
    '        ival = 0
    '        Timer1.Start()

    '    Else
    '        'WebBrowser1.Navigate("https://www.bing.com/search?q=" + TextBox1.Text)
    '        bing.Text = "Bing - ".ToString + TextBox1.Text
    '        TabControl1.TabPages.Add(bing)
    '        Dim webBrowser As New WebBrowser
    '        TabControl1.SelectedTab = bing
    '        bing.Controls.Add(webBrowser)
    '        webBrowser.Dock = DockStyle.Fill
    '        webBrowser.ScriptErrorsSuppressed = True
    '        webBrowser.Navigate("https://www.bing.com/search?q=" + TextBox1.Text)
    '        CurrentWebBrowserControl = webBrowser
    '        Label1.Text = "Bing"

    '        Timer1.Enabled = True
    '        ival = 0
    '        Timer1.Start()

    '    End If
    'End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bing As New TabPage
        bing.Text = "Bing - " & TextBox1.Text
        TabControl1.TabPages.Add(bing)

        Dim webView As New WebView2
        TabControl1.SelectedTab = bing
        bing.Controls.Add(webView)
        webView.Dock = DockStyle.Fill

        ' Initialize WebView2 and navigate to the URL
        AddHandler webView.CoreWebView2InitializationCompleted, Async Sub(sender2, e2)
                                                                    Try
                                                                        If e2.IsSuccess Then
                                                                            Await webView.EnsureCoreWebView2Async(Nothing)
                                                                            webView.CoreWebView2.Navigate("https://www.bing.com/search?q=" & TextBox1.Text)
                                                                            AddHandler webView.NavigationCompleted, AddressOf Run_Me_On_Load
                                                                            AddHandler webView.CoreWebView2.NewWindowRequested, AddressOf WebView_NewWindowRequested
                                                                            CurrentWebBrowserControl = webView
                                                                        Else
                                                                            'MessageBox.Show("WebView2 initialization failed.")

                                                                        End If
                                                                    Catch
                                                                    End Try
                                                                End Sub

        webView.EnsureCoreWebView2Async(Nothing)

        Label1.Text = "Bing"

        Timer1.Enabled = True
        ival = 0
        Timer1.Start()
    End Sub

    ' Handle NewWindowRequested to prevent opening popups
    Private Sub WebView_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs)
        e.Handled = True
        If TypeOf CurrentWebBrowserControl Is WebView2 Then
            DirectCast(CurrentWebBrowserControl, WebView2).CoreWebView2.Navigate(e.Uri)
        End If
    End Sub

    ' Update the Run_Me_On_Load method to handle WebView2 navigation completed
    Private Sub Run_Me_On_Load(sender As Object, e As CoreWebView2NavigationCompletedEventArgs)
        ' Your code to run when the document is completed loading
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim yandex As New TabPage
        If Form1.TextBox1.Visible = True Then
            'WebBrowser1.Navigate("https://yandex.com/search/?text=" + TextBox1.Text)
            yandex.Text = "Yandex - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(yandex)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = yandex
            yandex.Controls.Add(webBrowser)
            webBrowser.ScriptErrorsSuppressed = True
            webBrowser.Dock = DockStyle.Fill
            webBrowser.Navigate("https://yandex.com/search/?text=" + TextBox1.Text)

            Label1.Text = "Yandex"
            CurrentWebBrowserControl = webBrowser
            Timer1.Enabled = True
            ival = 0
            Timer1.Start()

        Else
            ' WebBrowser1.Navigate("https://yandex.com/search/?text=" + TextBox1.Text)
            yandex.Text = "Yandex - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(yandex)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = yandex
            yandex.Controls.Add(webBrowser)
            webBrowser.Dock = DockStyle.Fill
            webBrowser.ScriptErrorsSuppressed = True
            webBrowser.Navigate("https://yandex.com/search/?text=" + TextBox1.Text)
            Label1.Text = "Yandex"
            CurrentWebBrowserControl = webBrowser
            Timer1.Enabled = True
            ival = 0
            Timer1.Start()


        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim duck As New TabPage
        'If e.KeyChar = ChrW(Keys.Enter) Then
        Dim webBrowser As New WebBrowser
        Dim words As String() = TextBox1.Text.Split("")
        Dim detectWords As New List(Of String) From {"https://", "http://", "http", "www", "www.", ".com"}
        For Each word As String In words
            If detectWords.Contains(word.ToLower) Then
                'WebBrowser1.Navigate("https://duckduckgo.com/?q=" + TextBox1.Text)
                duck.Text = TextBox1.Text
                TabControl1.TabPages.Add(duck)
                duck.Text = "Duckduckgo - ".ToString + TextBox1.Text
                TabControl1.SelectedTab = duck
                duck.Controls.Add(webBrowser)
                webBrowser.Dock = DockStyle.Fill
                webBrowser.ScriptErrorsSuppressed = True
                webBrowser.Navigate(TextBox1.Text)
                Label1.Text = "Web"
                CurrentWebBrowserControl = webBrowser
                Timer1.Enabled = True
                ival = 0
                Timer1.Start()

            Else
                ' WebBrowser1.Navigate("https://duckduckgo.com/?q=" + TextBox1.Text)
                duck.Text = TextBox1.Text
                duck.Text = "Duckduckgo - ".ToString + TextBox1.Text
                TabControl1.TabPages.Add(duck)
                TabControl1.SelectedTab = duck
                duck.Controls.Add(webBrowser)
                webBrowser.Dock = DockStyle.Fill
                webBrowser.ScriptErrorsSuppressed = True
                webBrowser.Navigate(TextBox1.Text)
                Label1.Text = "Web"
                CurrentWebBrowserControl = webBrowser
                Timer1.Enabled = True
                ival = 0
                Timer1.Start()

            End If
        Next

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim yahoo As New TabPage
        If Form1.TextBox1.Visible = True Then
            'WebBrowser1.Navigate("https://search.yahoo.com/search;_ylt=AwrJ6ypiT1tflYAAvFVDDWVH;_ylc=X1MDMTE5NzgwNDg2NwRfcgMyBGZyAwRncHJpZAMuR0ZzX2dVRlFrdXh3S2FmRDJqTGZBBG5fcnNsdAMwBG5fc3VnZwMxMARvcmlnaW4Dc2VhcmNoLnlhaG9vLmNvbQRwb3MDMARwcXN0cgMEcHFzdHJsAwRxc3RybAM3BHF1ZXJ5A3NlYXJjaGoEdF9zdG1wAzE1OTk4MTk2MjU-?fr2=sb-top-search&p=" + TextBox1.Text)
            yahoo.Text = "Yahoo - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(yahoo)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = yahoo
            yahoo.Controls.Add(webBrowser)
            webBrowser.Dock = DockStyle.Fill
            webBrowser.ScriptErrorsSuppressed = True
            webBrowser.Navigate("https://search.yahoo.com/search;_ylt=AwrJ6ypiT1tflYAAvFVDDWVH;_ylc=X1MDMTE5NzgwNDg2NwRfcgMyBGZyAwRncHJpZAMuR0ZzX2dVRlFrdXh3S2FmRDJqTGZBBG5fcnNsdAMwBG5fc3VnZwMxMARvcmlnaW4Dc2VhcmNoLnlhaG9vLmNvbQRwb3MDMARwcXN0cgMEcHFzdHJsAwRxc3RybAM3BHF1ZXJ5A3NlYXJjaGoEdF9zdG1wAzE1OTk4MTk2MjU-?fr2=sb-top-search&p=" + TextBox1.Text)
            Label1.Text = "Yahoo"
            CurrentWebBrowserControl = webBrowser
            Timer1.Enabled = True
            ival = 0
            Timer1.Start()

        Else
            'WebBrowser1.Navigate("https://search.yahoo.com/search;_ylt=AwrJ6ypiT1tflYAAvFVDDWVH;_ylc=X1MDMTE5NzgwNDg2NwRfcgMyBGZyAwRncHJpZAMuR0ZzX2dVRlFrdXh3S2FmRDJqTGZBBG5fcnNsdAMwBG5fc3VnZwMxMARvcmlnaW4Dc2VhcmNoLnlhaG9vLmNvbQRwb3MDMARwcXN0cgMEcHFzdHJsAwRxc3RybAM3BHF1ZXJ5A3NlYXJjaGoEdF9zdG1wAzE1OTk4MTk2MjU-?fr2=sb-top-search&p=" + TextBox1.Text)
            yahoo.Text = "Yahoo - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(yahoo)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = yahoo
            yahoo.Controls.Add(webBrowser)
            webBrowser.Dock = DockStyle.Fill
            webBrowser.ScriptErrorsSuppressed = True
            webBrowser.Navigate("https://search.yahoo.com/search;_ylt=AwrJ6ypiT1tflYAAvFVDDWVH;_ylc=X1MDMTE5NzgwNDg2NwRfcgMyBGZyAwRncHJpZAMuR0ZzX2dVRlFrdXh3S2FmRDJqTGZBBG5fcnNsdAMwBG5fc3VnZwMxMARvcmlnaW4Dc2VhcmNoLnlhaG9vLmNvbQRwb3MDMARwcXN0cgMEcHFzdHJsAwRxc3RybAM3BHF1ZXJ5A3NlYXJjaGoEdF9zdG1wAzE1OTk4MTk2MjU-?fr2=sb-top-search&p=" + TextBox1.Text)
            CurrentWebBrowserControl = webBrowser
            Label1.Text = "Yahoo"

            Timer1.Enabled = True
            ival = 0
            Timer1.Start()

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim aol As New TabPage
        If Form1.TextBox1.Visible = True Then
            'WebBrowser1.Navigate("https://search.aol.co.uk/aol/search?s_chn=prt_bon&q=" + TextBox1.Text)
            aol.Text = "Aol - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(aol)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = aol
            aol.Controls.Add(webBrowser)
            webBrowser.ScriptErrorsSuppressed = True
            webBrowser.Dock = DockStyle.Fill
            webBrowser.Navigate("https://search.aol.co.uk/aol/search?s_chn=prt_bon&q=" + TextBox1.Text)
            CurrentWebBrowserControl = webBrowser
            Label1.Text = "Aol"

            Timer1.Enabled = True
            ival = 0
            Timer1.Start()

        Else
            'WebBrowser1.Navigate("https://search.aol.co.uk/aol/search?s_chn=prt_bon&q=" + TextBox1.Text)
            aol.Text = "Aol - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(aol)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = aol
            aol.Controls.Add(webBrowser)
            webBrowser.Dock = DockStyle.Fill
            webBrowser.ScriptErrorsSuppressed = True
            webBrowser.Navigate("https://search.aol.co.uk/aol/search?s_chn=prt_bon&q=" + TextBox1.Text)
            CurrentWebBrowserControl = webBrowser
            Label1.Text = "Aol"

            Timer1.Enabled = True
            ival = 0
            Timer1.Start()

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ask As New TabPage
        If Form1.TextBox1.Visible = True Then
            'WebBrowser1.Navigate("https://www.ask.com/web?o=0&l=dir&qo=serpSearchTopBox&q=" + TextBox1.Text)
            ask.Text = "Ask - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(ask)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = ask
            ask.Controls.Add(webBrowser)
            webBrowser.Dock = DockStyle.Fill
            webBrowser.ScriptErrorsSuppressed = True
            webBrowser.Navigate("https://www.ask.com/web?o=0&l=dir&qo=serpSearchTopBox&q=" + TextBox1.Text)
            CurrentWebBrowserControl = webBrowser
            Label1.Text = "Ask"
            AddHandler webBrowser.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf Run_Me_On_Load)
            Timer1.Enabled = True
            ival = 0
            Timer1.Start()

        Else
            'WebBrowser1.Navigate("https://www.ask.com/web?o=0&l=dir&qo=serpSearchTopBox&q=" + TextBox1.Text)
            ask.Text = "Ask - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(ask)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = ask
            ask.Controls.Add(webBrowser)
            webBrowser.Dock = DockStyle.Fill
            webBrowser.ScriptErrorsSuppressed = True
            webBrowser.Navigate("https://www.ask.com/web?o=0&l=dir&qo=serpSearchTopBox&q=" + TextBox1.Text)
            CurrentWebBrowserControl = webBrowser
            Label1.Text = "Ask"

            Timer1.Enabled = True
            ival = 0
            Timer1.Start()


        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim edu As New TabPage
        If Form1.TextBox1.Visible = True Then
            edu.Text = "Wikipedia - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(edu)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = edu
            edu.Controls.Add(webBrowser)
            webBrowser.Dock = DockStyle.Fill
            webBrowser.ScriptErrorsSuppressed = True
            webBrowser.Navigate("https://en.wikipedia.org/wiki/" + TextBox1.Text)
            CurrentWebBrowserControl = webBrowser
            Label1.Text = "Wikipedia"

            Timer1.Enabled = True

            Timer1.Start()
        Else
            edu.Text = "Wikipedia - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(edu)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = edu
            edu.Controls.Add(webBrowser)
            webBrowser.Dock = DockStyle.Fill
            webBrowser.ScriptErrorsSuppressed = True
            webBrowser.Navigate("https://en.wikipedia.org/wiki/" + TextBox1.Text)
            CurrentWebBrowserControl = webBrowser

            Label1.Text = "Education"

            Timer1.Enabled = True

            Timer1.Start()

        End If


    End Sub
    Private Sub round()
        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 30, 30), 180, 90)
        p.AddLine(30, 0, Me.Width - 30, 0)
        p.AddArc(New Rectangle(Me.Width - 30, 0, 30, 30), -90, 90)
        p.AddLine(Me.Width, 30, Me.Width, Me.Height - 30)
        p.AddArc(New Rectangle(Me.Width - 30, Me.Height - 30, 30, 30), 0, 90)
        p.AddLine(Me.Width - 30, Me.Height, 30, Me.Height)
        p.AddArc(New Rectangle(0, Me.Height - 30, 30, 30), 90, 90)
        p.CloseFigure()
        Me.Region = New Region(p)
    End Sub
    Private Sub No()
        'Region = New Region(New Rectangle(0, 0, Width, Height))
        Invalidate()
    End Sub

    Private Sub searchform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer1.Enabled = True
        TextBox1.Text = Form1.TextBox1.Text
        'round()

        IW = Me.Width
        IH = Me.Height

        Me.MaximumSize = New Size(My.Computer.Screen.WorkingArea.Size.Width,
                                  My.Computer.Screen.WorkingArea.Size.Height - 1)
        If Not browser.IsBrowserEmulationSet() Then
            browser.SetBrowserEmulationVersion()
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)
        Timer1.Stop()
        Timer1.Enabled = False
        Label1.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim tabpage As New TabPage
        Dim webBrowser As New WebBrowser
        TabControl1.SelectedTab = tabpage
        tabpage.Text = "Google - ".ToString + TextBox1.Text
        TabControl1.TabPages.Add(tabpage)
        tabpage.Controls.Add(webBrowser)
        webBrowser.Dock = DockStyle.Fill
        webBrowser.ScriptErrorsSuppressed = True
        webBrowser.Navigate("http://www.google.com/search?q=" + TextBox1.Text)
        CurrentWebBrowserControl = webBrowser
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        'No()
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form1.Show()
        Me.Hide()
    End Sub

    'Private Sub Panel1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
    '    If e.Button = MouseButtons.Left Then
    '        Me.Location += Control.MousePosition - Pos
    '    End If
    '    Pos = Control.MousePosition
    'End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.ParentChanged
        Me.TextBox1.Text = TextBox1.Text
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Try
            ' Assuming CurrentWebBrowserControl is properly set elsewhere in your application
            Dim webView As WebView2 = TryCast(CurrentWebBrowserControl, WebView2)

            ' Check if webView is not null and can navigate forward
            If webView IsNot Nothing AndAlso webView.CoreWebView2.CanGoForward Then
                webView.CoreWebView2.GoForward()
            Else
                MessageBox.Show("Cannot go forward.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error navigating forward: " & ex.Message)
        End Try
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Try
            CurrentWebBrowserControl.Refresh()
        Catch
        End Try
    End Sub

    Dim i As Integer

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'ival = ival + 1
        'If ival = 7 Then
        '    If Label1.Visible = False Then

        '    End If
        'End If

        If TabControl1.TabPages.Count < 1 Then
            Me.Hide()
            Form1.StartPosition = FormStartPosition.CenterScreen
            Form1.Show()
        End If


    End Sub
    'Private Sub TextBox1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        WebBrowser1.Navigate("http://www.google.com/search?q=" + TextBox1.Text)
    '    End If
    'End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress


    End Sub
    Dim Pos As Point
    Private Sub searchform_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Location += Control.MousePosition - Pos
        End If
        Pos = Control.MousePosition
    End Sub

    'Private Sub searchform_Resize(sender As Object, e As EventArgs) Handles Me.Resize
    '    Me.OnResize(e)

    '    If (WindowState = FormWindowState.Maximized) Then
    '        round()
    '    Else
    '        No()
    '    End If
    'End Sub
    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem


        'Dim g As Graphics = e.Graphics
        'Dim tp As TabPage = TabControl1.TabPages(e.Index)
        'Dim br As Brush
        'Dim sf As New StringFormat
        'Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)

        'sf.Alignment = StringAlignment.Center
        'Dim strTitle As String = tp.Text
        ''If the current index is the Selected Index, change the color
        'If TabControl1.SelectedIndex = e.Index Then
        '    'this is the background color of the tabpage
        '    'you could make this a stndard color for the selected page
        '    br = New SolidBrush(tp.BackColor)
        '    'this is the background color of the tab page
        '    g.FillRectangle(br, e.Bounds)
        '    'this is the background color of the tab page
        '    'you could make this a stndard color for the selected page
        '    'br = New SolidBrush(tp.ForeColor)
        '    'g.DrawString(strTitle, TabControl1.Font, br, r, sf)
        'Else
        '    'these are the standard colors for the unselected tab pages
        '    br = New SolidBrush(Color.GhostWhite)
        '    g.FillRectangle(br, e.Bounds)
        '    br = New SolidBrush(Color.Transparent)
        '    g.DrawString(strTitle, TabControl1.Font, br, r, sf)

        'End If


        ''  Identify which TabPage is currently selected
        'Dim SelectedTab As TabPage = TabControl1.TabPages(e.Index)
        ''e.Graphics.FillRectangle(New SolidBrush(Color.Blue), e.Bounds)
        ''  Get the area of the header of this TabPage
        ''Dim HeaderRect As Rectangle = TabControl1.GetTabRect(e.Index)
        'Dim HeaderRect As Rectangle = TabControl1.GetTabRect(e.Index)

        ''  Create two Brushes to paint the Text
        'Dim BlackTextBrush As New SolidBrush(Color.Blue)
        'Dim RedTextBrush As New SolidBrush(Color.Transparent)

        ''  Set the Alignment of the Text
        'Dim sf As New StringFormat()
        'sf.Alignment = StringAlignment.Center
        'sf.LineAlignment = StringAlignment.Center

        ''  Paint the Text using the appropriate Bold and Color setting 
        'If Convert.ToBoolean(e.State And DrawItemState.Selected) Then

        '    e.Graphics.FillRectangle(New SolidBrush(Color.White), HeaderRect)
        '    Dim BoldFont As New Font(TabControl1.Font.Name, TabControl1.Font.Size, FontStyle.Bold)
        '    e.Graphics.DrawString(SelectedTab.Text, BoldFont, RedTextBrush, HeaderRect, sf)

        'Else
        '    e.Graphics.DrawString(SelectedTab.Text, e.Font, BlackTextBrush, HeaderRect, sf)
        'End If

        ''  Job done - dispose of the Brushes
        'BlackTextBrush.Dispose()
        'RedTextBrush.DisposePrivate Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics = e.Graphics

        Dim tp As TabPage = TabControl1.TabPages(e.Index)

        Dim br As Brush

        Dim sf As New StringFormat

        Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)



        sf.Alignment = StringAlignment.Center



        Dim strTitle As String = tp.Text

        'If the current index is the Selected Index, change the color

        If TabControl1.SelectedIndex = e.Index Then

            'this is the background color of the tabpage

            'you could make this a stndard color for the selected page

            br = New SolidBrush(Color.White)

            'this is the background color of the tab page

            g.FillRectangle(br, e.Bounds)

            'this is the background color of the tab page

            'you could make this a stndard color for the selected page

            br = New SolidBrush(tp.ForeColor)

            ' g.DrawString(strTitle, TabControl1.Font, br, r, sf)

        Else

            'these are the standard colors for the unselected tab pages

            br = New SolidBrush(Color.WhiteSmoke)

            g.FillRectangle(br, e.Bounds)

            br = New SolidBrush(Color.Blue)

            ' g.DrawString(strTitle, TabControl1.Font, br, r, sf)

        End If


        e.Graphics.DrawString("X", e.Font, Brushes.Red, e.Bounds.Right - 15, e.Bounds.Top + 4)
        e.Graphics.DrawString(TabControl1.TabPages(e.Index).Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4)
        e.DrawFocusRectangle()

    End Sub

    Private Sub TabControl1_MouseDown(sender As Object, e As MouseEventArgs) Handles TabControl1.MouseDown
        'Error at closing first tab from from1
        Try
            For i As Integer = 0 To TabControl1.TabPages.Count - 1
                Dim r As Rectangle = TabControl1.GetTabRect(i)
                Dim closeButton As Rectangle = New Rectangle(r.Right - 15, r.Top + 4, 9, 7)
                If closeButton.Contains(e.Location) Then
                    TabControl1.TabPages.RemoveAt(i)
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim wolf As New TabPage
        If Form1.TextBox1.Visible = True Then
            wolf.Text = "Wolframalpha - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(wolf)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = wolf
            wolf.Controls.Add(webBrowser)
            webBrowser.Dock = DockStyle.Fill
            webBrowser.ScriptErrorsSuppressed = True
            CurrentWebBrowserControl = webBrowser
            webBrowser.Navigate("https://www.wolframalpha.com/input?i=" + TextBox1.Text)

            'Label1.Text = "Wolframalpha"

            Timer1.Enabled = True

            Timer1.Start()
        Else
            wolf.Text = "Wolframalpha - ".ToString + TextBox1.Text
            TabControl1.TabPages.Add(wolf)
            Dim webBrowser As New WebBrowser
            TabControl1.SelectedTab = wolf
            wolf.Controls.Add(webBrowser)
            webBrowser.Dock = DockStyle.Fill
            webBrowser.ScriptErrorsSuppressed = True
            CurrentWebBrowserControl = webBrowser
            webBrowser.Navigate("https://www.wolframalpha.com/input?i=" + TextBox1.Text)
            'Label1.Text = "Wolframalpha"

            Timer1.Enabled = True

            Timer1.Start()

        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

        Try
            ' Assuming CurrentWebBrowserControl is properly set elsewhere in your application
            Dim webView As WebView2 = TryCast(CurrentWebBrowserControl, WebView2)

            ' Check if webView is not null and can navigate back
            If webView IsNot Nothing AndAlso webView.CoreWebView2.CanGoBack Then
                webView.CoreWebView2.GoBack()
            Else
                MessageBox.Show("Cannot go back.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error navigating back: " & ex.Message)
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim search As New TabPage
        'If e.KeyChar = ChrW(Keys.Enter) Then
        Dim webBrowser As New WebBrowser
        Dim words As String() = TextBox1.Text.Split("")
        Dim detectWords As New List(Of String) From {"https://", "http://", "http", "www", "www.", ".com"}
        For Each word As String In words
            If detectWords.Contains(word.ToLower) Then
                'WebBrowser1.Navigate("https://duckduckgo.com/?q=" + TextBox1.Text)
                search.Text = TextBox1.Text
                TabControl1.TabPages.Add(search)

                TabControl1.SelectedTab = search
                search.Controls.Add(webBrowser)
                webBrowser.Dock = DockStyle.Fill
                webBrowser.ScriptErrorsSuppressed = True
                webBrowser.Navigate(TextBox1.Text)
                Label1.Text = "Web"
                CurrentWebBrowserControl = webBrowser
                Timer1.Enabled = True
                ival = 0
                Timer1.Start()

            Else
                ' WebBrowser1.Navigate("https://duckduckgo.com/?q=" + TextBox1.Text)
                search.Text = TextBox1.Text
                TabControl1.TabPages.Add(search)
                TabControl1.SelectedTab = search
                search.Controls.Add(webBrowser)
                webBrowser.Dock = DockStyle.Fill
                webBrowser.ScriptErrorsSuppressed = True
                webBrowser.Navigate(TextBox1.Text)
                Label1.Text = "Web"
                CurrentWebBrowserControl = webBrowser
                Timer1.Enabled = True
                ival = 0
                Timer1.Start()

            End If
        Next
    End Sub
End Class