<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatus
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.lbText = New Infragistics.Win.Misc.UltraLabel
        Me.SuspendLayout()
        '
        'lbText
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 15.0!
        Me.lbText.Appearance = Appearance1
        Me.lbText.Location = New System.Drawing.Point(12, 35)
        Me.lbText.Name = "lbText"
        Me.lbText.Size = New System.Drawing.Size(441, 36)
        Me.lbText.TabIndex = 0
        '
        'frmStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(468, 99)
        Me.Controls.Add(Me.lbText)
        Me.Name = "frmStatus"
        Me.Text = "Updating..."
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbText As Infragistics.Win.Misc.UltraLabel
End Class
