Public Class frmPassword

    Private Sub txtPwd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPwd.KeyUp
        If txtPwd.Text.Length = Len(ObtenerPassword()) Then
            If txtPwd.Text = ObtenerPassword() Then
                frmKL.Visible = True
                Me.Close()
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub tmrCierra_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCierra.Tick
        Me.Close()
    End Sub

    Private Sub frmPassword_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmKL.tmrKL.Enabled = True
    End Sub

    Private Sub frmPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Activate()
        frmKL.tmrKL.Enabled = False
    End Sub
End Class