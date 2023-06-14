<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        GroupBox1 = New GroupBox()
        cbShowpass = New CheckBox()
        btnExit = New Button()
        btnLogin = New Button()
        txtPassword = New TextBox()
        txtUsername = New TextBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(cbShowpass)
        GroupBox1.Controls.Add(btnExit)
        GroupBox1.Controls.Add(btnLogin)
        GroupBox1.Controls.Add(txtPassword)
        GroupBox1.Controls.Add(txtUsername)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(454, 288)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        ' 
        ' cbShowpass
        ' 
        cbShowpass.AutoSize = True
        cbShowpass.Location = New Point(118, 194)
        cbShowpass.Name = "cbShowpass"
        cbShowpass.Size = New Size(132, 24)
        cbShowpass.TabIndex = 7
        cbShowpass.Text = "Show Password"
        cbShowpass.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(118, 227)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(137, 45)
        btnExit.TabIndex = 6
        btnExit.Text = "Exit"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(261, 227)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(151, 45)
        btnLogin.TabIndex = 5
        btnLogin.Text = "&Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(118, 159)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(294, 27)
        txtPassword.TabIndex = 4
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' txtUsername
        ' 
        txtUsername.Location = New Point(118, 115)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(294, 27)
        txtUsername.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(20, 162)
        Label3.Name = "Label3"
        Label3.Size = New Size(70, 20)
        Label3.TabIndex = 2
        Label3.Text = "Password"' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(20, 118)
        Label2.Name = "Label2"
        Label2.Size = New Size(75, 20)
        Label2.TabIndex = 1
        Label2.Text = "Username"' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Black", 18F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label1.Location = New Point(118, 38)
        Label1.Name = "Label1"
        Label1.Size = New Size(189, 41)
        Label1.TabIndex = 0
        Label1.Text = "Payroll Bali"' 
        ' frmLogin
        ' 
        AcceptButton = btnLogin
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(480, 308)
        Controls.Add(GroupBox1)
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login Payroll Bali"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbShowpass As CheckBox
End Class
